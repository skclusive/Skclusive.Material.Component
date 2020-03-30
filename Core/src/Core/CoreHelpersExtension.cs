using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DomHelpers;
using Skclusive.Core.Component;

namespace Skclusive.Material.Core
{
    public static class CoreHelpersExtension
    {
        public static void TryAddMaterialCoreServices(this IServiceCollection services, ICoreConfig config)
        {
            services.TryAddDomHelpersServices(config);
        }
    }
}
