using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Material.Core;

namespace Skclusive.Material.Script
{
    public static class ScriptHelpersExtension
    {
        public static void TryAddMaterialScriptServices(this IServiceCollection services)
        {
            services.TryAddMaterialCoreServices();

            services.TryAddScoped<ScriptHelpers>();

            services.TryAddScoped<EventDelegator>();

            services.TryAddScoped<TrapFocusHelper>();

            services.TryAddScoped<MediaQueryMatcher>();

            services.TryAddScoped<DetectThemeHelper>();

            services.TryAddScoped<MenuListHelper>();

            services.TryAddScoped<HistoryBackHelper>();

            services.TryAddScoped<PopoverHelper>();

            services.TryAddScoped<SlideHelper>();

            services.TryAddScoped<RadioGroupHelper>();
        }
    }
}
