using EasyResto.Helpers;

namespace EasyResto.Extensions
{
    public static class BuilderServiceExtensions
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddSingleton<AuthHelpers, AuthHelpers>();

            return services;
        }
    }
}
