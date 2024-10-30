using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyResto.Infrastructure.Repository
{
    public class RoleRepository : IBaseRepository<Role>
    {
        private readonly string _objName = "Role";
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<RoleRepository> _logger;

        public RoleRepository(IDbContextFactory<EasyRestoDbContext> factory, ILogger<RoleRepository> logger)
        {
            _context = factory.CreateDbContext();
            _logger = logger;
        }

        public Task CreateAsync(Role obj)
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

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var objs = await _context.Roles.ToListAsync();
            if (objs == null)
            {
                throw new Exception($"No {_objName} items found.");
            }

            return objs;
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            var obj = await _context.Roles.FindAsync(id);
            if (obj == null)
            {
                throw new KeyNotFoundException($"No {_objName} item with Id {id} found.");
            }

            return obj;
        }

        public Task UpdateAsync(Guid id, Role obj)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, Role obj, List<Guid> privilegeIdsToAdd, List<Guid> privilegeIdsToRemove)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var role = await _context.Roles.FindAsync(id);
                if (role == null)
                {
                    throw new Exception($"{_objName} item with id {id} not found.");
                }

                role.Name = obj.Name;

                foreach (var privilegeId in privilegeIdsToRemove)
                {
                    var rolePrivilege = role.RolePrivileges.FirstOrDefault(e => e.PrivilegeId == privilegeId);
                    if (rolePrivilege is not null)
                    {
                        _context.RolePrivileges.Remove(rolePrivilege);
                    }
                }

                foreach (var privilegeId in privilegeIdsToAdd)
                {
                    var privilege = await _context.Privileges.FindAsync(privilegeId);
                    if (privilege is null)
                    {
                        throw new Exception($"Privilege with ID {privilegeId} not found.");
                    }

                    if (!role.RolePrivileges.Any(e => e.PrivilegeId == privilegeId))
                    {
                        var rolePrivilege = new RolePrivilege
                        {
                            RoleId = id,
                            PrivilegeId = privilegeId
                        };

                        _context.RolePrivileges.Add(rolePrivilege);
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
    }
}
