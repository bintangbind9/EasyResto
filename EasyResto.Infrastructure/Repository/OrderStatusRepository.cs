using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyResto.Infrastructure.Repository
{
    public class OrderStatusRepository : IBaseRepository<OrderStatus>
    {
        private readonly string _objName = "Order Status";
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<OrderStatusRepository> _logger;

        public OrderStatusRepository(IDbContextFactory<EasyRestoDbContext> factory, ILogger<OrderStatusRepository> logger)
        {
            _context = factory.CreateDbContext();
            _logger = logger;
        }

        public async Task CreateAsync(OrderStatus obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeletesAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderStatus>> GetAllAsync()
        {
            var objs = await _context.OrderStatuses.ToListAsync();
            if (objs == null)
            {
                throw new Exception($"No {_objName} items found.");
            }

            return objs;
        }

        public Task<OrderStatus> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, OrderStatus obj)
        {
            throw new NotImplementedException();
        }
    }
}
