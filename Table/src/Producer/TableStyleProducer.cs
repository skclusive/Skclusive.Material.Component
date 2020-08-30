using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Table
{
    public class TableStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            var isDark = theme.IsDark();

            var palette = theme.Palette;

            return new Dictionary<string, string>
            {
                { "--theme-component-table-row-background-selected", (isDark ? "rgba(255, 255, 255, 0.08)" : "rgba(0, 0, 0, 0.04)").ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-table-row-background-hover", (isDark ? "rgba(255, 255, 255, 0.14)" : "rgba(0, 0, 0, 0.07)").ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-table-cell-border-bottom", (isDark ? palette.Divider.Fade(1).Darken(0.68m) : palette.Divider.Fade(1).Lighten(0.88m)).ToString(CultureInfo.InvariantCulture) }
            };
        }
    }
}