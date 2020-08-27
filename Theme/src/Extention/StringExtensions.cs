
using System;
using System.Globalization;
using System.Text;

namespace Skclusive.Material.Theme
{
    public static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            var chars = input.ToCharArray();

            Array.Reverse(chars);

            return String.Concat(chars);
        }

        public static string ToContrastText(this string background, decimal contrastThreshold = 3)
        {
            return background.ContrastRatio(PaletteColors.Dark.Text.Primary) >= contrastThreshold ? PaletteColors.Dark.Text.Primary : PaletteColors.Light.Text.Primary;
        }
    }
}