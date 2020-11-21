using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Skclusive.Material.Theme
{
    public static class ColorManipulator
    {
        public static decimal Clamp(decimal n, int min, int max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        public static string HexToRgb(this string color)
        {
            color = color.Substring(1);

            var reg = new Regex($".{{1,{color.Length / 3}}}", RegexOptions.ECMAScript);

            var matches = reg.Matches(color);

            var builder = new StringBuilder();
            if (matches.Count > 0)
            {
                builder.Append("rgb(");

                var hexes = new List<string>();
                for (int ctr = 0; ctr < matches.Count; ctr++)
                {
                    hexes.Add(matches[ctr].Value);
                }
                // matches.Select(match => match.Value).ToList();

                if (matches[0].Length == 1)
                {
                    hexes = hexes.Select(n => $"{n}{n}").ToList();
                }

                var values = hexes.Select(value => int.Parse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture));

                builder.Append(string.Join(", ", values));

                builder.Append(")");
            }

            return builder.ToString();
        }

        public static string IntToHex(this int value)
        {
            var hex = value.ToString("X");

            return hex.Length == 1 ? $"0{hex}" : hex;
        }

        public static string RgbToHex(this string color)
        {
            if (color[0] == '#')
            {
                return color;
            }

            var (type, values) = color.DecomposeColor();

            var hexes = values.Select(value => Convert.ToInt32(value).IntToHex());

            return $"#{string.Join("", hexes)}";
        }

        public static string HslToRgb(this string color)
        {
            var (type, values) = color.DecomposeColor();

            var h = values[0];
            var s = values[1] / 100;
            var l = values[2] / 100;
            var a = s * Math.Min(l, 1 - l);

            decimal f(int n)
            {
                var k = (n + h / 30) % 12;

                return l - a * Math.Max(Math.Min(k - 3, Math.Min(9 - k, 1)), -1);
            }

            var doubles = new decimal[] { Math.Round(f(0) * 255), Math.Round(f(8) * 255), Math.Round(f(4) * 255) };

            var rgbvalues = doubles.Select(d => (decimal)d).ToList();

            var rgbtype = type == "hsla" ? "rgba" : "rgb";

            if (type == "hsla" && values.Length > 3)
            {
                rgbvalues.Add(values[3]);
            }

            return (type: rgbtype, values: rgbvalues.ToArray()).RecomposeColor();
        }

        public static (string type, decimal[] values) DecomposeColor(this string color)
        {
            if (color[0] == '#')
            {
                return color.HexToRgb().DecomposeColor();
            }

            var marker = color.IndexOf("(");
            var type = color.Substring(0, marker);

            var values = color.Substring(marker + 1, (color.Length - 1) - (marker + 1))
            .Split(',')
            .Select(value => value.Trim().Replace("%", ""))
            .Select(value => decimal.Parse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture)).ToArray();

            return (type, values);
        }

        public static string RecomposeColor(this (string type, decimal[] values) composed)
        {
            var (type, values) = composed;

            List<string> segs = new List<string>();

            if (type.IndexOf("rgb") != -1)
            {
                segs.AddRange(values.Select((value, index) => index < 3 ? Convert.ToInt32(Math.Floor(value)).ToString(CultureInfo.InvariantCulture) : value.ToString(CultureInfo.InvariantCulture)));
            }
            else if (type.IndexOf("hsl") != -1)
            {
                segs.AddRange(values.Select((value, index) => index == 1 || index == 2 ? $"{Convert.ToInt32(Math.Floor(value)).ToString(CultureInfo.InvariantCulture)}%" : value.ToString(CultureInfo.InvariantCulture)));
            }

            return $"{type}({string.Join(", ", segs)})";
        }

        public static decimal Luminance(this string color)
        {
            var decompo = color.DecomposeColor();

            var rgb = decompo.type == "hsl" ? color.HslToRgb().DecomposeColor().values : decompo.values;

            rgb = rgb.Select(val =>
            {
                val /= 255; // normalized
                return (decimal)(val <= 0.03928m ? val / 12.92m : (decimal)Math.Pow(((double)((val + 0.055m) / 1.055m)), 2.4));
            }).ToArray();

            return Decimal.Round(0.2126m * rgb[0] + 0.7152m * rgb[1] + 0.0722m * rgb[2], 3);
        }

        public static decimal ContrastRatio(this string foreground, string background)
        {
            var lumA = foreground.Luminance();

            var lumB = background.Luminance();

            return Decimal.Round((Math.Max(lumA, lumB) + 0.05m) / (Math.Min(lumA, lumB) + 0.05m), 2);
        }

        public static string Fade(this string color, decimal alpha)
        {
            var (type, values) = color.DecomposeColor();

            alpha = Clamp(alpha, 0, 1);

            var segs = new List<decimal>(values);
            if (segs.Count > 3)
            {
                segs[3] = alpha;
            }
            else
            {
                segs.Add(alpha);
            }
            type = type == "rgb" || type == "hsl" ? $"{type}a" : type;

            return (type, values: segs.ToArray()).RecomposeColor();
        }

        public static string Darken(this string color, decimal coefficient)
        {
            var (type, values) = color.DecomposeColor();

            coefficient = Clamp(coefficient, 0, 1);

            if (type.IndexOf("hsl") != -1)
            {
                values[2] = values[2] * (1 - coefficient);
            }
            else if (type.IndexOf("rgb") != -1)
            {
                for (var i = 0; i < 3; i += 1)
                {
                    values[i] = values[i] * (1 - coefficient);
                }
            }
            return (type, values).RecomposeColor();
        }

        public static string Lighten(this string color, decimal coefficient)
        {
            var (type, values) = color.DecomposeColor();

            coefficient = Clamp(coefficient, 0, 1);

            if (type.IndexOf("hsl") != -1)
            {
                values[2] += (100 - values[2]) * coefficient;
            }
            else if (type.IndexOf("rgb") != -1)
            {
                for (var i = 0; i < 3; i += 1)
                {
                    values[i] += (255 - values[i]) * coefficient;
                }
            }
            return (type, values).RecomposeColor();
        }

        public static string Emphasize(this string color, decimal coefficient = 0.15m)
        {
            var toDark = color.Luminance() > 0.5m;

            return toDark ? color.Darken(coefficient) : color.Lighten(coefficient);
        }
    }
}