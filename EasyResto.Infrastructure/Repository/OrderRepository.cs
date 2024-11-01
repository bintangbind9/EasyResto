using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
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
                if (string.IsNullOrWhiteSpace(_appUserId)) throw new Exception("Current User Id not found.");
                var waiter = await _context.AppUsers.FindAsync(Guid.Parse(_appUserId!));
                if (waiter == null) throw new Exception($"Waiter with Id {_appUserId} not found.");
                obj.Waiter = waiter;

                DateTime dateNow = DateTime.Now;
                string dateNowCode = dateNow.ToString("yyyyMMdd");
                int countOrder = await _context.Orders.CountAsync(e => e.Date.Day == dateNow.Day && e.Date.Month == dateNow.Month && e.Date.Year == dateNow.Year);
                string number = $"0000{countOrder + 1}";
                obj.Code = $"{_prefixCode}-{dateNowCode}{number.Substring(number.Length - 4, 4)}";
                
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
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No {_objName} item found with the id {id}.");
            }
        }

        public async Task DeletesAsync(List<Guid> ids)
        {
            var orders = await _context.Orders.Where(e => ids.Contains(e.Id)).ToListAsync();
            if (orders != null)
            {
                _context.Orders.RemoveRange(orders);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No {_objName} items found.");
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
    }
}
