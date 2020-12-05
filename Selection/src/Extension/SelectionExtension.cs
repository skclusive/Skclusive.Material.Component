using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Icon;
using Skclusive.Material.Button;
using Skclusive.Material.Form;
using Skclusive.Material.Theme;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Skclusive.Material.Selection
{
    public static class SelectionExtension
    {
        public static void TryAddSelectionServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddIconServices(config);

            services.TryAddButtonServices(config);

            services.TryAddFormServices(config);

            services.TryAddTransient<RadioGroupHelper>();

            services.TryAddStyleTypeProvider<SelectionStyleProvider>();

            services.TryAddScriptTypeProvider<SelectionScriptProvider>();

            services.TryAddStyleProducer<SelectionStyleProducer>();
        }
    }
}
