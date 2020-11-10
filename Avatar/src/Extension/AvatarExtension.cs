using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Avatar
{
    public static class AvatarExtension
    {
        public static void TryAddAvatarServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddThemeServices(config);

            services.TryAddStyleTypeProvider<AvatarStyleProvider>();

            services.TryAddStyleProducer<AvatarStyleProducer>();
        }
    }
}
