using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Script;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Component
{
    public static class MaterialExtension
    {
        public static void AddMaterialUI(this IServiceCollection services)
        {
            services.AddDomHelpers();

            services.AddScriptHelpers();
        }
    }
}
