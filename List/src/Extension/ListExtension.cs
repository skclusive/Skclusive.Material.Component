using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Button;
using Skclusive.Material.Typography;

namespace Skclusive.Material.List
{
    public static class ListExtension
    {
        public static void TryAddListServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddTypographyServices(config);

            services.TryAddButtonServices(config);

            services.TryAddStyleTypeProvider<ListStyleProvider>();
        }
    }
}
