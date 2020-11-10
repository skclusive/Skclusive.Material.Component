using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Container
{
    public static class ContainerExtension
    {
        public static void TryAddContainerServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddThemeServices(config);

            services.TryAddStyleTypeProvider<ContainerStyleProvider>();
        }
    }
}
