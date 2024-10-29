using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyResto.Infrastructure.Repository
{
    public class DiningTableRepository : IBaseRepository<DiningTable>
    {
        private readonly string _objName = "Dining Table";
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<DiningTableRepository> _logger;

        public DiningTableRepository(IDbContextFactory<EasyRestoDbContext> factory, ILogger<DiningTableRepository> logger)
        {
            _context = factory.CreateDbContext();
            _logger = logger;
        }
        public async Task CreateAsync(DiningTable obj)
        {
            try
            {
                _context.DiningTables.Add(obj);
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
            var obj = await _context.DiningTables.FindAsync(id);
            if (obj != null)
            {
                _context.DiningTables.Remove(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No {_objName} item found with the id {id}.");
            }
        }

        public async Task DeletesAsync(List<Guid> ids)
        {
            var objs = await _context.DiningTables.Where(e => ids.Contains(e.Id)).ToListAsync();
            if (objs != null)
            {
                _context.DiningTables.RemoveRange(objs);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No {_objName} items found.");
            }
        }

        public async Task<IEnumerable<DiningTable>> GetAllAsync()
        {
            var objs = await _context.DiningTables.ToListAsync();
            if (objs == null)
            {
                throw new Exception($"No {_objName} items found.");
            }

            return objs;
        }

        public async Task<DiningTable> GetByIdAsync(Guid id)
        {
            var obj = await _context.DiningTables.FindAsync(id);
            if (obj == null)
            {
                throw new KeyNotFoundException($"No {_objName} item with Id {id} found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Guid id, DiningTable obj)
        {
            try
            {
                var diningTable = await _context.DiningTables.FindAsync(id);
                if (diningTable == null)
                {
                    throw new Exception($"{_objName} item with id {id} not found.");
                }

                diningTable.Name = obj.Name;
                diningTable.Capacity = obj.Capacity;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the {_objName} item with id {id}.");
                throw;
            }
        }
    }
}
