using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Paper;

namespace Skclusive.Material.AppBar
{
    public static class AppBarExtension
    {
        public static void TryAddAppBarServices(this IServiceCollection services, IMaterialConfig config)
        {
            // Theme service would be added by Paper
            services.TryAddPaperServices(config);

            services.TryAddStyleTypeProvider<AppBarStyleProvider>();
        }
    }
}
