using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Chip;
using Skclusive.Material.Divider;
using Skclusive.Material.Card;
using Skclusive.Material.Responsive;
using Skclusive.Material.Baseline;
using Skclusive.Material.Container;
using Skclusive.Material.Grid;
using Skclusive.Material.Hidden;
using Skclusive.Material.Badge;
using Skclusive.Material.Selection;
using Skclusive.Material.Tab;
using Skclusive.Material.Table;
using Skclusive.Material.Toolbar;
using Skclusive.Material.Link;
using Skclusive.Material.Dialog;
using Skclusive.Material.Drawer;
using Skclusive.Material.Menu;
using Skclusive.Material.Text;
using Skclusive.Material.Progress;
using Skclusive.Material.AppBar;

namespace Skclusive.Material.Component
{
    public static class MaterialExtension
    {
        public static void TryAddMaterialServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddBaselineServices(config);
            services.TryAddResponsiveServices(config);
            services.TryAddContainerServices(config);
            services.TryAddGridServices(config);
            services.TryAddDividerServices(config);
            services.TryAddBadgeServices(config);
            services.TryAddToolbarServices(config);
            services.TryAddProgressServices(config);

            services.TryAddChipServices(config);
            services.TryAddCardServices(config);
            services.TryAddSelectionServices(config);
            services.TryAddTabServices(config);
            services.TryAddTableServices(config);
            services.TryAddLinkServices(config);
            services.TryAddDialogServices(config);
            services.TryAddDrawerServices(config);
            services.TryAddMenuServices(config);
            services.TryAddTextServices(config);
            services.TryAddAppBarServices(config);

            services.TryAddHiddenServices(config);
        }
    }
}
