using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;
using Skclusive.Material.Paper;

namespace Skclusive.Material.Popover
{
    public static class PopoverExtension
    {
        public static void TryAddPopoverServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddPaperServices(config);

            services.TryAddModalServices(config);

            services.TryAddTransient<PopoverHelper>();

            services.TryAddStyleTypeProvider<PopoverStyleProvider>();

            services.TryAddScriptTypeProvider<PopoverScriptProvider>();
        }
    }
}
