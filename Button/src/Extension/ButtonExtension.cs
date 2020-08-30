using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;
using Skclusive.Material.Transition;

namespace Skclusive.Material.Button
{
    public static class ButtonExtension
    {
        public static void TryAddButtonServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddMaterialTransitionServices(config);

            services.TryAddStyleTypeProvider<ButtonStyleProvider>();

            services.TryAddStyleProducer<ButtonStyleProducer>();
        }
    }
}
