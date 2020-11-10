using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Icon;
using Skclusive.Material.Button;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Table
{
    public static class TableExtension
    {
        public static void TryAddTableServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddIconServices(config);

            services.TryAddButtonServices(config);

            services.TryAddStyleTypeProvider<TableStyleProvider>();

            services.TryAddStyleProducer<TableStyleProducer>();
        }
    }
}
