using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Script
{
    public static class ScriptHelpersExtension
    {
        public static void TryAddMaterialScriptServices(this IServiceCollection services, ICoreConfig config)
        {
            services.TryAddMaterialCoreServices(config);

            services.TryAddTransient<ScriptHelpers>();

            services.TryAddTransient<EventDelegator>();

            services.TryAddTransient<TrapFocusHelper>();

            services.TryAddTransient<MediaQueryMatcher>();

            services.TryAddTransient<DetectThemeHelper>();

            services.TryAddTransient<MenuListHelper>();

            services.TryAddTransient<HistoryBackHelper>();

            services.TryAddTransient<PopoverHelper>();

            services.TryAddTransient<SlideHelper>();

            services.TryAddTransient<RadioGroupHelper>();
        }
    }
}
