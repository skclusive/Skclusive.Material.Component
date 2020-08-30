using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Paper;
using Skclusive.Material.Button;
using Skclusive.Material.Avatar;
using Skclusive.Material.Typography;

namespace Skclusive.Material.Card
{
    public static class CardExtension
    {
        public static void TryAddCardServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddPaperServices(config);

            services.TryAddAvatarServices(config);

            services.TryAddTypographyServices(config);

            services.TryAddButtonServices(config);

            services.TryAddStyleTypeProvider<CardStyleProvider>();
        }
    }
}
