using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;

namespace Skclusive.Material.Core
{
    public static class CoreExtensions
    {
        public static void TryAddMaterialCoreServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddCoreServices(config);
        }
    }
}
