using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Icon;
using Skclusive.Material.Button;

namespace Skclusive.Material.Tab
{
    public static class TabExtension
    {
        public static void TryAddTabServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddIconServices(config);

            services.TryAddButtonServices(config);

            services.TryAddStyleTypeProvider<TabStyleProvider>();
        }
    }
}
