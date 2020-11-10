using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Avatar
{
    public class AvatarStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            var isDark = theme.IsDark();

            var palette = theme.Palette;

            return new Dictionary<string, string>
            {
                { "--theme-component-avatar-background", (isDark ? palette.Grey.X600 : palette.Grey.X400).ToString(CultureInfo.InvariantCulture) }
            };
        }
    }
}