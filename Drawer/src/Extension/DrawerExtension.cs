using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;
using Skclusive.Material.Paper;

namespace Skclusive.Material.Drawer
{
    public static class DrawerExtension
    {
        public static void TryAddDrawerServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddPaperServices(config);

            services.TryAddModalServices(config);

            services.TryAddStyleTypeProvider<DrawerStyleProvider>();
        }
    }
}
