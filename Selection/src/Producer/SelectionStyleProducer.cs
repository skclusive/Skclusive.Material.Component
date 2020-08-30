using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Selection
{
    public class SelectionStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            var isDark = theme.IsDark();

            var palette = theme.Palette;

            return new Dictionary<string, string>
            {
                { "--theme-component-switch-color", (isDark ? palette.Grey.X400 : palette.Grey.X50).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-switch-disabled-color", (isDark ? palette.Grey.X800 : palette.Grey.X400).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-switch-disabled-opacity", (isDark ? 0.1 : 0.12).ToString(CultureInfo.InvariantCulture) },
            };
        }
    }
}