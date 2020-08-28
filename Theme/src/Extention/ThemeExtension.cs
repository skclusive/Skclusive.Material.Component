using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Theme
{
    public static class ThemeExtension
    {
        public static void TryAddMaterialThemeServices(this IServiceCollection services, ICoreConfig config)
        {
            services.TryAddMaterialCoreServices(config);

            services.TryAddScoped<IThemeProducer, ThemeProducer>();
        }
    }
}
