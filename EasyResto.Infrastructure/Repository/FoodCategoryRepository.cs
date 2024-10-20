using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyResto.Infrastructure.Repository
{
    public class FoodCategoryRepository : IBaseRepository<FoodCategory>
    {
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<FoodCategoryRepository> _logger;

        public FoodCategoryRepository(EasyRestoDbContext context, ILogger<FoodCategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateAsync(FoodCategory obj)
        {
            try
            {
                obj.CreatedAt = DateTime.Now;
                _context.FoodCategories.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Food Category item.");
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var foodCategory = await _context.FoodCategories.FindAsync(id);
            if (foodCategory != null)
            {
                _context.FoodCategories.Remove(foodCategory);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No Food Category item found with the id {id}.");
            }
        }

        public async Task<IEnumerable<FoodCategory>> GetAllAsync()
        {
            var objs = await _context.FoodCategories.ToListAsync();
            if (objs == null)
            {
                throw new Exception("No Food Category items found.");
            }

            return objs;
        }

        public async Task<FoodCategory>GetByIdAsync(Guid id)
        {
            var obj = await _context.FoodCategories.FindAsync(id);
            if (obj == null)
            {
                throw new KeyNotFoundException($"No Food Category item with Id {id} found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Guid id, FoodCategory obj)
        {
            try
            {
                var foodCategory = await _context.FoodCategories.FindAsync(id);
                if (foodCategory == null)
                {
                    throw new Exception($"Food Category item with id {id} not found.");
                }

                if (obj.Name != null)
                {
                    foodCategory.Name = obj.Name;
                }

                foodCategory.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the food category item with id {id}.");
                throw;
            }
        }
    }
}
