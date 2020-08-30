using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Typography;

namespace Skclusive.Material.Link
{
    public static class LinkExtension
    {
        public static void TryAddLinkServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddTypographyServices(config);

            services.TryAddStyleTypeProvider<LinkStyleProvider>();
        }
    }
}
