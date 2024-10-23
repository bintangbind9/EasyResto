using EasyResto.Application.Repository;
using EasyResto.Application.Service;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyResto.Infrastructure.Repository
{
    public class AppUserRepository : IBaseRepository<AppUser>
    {
        private readonly string _objName = "AppUser";
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<AppUserRepository> _logger;
        private readonly IPasswordService _passwordService;

        public AppUserRepository(IDbContextFactory<EasyRestoDbContext> factory, ILogger<AppUserRepository> logger, IPasswordService passwordService)
        {
            _context = factory.CreateDbContext();
            _logger = logger;
            _passwordService = passwordService;
        }

        public async Task CreateAsync(AppUser obj)
        {
            try
            {
                obj.Username = obj.Username.Trim();
                obj.Password = _passwordService.HashPassword(obj.Password);
                obj.IsActive = true;
                obj.CreatedAt = DateTime.Now;
                _context.AppUsers.Add(obj);
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
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser != null)
            {
                _context.AppUsers.Remove(appUser);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No {_objName} item found with the id {id}.");
            }
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            var objs = await _context.AppUsers.ToListAsync();
            if (objs == null)
            {
                throw new Exception($"No {_objName} items found.");
            }

            return objs;
        }

        public async Task<AppUser> GetByIdAsync(Guid id)
        {
            var obj = await _context.AppUsers.FindAsync(id);
            if (obj == null)
            {
                throw new KeyNotFoundException($"No {_objName} item with Id {id} found.");
            }

            return obj;
        }

        public async Task UpdateAsync(Guid id, AppUser obj)
        {
            try
            {
                var appUser = await _context.AppUsers.FindAsync(id);
                if (appUser == null)
                {
                    throw new Exception($"{_objName} item with id {id} not found.");
                }

                if (obj.Name != null) appUser.Name = obj.Name;
                if (obj.Password != null) appUser.Password = _passwordService.HashPassword(obj.Password);
                appUser.IsActive = obj.IsActive;

                appUser.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the {_objName} item with id {id}.");
                throw;
            }
        }

        public async Task<AppUser?> Get(string username, bool isActive = true)
        {
            var obj = await _context.AppUsers.Where(e => e.Username == username && e.IsActive == isActive).SingleOrDefaultAsync();
            return obj;
        }
    }
}
