
using System.Globalization;
using System.Text;

namespace Skclusive.Material.Theme
{
    public static class DecimalExtensions
    {
        public static string ToCleanString(this decimal input, bool leadingZero = false)
        {
            var value = input.ToString(CultureInfo.InvariantCulture);

            if (value.Contains("."))
            {
                StringBuilder builder = new StringBuilder();
                var chars = value.ToCharArray();
                var lastZero = false;
                for (var i = chars.Length - 1; i >= 0; i--)
                {
                    char ch = chars[i];
                    if (ch == '0')
                    {
                        lastZero = true;
                    }
                    else if (ch == '.' && lastZero)
                    {
                        lastZero = false;
                        continue;
                    }
                    else
                    {
                        lastZero = false;
                        builder.Append(ch);
                    }
                }
                value = builder.ToString().Reverse();
            }

            if (leadingZero && value[0] == '.')
            {
                value = $"0{value}";
            }

            return value;
        }
    }
}