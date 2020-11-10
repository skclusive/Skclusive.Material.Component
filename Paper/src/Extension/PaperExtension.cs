using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Paper
{
    public static class PaperExtension
    {
        public static void TryAddPaperServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddThemeServices(config);

            services.TryAddStyleTypeProvider<PaperStyleProvider>();
        }
    }
}
