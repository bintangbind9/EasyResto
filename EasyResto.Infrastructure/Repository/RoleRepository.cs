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

        public Task<Role> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Role obj)
        {
            throw new NotImplementedException();
        }
    }
}
