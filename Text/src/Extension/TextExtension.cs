using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Input;

namespace Skclusive.Material.Text
{
    public static class TextExtension
    {
        public static void TryAddTextServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddInputServices(config);
        }
    }
}
