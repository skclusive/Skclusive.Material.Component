using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.List;
using Skclusive.Material.Popover;

namespace Skclusive.Material.Menu
{
    public static class MenuExtension
    {
        public static void TryAddMenuServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddListServices(config);

            services.TryAddPopoverServices(config);

            services.TryAddTransient<MenuListHelper>();

            services.TryAddStyleTypeProvider<MenuStyleProvider>();

            services.TryAddScriptTypeProvider<MenuScriptProvider>();
        }
    }
}
