using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyResto.Infrastructure.Repository
{
    public class FoodItemRepository : IBaseRepository<FoodItem>
    {
        private readonly string _objName = "Food";
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<FoodItemRepository> _logger;

        public FoodItemRepository(IDbContextFactory<EasyRestoDbContext> factory, ILogger<FoodItemRepository> logger)
        {
            _context = factory.CreateDbContext();
            _logger = logger;
        }

        public async Task CreateAsync(FoodItem obj)
        {
            try
            {
                _context.FoodItems.Add(obj);
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
            var obj = await _context.FoodItems.FindAsync(id);
            if (obj != null)
            {
                _context.FoodItems.Remove(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No {_objName} item found with the id {id}.");
            }
        }

        public async Task DeletesAsync(List<Guid> ids)
        {
            var objs = await _context.FoodItems.Where(e => ids.Contains(e.Id)).ToListAsync();
            if (objs != null)
            {
                _context.FoodItems.RemoveRange(objs);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No {_objName} items found.");
            }
        }

        public async Task<IEnumerable<FoodItem>> GetAllAsync()
        {
            var objs = await _context.FoodItems.ToListAsync();
            if (objs == null)
            {
                throw new Exception($"No {_objName} items found.");
            }

            return objs;
        }

        public async Task<FoodItem> GetByIdAsync(Guid id)
        {
            var obj = await _context.FoodItems.FindAsync(id);
            if (obj == null)
            {
                throw new KeyNotFoundException($"No {_objName} item with Id {id} found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Guid id, FoodItem obj)
        {
            try
            {
                var foodItem = await _context.FoodItems.FindAsync(id);
                if (foodItem == null)
                {
                    throw new Exception($"{_objName} item with id {id} not found.");
                }

                var foodCategory = await _context.FoodCategories.FindAsync(obj.FoodCategoryId);
                if (foodCategory == null)
                {
                    throw new Exception($"Food Category item with id {obj.FoodCategoryId} not found.");
                }

                var foodItemStatus = await _context.FoodItemStatuses.FindAsync(obj.FoodItemStatusId);
                if (foodItemStatus == null)
                {
                    throw new Exception($"Food Item Status with id {obj.FoodItemStatusId} not found.");
                }

                foodItem.FoodCategory = foodCategory;
                foodItem.FoodItemStatus = foodItemStatus;
                foodItem.Name = obj.Name;
                foodItem.Price = obj.Price;

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
