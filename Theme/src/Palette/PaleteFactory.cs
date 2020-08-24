using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public static class PaletteFactory
    {
        public static PaletteColor AugmentColor(PaletteColorConfig color,
            Func<PaletteColorConfig, string> mainShade,
            Func<PaletteColorConfig, string> lightShade,
            Func<PaletteColorConfig, string> darkShade,
            decimal tonalOffset = 0.2m,
            decimal contrastThreshold = 3)
        {
            var main = color.Main ?? mainShade(color);

            var light = color.Light ?? lightShade(color) ?? main.Lighten(tonalOffset);

            var dark = color.Dark ?? darkShade(color) ?? main.Darken(tonalOffset * 1.5m);

            var contrastText = color.ContrastText ?? ToContrastText(main, contrastThreshold);

            return new PaletteColor
            {
                Main = main,

                Light = light,

                Dark = dark,

                ContrastText = contrastText,
            };
        }

        public static PaletteColor AugmentColor(PaletteColorConfig colorConfig, decimal tonalOffset = 0.2m, decimal contrastThreshold = 3)
        {
            return AugmentColor(colorConfig, p => p.X500, p => p.X300, p => p.X700, tonalOffset, contrastThreshold);
        }

        public static string ToContrastText(string background, decimal contrastThreshold = 3)
        {
            return background.ContrastRatio(TypeColors.Dark.Text.Primary) >= contrastThreshold ? TypeColors.Dark.Text.Primary : TypeColors.Light.Text.Primary;
        }

        public static Palette CreatePalette(PaletteConfig config)
        {
            var tonalOffset = config?.TonalOffset ?? 0.2m;

            var contrastThreshold = config?.ContrastThreshold ?? 3;

            var primary = AugmentColor(config?.Primary ?? new PaletteColorConfig
            {
                Light = TypeColors.Indigo.X300,

                Main = TypeColors.Indigo.X500,

                Dark = TypeColors.Indigo.X700

            }, tonalOffset, contrastThreshold);

            var secondary = AugmentColor(config?.Secondary ?? new PaletteColorConfig
            {
                Light = TypeColors.Pink.A200,

                Main = TypeColors.Pink.A400,

                Dark = TypeColors.Pink.A700
            },
            p => p.A400, p => p.A200, p => p.A700, tonalOffset, contrastThreshold);

            var error = AugmentColor(config?.Error ?? new PaletteColorConfig
            {
                Light = TypeColors.Red.X300,

                Main = TypeColors.Red.X500,

                Dark = TypeColors.Red.X700

            }, tonalOffset, contrastThreshold);

            var type = config?.Type ?? PaletteType.Light;

            var isLight = type == PaletteType.Light;

            var palette = new Palette
            {
                Primary = primary,

                Secondary = secondary,

                Error = error,

                Type = type,

                ContrastThreshold = contrastThreshold,

                TonalOffset = tonalOffset,

                Grey = config?.Grey ?? TypeColors.Grey,

                Common = config?.Common ?? TypeColors.Common,

                Text = config?.Text ?? (isLight ? TypeColors.Light.Text : TypeColors.Dark.Text),

                Divider = config?.Divider ?? (isLight ? TypeColors.Light.Divider : TypeColors.Dark.Divider),

                Background = config?.Background ?? (isLight ? TypeColors.Light.Background : TypeColors.Dark.Background),

                Action = config?.Action ?? (isLight ? TypeColors.Light.Action : TypeColors.Dark.Action),

                Custom = config?.Custom ?? (isLight ? TypeColors.Light.Custom : TypeColors.Dark.Custom),
            };

            return palette;
        }
    }
}