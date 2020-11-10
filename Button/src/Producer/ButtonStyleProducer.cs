using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Button
{
    public class ButtonStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            var palette = theme.Palette;

            var isDark = theme.IsDark();

            return new Dictionary<string, string>
            {
                { "--theme-component-button-border-outlined", (isDark ? "rgba(255, 255, 255, 0.23)" : "rgba(0, 0, 0, 0.23)").ToString(CultureInfo.InvariantCulture) },
            };
        }
    }
}