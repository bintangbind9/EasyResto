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

        public async Task DeletesAsync(List<Guid> ids)
        {
            var appUsers = await _context.AppUsers.Where(e => ids.Contains(e.Id)).ToListAsync();
            if (appUsers != null)
            {
                _context.AppUsers.RemoveRange(appUsers);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"No {_objName} items found.");
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

        public Task UpdateAsync(Guid id, AppUser obj)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, AppUser obj, List<Guid> roleIdsToAdd, List<Guid> roleIdsToRemove)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var appUser = await _context.AppUsers.FindAsync(id);
                if (appUser == null)
                {
                    throw new Exception($"{_objName} item with id {id} not found.");
                }

                if (obj.Name != null) appUser.Name = obj.Name;
                if (!string.IsNullOrWhiteSpace(obj.Password))
                {
                    if (obj.Password.Trim().Length < 5) throw new Exception("Password must be at least 5 characters long.");
                    appUser.Password = _passwordService.HashPassword(obj.Password);
                }
                appUser.IsActive = obj.IsActive;

                foreach (var roleId in roleIdsToRemove)
                {
                    var appUserRole = appUser.AppUserRoles.FirstOrDefault(e => e.RoleId == roleId);
                    if (appUserRole is not null)
                    {
                        _context.AppUserRoles.Remove(appUserRole);
                    }
                }

                foreach (var roleId in roleIdsToAdd)
                {
                    var role = await _context.Roles.FindAsync(roleId);
                    if (role is null)
                    {
                        throw new Exception($"Role with ID {roleId} not found.");
                    }

                    if (!appUser.AppUserRoles.Any(e => e.RoleId == roleId))
                    {
                        var appUserRole = new AppUserRole
                        {
                            AppUserId = id,
                            RoleId = roleId
                        };

                        _context.AppUserRoles.Add(appUserRole);
                    }
                }

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

        public async Task<AppUser?> Get(string username, bool isActive = true)
        {
            var obj = await _context.AppUsers.Where(e => e.Username == username && e.IsActive == isActive).SingleOrDefaultAsync();
            return obj;
        }
    }
}
