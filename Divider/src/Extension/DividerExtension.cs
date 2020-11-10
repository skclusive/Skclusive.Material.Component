using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Divider
{
    public static class DividerExtension
    {
        public static void TryAddDividerServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddThemeServices(config);

            services.TryAddStyleTypeProvider<DividerStyleProvider>();

            services.TryAddStyleProducer<DividerStyleProducer>();
        }
    }
}
