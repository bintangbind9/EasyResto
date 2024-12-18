﻿using EasyResto.Application.Repository;
using EasyResto.Application.Service;
using EasyResto.Domain.Common;
using EasyResto.Domain.Entities;
using EasyResto.Infrastructure.Context;
using EasyResto.Infrastructure.Repository;
using EasyResto.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EasyResto.Extensions
{
    public static class BuilderServiceExtensions
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddHttpContextAccessor();
            services.Configure<DbSettings>(configuration.GetSection("DbSettings"));

            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddDbContextFactory<EasyRestoDbContext>((provider, options) =>
            {
                var dbSettings = provider.GetRequiredService<IOptions<DbSettings>>().Value;
                options.UseLazyLoadingProxies().UseSqlServer(dbSettings?.ConnectionString);
            });
            services.AddTransient<IBaseRepository<AppUser>, AppUserRepository>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IBaseRepository<FoodCategory>, FoodCategoryRepository>();
            services.AddTransient<IBaseRepository<DiningTable>, DiningTableRepository>();
            services.AddTransient<IBaseRepository<Role>, RoleRepository>();
            services.AddTransient<IBaseRepository<Privilege>, PrivilegeRepository>();
            services.AddTransient<IBaseRepository<FoodItem>, FoodItemRepository>();
            services.AddTransient<IBaseRepository<FoodItemStatus>, FoodItemStatusRepository>();
            services.AddTransient<IBaseRepository<Order>, OrderRepository>();
            services.AddTransient<IBaseRepository<OrderStatus>, OrderStatusRepository>();

            return services;
        }
    }
}
