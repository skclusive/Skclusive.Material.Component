using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Core
{
    public static class CoreHelpersExtension
    {
        public static void TryAddMaterialCoreServices(this IServiceCollection services)
        {
            services.TryAddDomHelpersServices();
        }
    }
}
