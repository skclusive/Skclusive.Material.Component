using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Typography;

namespace Skclusive.Material.Form
{
    public static class FormExtension
    {
        public static void TryAddFormServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddTypographyServices(config);

            services.TryAddStyleTypeProvider<FormStyleProvider>();
        }
    }
}
