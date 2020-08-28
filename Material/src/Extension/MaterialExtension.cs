using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Script;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Component
{
    public static class MaterialExtension
    {
        public static void TryAddMaterialServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddMaterialScriptServices(config);
            services.TryAddMaterialThemeServices(config);
            services.AddSingleton<IStyleTypeProvider, MaterialStyleProvider>();
        }
    }
}
