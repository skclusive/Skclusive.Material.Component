using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Divider
{
    public class DividerStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            return new Dictionary<string, string>
            {
                { "--theme-component-divider-background-color", theme.Palette.Divider.Fade(0.08m).ToString(CultureInfo.InvariantCulture) }
            };
        }
    }
}