using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Theme
{
    public static class ThemeExtensions
    {
        public static void TryAddThemeServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddMaterialCoreServices(config);

            services.TryAddScoped<IThemeProducer, ThemeProducer>();
        }

        public static void TryAddStyleProducer<TStyleProducer>(this IServiceCollection services) where TStyleProducer : class, IStyleProducer
        {
            services.TryAddScopedEnumerable<IStyleProducer, TStyleProducer>();
        }
    }
}
