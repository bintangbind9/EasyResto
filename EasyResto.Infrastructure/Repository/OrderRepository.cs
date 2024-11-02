using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
using EasyResto.Domain.Enums;
using EasyResto.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace EasyResto.Infrastructure.Repository
{
    public class OrderRepository : IBaseRepository<Order>
    {
        private readonly string _objName = "Order";
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<OrderRepository> _logger;
        private readonly string? _appUserId;
        private readonly string _prefixCode = "ORD";

        public OrderRepository(IDbContextFactory<EasyRestoDbContext> factory, ILogger<OrderRepository> logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = factory.CreateDbContext();
            _logger = logger;
            _appUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public async Task CreateAsync(Order obj)
        {
            try
            {
                #region Waiter
                if (string.IsNullOrWhiteSpace(_appUserId)) throw new Exception("Current User Id not found.");
                var waiter = await _context.AppUsers.FindAsync(Guid.Parse(_appUserId!));
                if (waiter == null) throw new Exception($"Waiter with Id {_appUserId} not found.");
                obj.Waiter = waiter;
                #endregion

                #region Code
                DateTime dateNow = DateTime.Now;
                string dateNowCode = dateNow.ToString("yyyyMMdd");
                int numberLength = 4;
                var lastOrder = await _context.Orders.Where(e => e.Date.Day == dateNow.Day && e.Date.Month == dateNow.Month && e.Date.Year == dateNow.Year)
                    .OrderByDescending(e => e.CreatedAt).FirstOrDefaultAsync();
                int maxNumber = 0;
                if (lastOrder != null)
                {
                    var code = lastOrder.Code;
                    maxNumber = Convert.ToInt32(code.Substring(code.Length - numberLength, numberLength));
                }
                string number = $"0000{maxNumber + 1}";
                obj.Code = $"{_prefixCode}-{dateNowCode}{number.Substring(number.Length - numberLength, numberLength)}";
                #endregion

                obj.Date = DateTime.Now;

                obj.Tax = obj.Tax / 100;

                _context.Orders.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating the {_objName} item.");
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order != null)
                {
                    _context.OrderDetails.RemoveRange(order.OrderDetails);
                    _context.Orders.Remove(order);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    throw new Exception($"No {_objName} item found with the id {id}.");
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeletesAsync(List<Guid> ids)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var orders = await _context.Orders.Where(e => ids.Contains(e.Id)).ToListAsync();
                if (orders != null)
                {
                    foreach (var order in orders)
                    {
                        _context.OrderDetails.RemoveRange(order.OrderDetails);
                    }
                    _context.Orders.RemoveRange(orders);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    throw new Exception($"No {_objName} items found.");
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }   
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var objs = await _context.Orders.ToListAsync();
            if (objs == null)
            {
                throw new Exception($"No {_objName} items found.");
            }

            return objs;
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            var obj = await _context.Orders.FindAsync(id);
            if (obj == null)
            {
                throw new KeyNotFoundException($"No {_objName} item with Id {id} found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Guid id, Order obj)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                #region GET DATA
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    throw new Exception($"{_objName} item with id {id} not found.");
                }

                var diningTable = await _context.DiningTables.FindAsync(obj.DiningTableId);
                if (diningTable == null)
                {
                    _logger.LogError("Dining Table with Id {ObjDiningTableId} not found.", obj.DiningTableId);
                    throw new Exception("Dining Table not found.");
                }

                var orderStatus = await _context.OrderStatuses.FindAsync(obj.OrderStatusId);
                if (orderStatus == null)
                {
                    _logger.LogError("Order Status with Id {ObjOrderStatusId} not found.", obj.OrderStatusId);
                    throw new Exception("Order Status not found.");
                }

                var waiter = await _context.AppUsers.Where(e => e.Id == obj.WaiterId && e.IsActive).SingleOrDefaultAsync();
                if (waiter == null)
                {
                    _logger.LogError("Waiter with Id {ObjWaiterId} not found.", obj.WaiterId);
                    throw new Exception("Waiter not found.");
                }

                AppUser? chef = null;
                if (obj.ChefId != null)
                {
                    chef = await _context.AppUsers.Where(e => e.Id == obj.ChefId && e.IsActive).SingleOrDefaultAsync();
                    if (chef == null)
                    {
                        _logger.LogError("Chef with Id {ObjChefId} not found.", obj.ChefId);
                        throw new Exception("Chef not found.");
                    }
                }

                AppUser? cashier = null;
                if (obj.CashierId != null)
                {
                    cashier = await _context.AppUsers.Where(e => e.Id == obj.CashierId && e.IsActive).SingleOrDefaultAsync();
                    if (cashier == null)
                    {
                        _logger.LogError("Cashier with Id {ObjCashierId} not found.", obj.CashierId);
                        throw new Exception("Cashier not found.");
                    }
                }
                #endregion

                #region SET DATA
                order.DiningTable = diningTable;
                order.OrderStatus = orderStatus;
                order.Waiter = waiter;
                order.Chef = chef;
                order.Cashier = cashier;
                order.Date = obj.Date;
                order.TotalPrice = obj.TotalPrice;
                order.Tax = obj.Tax;
                order.BillAmount = obj.BillAmount;
                order.CashierNote = obj.CashierNote;
                order.CustomerNote = obj.CustomerNote;
                #endregion

                #region SET OrderDetails

                List<OrderDetail> orderDetailsToRemove = order.OrderDetails.Except(obj.OrderDetails).ToList();
                List<OrderDetail> orderDetailsToAdd = obj.OrderDetails.Except(order.OrderDetails).ToList();
                List<OrderDetail> orderDetailsToUpdate = order.OrderDetails.Intersect(obj.OrderDetails).ToList();

                foreach (var orderDetailToRemove in orderDetailsToRemove)
                {
                    var orderDetail = order.OrderDetails.FirstOrDefault(e => e.Id == orderDetailToRemove.Id);
                    if (orderDetail is not null)
                    {
                        order.OrderDetails.Remove(orderDetail);
                    }
                }

                foreach (var orderDetailToAdd in orderDetailsToAdd)
                {
                    if (!order.OrderDetails.Any(e => e.Id == orderDetailToAdd.Id))
                    {
                        order.OrderDetails.Add(orderDetailToAdd);
                    }
                }

                foreach (var orderDetailToUpdate in orderDetailsToUpdate)
                {
                    var orderDetail = order.OrderDetails.FirstOrDefault(e => e.Id == orderDetailToUpdate.Id);
                    if (orderDetail is not null)
                    {
                        var foodItem = await _context.FoodItems.FindAsync(orderDetailToUpdate.FoodItemId);
                        if (foodItem == null)
                        {
                            _logger.LogError("Food with Id {OrderDetailToUpdateFoodItemId} not found.", orderDetailToUpdate.FoodItemId);
                            throw new Exception("Food not found.");
                        }

                        orderDetail.FoodItem = foodItem;
                        orderDetail.Price = orderDetailToUpdate.Price;
                        orderDetail.Qty = orderDetailToUpdate.Qty;
                    }
                }

                #endregion

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, $"An error occurred while updating the {_objName} item with id {id}.");
                throw;
            }
        }

        public async Task UpdateAsync(Guid id, Order obj, List<OrderDetail> orderDetailsToAdd, List<OrderDetail> orderDetailsToRemove, List<OrderDetail> orderDetailsToUpdate)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                #region GET DATA
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    throw new Exception($"{_objName} item with id {id} not found.");
                }

                var diningTable = await _context.DiningTables.FindAsync(obj.DiningTableId);
                if (diningTable == null)
                {
                    _logger.LogError("Dining Table with Id {ObjDiningTableId} not found.", obj.DiningTableId);
                    throw new Exception("Dining Table not found.");
                }

                var orderStatus = await _context.OrderStatuses.FindAsync(obj.OrderStatusId);
                if (orderStatus == null)
                {
                    _logger.LogError("Order Status with Id {ObjOrderStatusId} not found.", obj.OrderStatusId);
                    throw new Exception("Order Status not found.");
                }

                var waiter = await _context.AppUsers.Where(e => e.Id == obj.WaiterId && e.IsActive).SingleOrDefaultAsync();
                if (waiter == null)
                {
                    _logger.LogError("Waiter with Id {ObjWaiterId} not found.", obj.WaiterId);
                    throw new Exception("Waiter not found.");
                }

                AppUser? chef = null;
                if (obj.ChefId != null)
                {
                    chef = await _context.AppUsers.Where(e => e.Id == obj.ChefId && e.IsActive).SingleOrDefaultAsync();
                    if (chef == null)
                    {
                        _logger.LogError("Chef with Id {ObjChefId} not found.", obj.ChefId);
                        throw new Exception("Chef not found.");
                    }
                }

                AppUser? cashier = null;
                if (obj.CashierId != null)
                {
                    cashier = await _context.AppUsers.Where(e => e.Id == obj.CashierId && e.IsActive).SingleOrDefaultAsync();
                    if (cashier == null)
                    {
                        _logger.LogError("Cashier with Id {ObjCashierId} not found.", obj.CashierId);
                        throw new Exception("Cashier not found.");
                    }
                }
                #endregion

                #region SET DATA
                order.DiningTable = diningTable;
                order.OrderStatus = orderStatus;
                order.Waiter = waiter;
                order.Chef = chef;
                order.Cashier = cashier;
                order.Date = obj.Date;
                order.TotalPrice = obj.TotalPrice;
                order.Tax = obj.Tax;
                order.BillAmount = obj.BillAmount;
                order.CashierNote = obj.CashierNote;
                order.CustomerNote = obj.CustomerNote;
                #endregion

                #region SET OrderDetails
                foreach (var orderDetailToRemove in orderDetailsToRemove)
                {
                    var orderDetail = order.OrderDetails.FirstOrDefault(e => e.Id == orderDetailToRemove.Id);
                    if (orderDetail is not null)
                    {
                        order.OrderDetails.Remove(orderDetail);
                    }
                }

                foreach (var orderDetailToAdd in orderDetailsToAdd)
                {
                    if (!order.OrderDetails.Any(e => e.Id == orderDetailToAdd.Id))
                    {
                        order.OrderDetails.Add(orderDetailToAdd);
                    }
                }

                foreach (var orderDetailToUpdate in orderDetailsToUpdate)
                {
                    var orderDetail = order.OrderDetails.FirstOrDefault(e => e.Id == orderDetailToUpdate.Id);
                    if (orderDetail is not null)
                    {
                        var foodItem = await _context.FoodItems.FindAsync(orderDetailToUpdate.FoodItemId);
                        if (foodItem == null)
                        {
                            _logger.LogError("Food with Id {OrderDetailToUpdateFoodItemId} not found.", orderDetailToUpdate.FoodItemId);
                            throw new Exception("Food not found.");
                        }

                        orderDetail.FoodItem = foodItem;
                        orderDetail.Price = orderDetailToUpdate.Price;
                        orderDetail.Qty = orderDetailToUpdate.Qty;
                    }
                }
                #endregion

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, $"An error occurred while updating the {_objName} item with id {id}.");
                throw;
            }
        }

        public async Task UpdateAsync(Guid id, OrderStatusCode orderStatusCode)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                #region GET DATA
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    throw new KeyNotFoundException($"{_objName} item with id {id} not found.");
                }

                var orderStatus = await _context.OrderStatuses.Where(e => e.Code == orderStatusCode.ToString()).SingleOrDefaultAsync();
                if (orderStatus == null)
                {
                    throw new KeyNotFoundException($"OrderStatusCode {orderStatusCode} not found.");
                }

                if (string.IsNullOrWhiteSpace(_appUserId)) throw new Exception("Current User Id not found.");
                var appUser = await _context.AppUsers.Where(e => e.Id == Guid.Parse(_appUserId!) && e.IsActive).SingleOrDefaultAsync();
                if (appUser == null) throw new KeyNotFoundException($"Current User with Id {_appUserId} not found.");
                #endregion

                #region FILTERING & SET DATA
                switch (orderStatusCode)
                {
                    case OrderStatusCode.Draft:
                        break;
                    case OrderStatusCode.Requested:
                        break;
                    case OrderStatusCode.Cooking:
                        if (order.OrderStatus.Code != OrderStatusCode.Requested.ToString())
                        {
                            throw new Exception($"Order Status is not {OrderStatusCode.Requested}.");
                        }
                        order.Chef = appUser;
                        break;
                    case OrderStatusCode.Ready:
                        if (order.OrderStatus.Code != OrderStatusCode.Cooking.ToString())
                        {
                            throw new Exception($"Order Status is not {OrderStatusCode.Cooking}.");
                        }
                        if (order.ChefId != appUser.Id)
                        {
                            throw new Exception("You dont have permission to finish cooking this order.");
                        }
                        break;
                    case OrderStatusCode.Delivered:
                        if (order.OrderStatus.Code != OrderStatusCode.Ready.ToString())
                        {
                            throw new Exception($"Order Status is not {OrderStatusCode.Ready}.");
                        }
                        order.Waiter = appUser;
                        break;
                    case OrderStatusCode.Billed:
                        if (order.OrderStatus.Code != OrderStatusCode.Delivered.ToString())
                        {
                            throw new Exception($"Order Status is not {OrderStatusCode.Delivered}.");
                        }
                        order.Cashier = appUser;
                        break;
                    case OrderStatusCode.Closed:
                        if (order.OrderStatus.Code != OrderStatusCode.Billed.ToString())
                        {
                            throw new Exception($"Order Status is not {OrderStatusCode.Billed}.");
                        }
                        break;
                    case OrderStatusCode.Canceled:
                        if (!(order.OrderStatus.Code == OrderStatusCode.Draft.ToString() || order.OrderStatus.Code == OrderStatusCode.Requested.ToString()))
                        {
                            throw new Exception($"Order Status is not {OrderStatusCode.Draft} or {OrderStatusCode.Requested}");
                        }
                        if (order.WaiterId != Guid.Parse(_appUserId)) throw new Exception("You dont have permission to cancel this order.");
                        break;
                }
                #endregion

                #region SET OrderStatus
                order.OrderStatus = orderStatus;
                #endregion

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, $"An error occurred while updating the {_objName} item with id {id}.");
                throw;
            }
        }
    }
}
