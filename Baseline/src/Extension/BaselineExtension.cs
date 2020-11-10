using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Baseline
{
    public static class BaselineExtension
    {
        public static void TryAddBaselineServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddThemeServices(config);

            services.TryAddStyleTypeProvider<BaselineStyleProvider>();
        }
    }
}
