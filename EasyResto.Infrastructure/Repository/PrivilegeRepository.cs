using EasyResto.Application.Repository;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyResto.Infrastructure.Repository
{
    public class PrivilegeRepository : IBaseRepository<Privilege>
    {
        private readonly string _objName = "Privilege";
        private readonly EasyRestoDbContext _context;
        private readonly ILogger<PrivilegeRepository> _logger;

        public PrivilegeRepository(IDbContextFactory<EasyRestoDbContext> factory, ILogger<PrivilegeRepository> logger)
        {
            _context = factory.CreateDbContext();
            _logger = logger;
        }

        public Task CreateAsync(Privilege obj)
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

        public async Task<IEnumerable<Privilege>> GetAllAsync()
        {
            var objs = await _context.Privileges.ToListAsync();
            if (objs == null)
            {
                throw new Exception($"No {_objName} items found.");
            }

            return objs;
        }

        public Task<Privilege> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Privilege obj)
        {
            throw new NotImplementedException();
        }
    }
}
