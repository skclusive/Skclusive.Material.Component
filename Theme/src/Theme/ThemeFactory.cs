using System;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public static class ThemeFactory
    {
        public static Theme CreateTheme(ThemeConfig config)
        {
            var palette = PaletteFactory.CreatePalette(config?.Palette);

            var typographyFunc = config?.TypographyFunc ?? ((Palette p) => config?.Typography);

            var theme = new Theme
            {
                Direction = config?.Direction ?? Direction.LTR,

                Shape = ShapeFactory.CreateShape(config?.Shape),

                Breakpoints = BreakpointsFactory.CreateBreakpoints(config?.Breakpoints),

                Spacing = SpacingFactory.CreateSpacing(config?.Spacing),

                Palette = palette,

                Typography = TypographyFactory.CreateTypography(palette, typographyFunc),

                Transitions = TransitionsFactory.CreateTransitions(config?.Transitions),

                ZIndex = ZIndexFactory.CreateZIndex(config?.ZIndex),

                Shadows = config?.Shadows ?? Shadow.Shadows.ToArray()
            };

            return theme;
        }
    }
}