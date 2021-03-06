﻿using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Responsive
{
    public static class ResponsiveExtension
    {
        public static void TryAddResponsiveServices(this IServiceCollection services, IMaterialConfig config)
        {
            services.TryAddThemeServices(config);
        }
    }
}
