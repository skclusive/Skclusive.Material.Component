
using System;
using System.Globalization;
using System.Text;

namespace Skclusive.Material.Theme
{
    public static class ThemeValueExtension
    {
        public static bool IsDark(this ThemeValue theme)
        {
            return theme.Palette.Type == PaletteType.Dark;
        }

        public static bool IsLight(this ThemeValue theme)
        {
            return theme.Palette.Type == PaletteType.Light;
        }
    }
}