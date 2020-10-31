using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Transition.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Transition;
using Skclusive.Material.Theme;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Skclusive.Material.Transition
{
    public static class TransitionExtension
    {
        public static void TryAddMaterialTransitionServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddThemeServices(config);

            services.TryAddTransitionServices(config);

            services.TryAddTransient<SlideHelper>();

            services.TryAddStyleTypeProvider<TransitionStyleProvider>();

            services.TryAddScriptTypeProvider<TransitionScriptProvider>();
        }
    }
}
