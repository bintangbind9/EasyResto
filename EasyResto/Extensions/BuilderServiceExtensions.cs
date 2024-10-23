using EasyResto.Application.Repository;
using EasyResto.Application.Service;
using EasyResto.Domain.Common;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using EasyResto.Infrastructure.Repository;
using EasyResto.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

namespace EasyResto.Extensions
{
    public static class BuilderServiceExtensions
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<DbSettings>(configuration.GetSection("DbSettings"));

            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddDbContextFactory<EasyRestoDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(configuration["DbSettings:ConnectionString"]);
            });
            services.AddTransient<IBaseRepository<AppUser>, AppUserRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IBaseRepository<FoodCategory>, FoodCategoryRepository>();

            return services;
        }
    }
}
