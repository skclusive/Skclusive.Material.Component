using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Script
{
    public static class ScriptExtension
    {
        public static void TryAddMaterialScriptServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddMaterialCoreServices(config);

            services.TryAddDomHelpersServices(config);

            services.TryAddTransient<ScriptHelpers>();

            services.TryAddTransient<EventDelegator>();

            services.TryAddTransient<MediaQueryMatcher>();

            services.TryAddTransient<DetectThemeHelper>();

            services.TryAddTransient<HistoryBackHelper>();

            services.TryAddScriptTypeProvider<MaterialScriptProvider>();
        }
    }
}
