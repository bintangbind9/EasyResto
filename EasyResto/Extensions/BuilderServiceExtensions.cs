using EasyResto.Application.Repository;
using EasyResto.Domain.Common;
using EasyResto.Domain.Entities;
using EasyResto.Helpers;
using EasyResto.Infrastructure.Context;
using EasyResto.Infrastructure.Repository;
using EasyResto.Infrastructure.Service;

namespace EasyResto.Extensions
{
    public static class BuilderServiceExtensions
    {
        public static IServiceCollection AddAppConfigurer(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<DbSettings>(configuration.GetSection("DbSettings"));

            return services;
        }

        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddSingleton<AuthHelpers>();
            services.AddSingleton<PasswordService>();
            services.AddTransient<EasyRestoDbContext>();
            services.AddTransient<IBaseRepository<AppUser>, AppUserRepository>();
            services.AddTransient<IBaseRepository<FoodCategory>, FoodCategoryRepository>();

            return services;
        }
    }
}
