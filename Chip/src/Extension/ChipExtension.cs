using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;
using Skclusive.Material.Avatar;
using Skclusive.Material.Icon;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Chip
{
    public static class ChipExtension
    {
        public static void TryAddChipServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddDomHelpersServices(config);

            services.TryAddAvatarServices(config);

            services.TryAddIconServices(config);

            services.TryAddStyleTypeProvider<ChipStyleProvider>();

            services.TryAddStyleProducer<ChipStyleProducer>();
        }
    }
}
