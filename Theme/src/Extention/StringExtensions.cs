
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
    }
}