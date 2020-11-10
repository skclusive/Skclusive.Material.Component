using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Form;

namespace Skclusive.Material.Input
{
    public static class InputExtension
    {
        public static void TryAddInputServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddFormServices(config);

            services.TryAddStyleTypeProvider<InputStyleProvider>();
        }
    }
}
