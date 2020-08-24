
using System;
using System.Globalization;
using System.Text;

namespace Skclusive.Material.Theme
{
    public static class ThemeExtensions
    {
        public static bool IsDark(this Theme theme)
        {
            return theme.Palette.Type == PaletteType.Dark;
        }

        public static bool IsLight(this Theme theme)
        {
            return theme.Palette.Type == PaletteType.Light;
        }
    }
}