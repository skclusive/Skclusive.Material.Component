using Microsoft.Extensions.DependencyInjection;

namespace Skclusive.Material.Script
{
    public static class ScriptHelpersExtension
    {
        public static void AddScriptHelpers(this IServiceCollection services)
        {
            services.AddScoped<ScriptHelpers>();

            services.AddTransient<EventDelegator>();

            services.AddTransient<TrapFocusHelper>();

            services.AddTransient<MediaQueryMatcher>();

            services.AddTransient<DetectThemeHelper>();

            services.AddTransient<MenuListHelper>();

            services.AddTransient<HistoryBackHelper>();

            services.AddTransient<PopoverHelper>();

            services.AddTransient<SlideHelper>();
        }
    }
}
