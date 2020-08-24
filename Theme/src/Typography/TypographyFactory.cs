using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public static class TypographyFactory
    {
        public static readonly string DefaultFontFamily = @"""Roboto"", ""Helvetica"", ""Arial"", sans-serif";

        public static Typography CreateTypography(Palette palette, TypographyConfig config)
        {
            var fontFamily = config?.FontFamily ?? DefaultFontFamily;

            // The default font size of the Material Specification.
            var fontSize = config?.FontSize ?? 14; // px

            var fontWeightLight = config?.FontWeightLight ?? 300;

            var fontWeightRegular = config?.FontWeightRegular ?? 400;

            var fontWeightMedium = config?.FontWeightMedium ?? 500;

            var fontWeightBold = config?.FontWeightBold ?? 700;

            // var allVariants = config?.AllVariants;

            // Tell Material-UI what's the font-size on the html element.
            // 16px is the default font-size used by browsers.
            var htmlFontSize = config?.HtmlFontSize ?? 16;

            var coef = (decimal)fontSize / 14;

            Func<short, string> pxToRem = config?.PxToRem ?? ((short size) => $"{Decimal.Round(((decimal)size / htmlFontSize) * coef, 2)}rem".Replace(".00", ""));

            TypographySegment BuildVariant(TypographySegmentConfig option, short fontWeight, short size, decimal lineHeight, decimal letterSpacing, string transform = null)
            {
                return new TypographySegment
                {
                    FontFamily = option?.FontFamily ?? fontFamily,

                    FontWeight = option?.FontWeight ?? fontWeight,

                    FontSize = option?.FontSize ?? pxToRem(size),

                    LineHeight = option?.LineHeight ?? lineHeight,

                    LetterSpacing = option?.LetterSpacing ?? (fontFamily == DefaultFontFamily ? ((Math.Round((double)(letterSpacing / size) * 1e5) / 1e5).ToString(CultureInfo.InvariantCulture) + "em") : ""),

                    TextTransform = option?.TextTransform ?? transform
                };
            }

            var typography = new Typography
            {
                PxToRem = pxToRem,

                HtmlFontSize = htmlFontSize,

                FontFamily = fontFamily,

                FontSize = fontSize,

                FontWeightLight = fontWeightLight,

                FontWeightRegular = fontWeightRegular,

                FontWeightMedium = fontWeightMedium,

                FontWeightBold = fontWeightBold,

                H1 = BuildVariant(config?.H1, fontWeightLight, 96, 1, -1.5m),

                H2 = BuildVariant(config?.H2, fontWeightLight, 60, 1, -0.5m),

                H3 = BuildVariant(config?.H3, fontWeightRegular, 48, 1.04m, 0),

                H4 = BuildVariant(config?.H4, fontWeightRegular, 34, 1.17m, 0.25m),

                H5 = BuildVariant(config?.H5, fontWeightRegular, 24, 1.33m, 0),

                H6 = BuildVariant(config?.H6, fontWeightMedium, 20, 1.6m, 0.15m),

                Subtitle1 = BuildVariant(config?.Subtitle1, fontWeightRegular, 16, 1.75m, 0.15m),

                Subtitle2 = BuildVariant(config?.Subtitle2, fontWeightMedium, 14, 1.57m, 0.1m),

                Body1 = BuildVariant(config?.Body1, fontWeightRegular, 16, 1.5m, 0.15m),

                Body2 = BuildVariant(config?.Body2, fontWeightRegular, 14, 1.43m, 0.15m),

                Caption = BuildVariant(config?.Caption, fontWeightRegular, 12, 1.66m, 0.4m),

                Button = BuildVariant(config?.Button, fontWeightMedium, 14, 1.75m, 0.4m, transform: "uppercase"),

                Overline = BuildVariant(config?.Overline, fontWeightRegular, 12, 2.66m, 1, transform: "uppercase"),
            };

            return typography;
        }

        public static Typography CreateTypography(Palette palette, Func<Palette, TypographyConfig> optionFunc)
        {
            return CreateTypography(palette, optionFunc(palette));
        }
    }
}