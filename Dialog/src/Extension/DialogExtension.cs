using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;
using Skclusive.Material.Paper;
using Skclusive.Material.Typography;

namespace Skclusive.Material.Dialog
{
    public static class DialogExtension
    {
        public static void TryAddDialogServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddPaperServices(config);

            services.TryAddTypographyServices(config);

            services.TryAddModalServices(config);

            services.TryAddStyleTypeProvider<DialogStyleProvider>();
        }
    }
}
