using CaspianTeam.Framework.NetCore.Frameworks.MemoryCache;
using CaspianTeam.Framework.NetCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CaspianTeam.Framework.NetCore.Infrastructures
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonServiceCollection(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryCacheManager, MemoryCacheManager>();
            services.AddTransient<IUtilityService, UtilityService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IImageService, ImageService>();

            return services;
        }
    }
}
