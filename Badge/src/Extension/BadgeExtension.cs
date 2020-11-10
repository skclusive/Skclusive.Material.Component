using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Badge
{
    public static class BadgeExtension
    {
        public static void TryAddBadgeServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddThemeServices(config);

            services.TryAddStyleTypeProvider<BadgeStyleProvider>();
        }
    }
}
