using System.Collections.Generic;
using System.Globalization;
using Skclusive.Core.Component;
using Skclusive.Material.Theme;

namespace Skclusive.Material.Chip
{
    public class ChipStyleProducer : IStyleProducer
    {
        public IDictionary<string, string> Variables(ThemeValue theme)
        {
            var palette = theme.Palette;

            string ToContrastText(string color)
            {
                return color.ToContrastText(palette.ContrastThreshold);
            }

            var isDark = theme.IsDark();

            return new Dictionary<string, string>
            {
                { "--theme-component-chip-color", ToContrastText(isDark ? palette.Grey.X700 : palette.Grey.X300).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-background-color", (isDark ? palette.Grey.X700 : palette.Grey.X300).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-clickable-focus", (isDark ? palette.Grey.X700 : palette.Grey.X300).Emphasize(0.08m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-clickable-active", (isDark ? palette.Grey.X700 : palette.Grey.X300).Emphasize(0.12m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-clickable-primary-focus", palette.Primary.Main.Emphasize(0.08m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-clickable-primary-active", palette.Primary.Main.Emphasize(0.12m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-clickable-secondary-focus", palette.Secondary.Main.Emphasize(0.08m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-clickable-secondary-active", palette.Secondary.Main.Emphasize(0.12m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-deletable-focus", (isDark ? palette.Grey.X700 : palette.Grey.X300).Emphasize(0.08m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-deletable-primary-focus", palette.Primary.Main.Emphasize(0.2m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-deletable-secondary-focus", palette.Secondary.Main.Emphasize(0.2m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-outlined-focus", palette.Text.Primary.Fade(palette.Action.HoverOpacity).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-outlined-primary-focus", palette.Primary.Main.Fade(palette.Action.HoverOpacity).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-outlined-secondary-focus", palette.Secondary.Main.Fade(palette.Action.HoverOpacity).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-avatar-color", (isDark ? palette.Grey.X300 : palette.Grey.X700).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-icon-color", (isDark ? palette.Grey.X300 : palette.Grey.X700).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-delete-icon-color", palette.Text.Primary.Fade(0.26m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-delete-icon-color-hover", palette.Text.Primary.Fade(0.26m).Fade(0.4m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-delete-icon-primary-color", palette.Primary.ContrastText.Fade(0.7m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-delete-icon-secondary-color", palette.Secondary.ContrastText.Fade(0.7m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-delete-icon-outlined-primary-color", palette.Primary.Main.Fade(0.7m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-delete-icon-outlined-secondary-color", palette.Secondary.Main.Fade(0.7m).ToString(CultureInfo.InvariantCulture) },
                { "--theme-component-chip-border-outlined", (isDark ? "rgba(255, 255, 255, 0.23)" : "rgba(0, 0, 0, 0.23)").ToString(CultureInfo.InvariantCulture) },
            };
        }
    }
}