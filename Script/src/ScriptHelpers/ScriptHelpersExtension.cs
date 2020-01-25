using Microsoft.Extensions.DependencyInjection;

namespace Skclusive.Material.Script
{
    public static class ScriptHelpersExtension
    {
        public static void AddScriptHelpers(this IServiceCollection services)
        {
            services.AddScoped<ScriptHelpers>();

            services.AddScoped<EventDelegator>();

            services.AddScoped<TrapFocusHelper>();

            services.AddScoped<MediaQueryMatcher>();

            services.AddScoped<DetectThemeHelper>();

            services.AddScoped<MenuListHelper>();

            services.AddScoped<HistoryBackHelper>();

            services.AddScoped<PopoverHelper>();

            services.AddScoped<SlideHelper>();

            services.AddScoped<RadioGroupHelper>();
        }
    }
}
