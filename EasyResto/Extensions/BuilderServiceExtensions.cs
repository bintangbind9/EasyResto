﻿using EasyResto.Application.Repository;
using EasyResto.Domain.Common;
using EasyResto.Domain.Entities;
using EasyResto.Helpers;
using EasyResto.Infrastructure.Context;
using EasyResto.Infrastructure.Repository;

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
            services.AddTransient<EasyRestoDbContext>();
            services.AddTransient<IBaseRepository<FoodCategory>, FoodCategoryRepository>();

            return services;
        }
    }
}