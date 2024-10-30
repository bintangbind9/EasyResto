using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyResto.Infrastructure.Repository
{
    public class FoodItemStatusRepository : IBaseRepository<FoodItemStatus>
    {
        private readonly string _objName = "Food Item Status";
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<FoodItemStatusRepository> _logger;

        public FoodItemStatusRepository(IDbContextFactory<EasyRestoDbContext> factory, ILogger<FoodItemStatusRepository> logger)
        {
            _context = factory.CreateDbContext();
            _logger = logger;
        }

        public Task CreateAsync(FoodItemStatus obj)
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

        public async Task<IEnumerable<FoodItemStatus>> GetAllAsync()
        {
            var objs = await _context.FoodItemStatuses.ToListAsync();
            if (objs == null)
            {
                throw new Exception($"No {_objName} items found.");
            }

            return objs;
        }

        public Task<FoodItemStatus> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, FoodItemStatus obj)
        {
            throw new NotImplementedException();
        }
    }
}
