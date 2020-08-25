using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Theme
{
    public class ThemeProducer
    {
        private static string Wrap(string style)
        {
            return @"
                :root {" + style + @"
                }";
        }

        public static string BuildMediaScheme(Theme theme)
        {
            var scheme = theme.IsDark() ? "dark" : "light";

            return @$"@media (prefers-color-scheme: {scheme}) {{
                {BuildScheme(theme)}
            }}";
        }

        /*
        new items
            --theme-typography-font-size-20
            --theme-typography-font-size-12
            --theme-palette-current-background
        */
        /* deprecated

            --theme-typography-font-size-medium
            --theme-typography-font-size-normal
            --theme-palette-common-background


            --theme-palette-color: {palette.Common.Color};

            --theme-palette-warning-main: {palette.Warning.Main};
            --theme-palette-warning-light: {palette.Warning.Light};
            --theme-palette-warning-dark: {palette.Warning.Dark};
            --theme-palette-warning-contrast-text: {palette.Warning.ContrastText};

            --theme-palette-info-main: {palette.Info.Main};
            --theme-palette-info-light: {palette.Info.Light};
            --theme-palette-info-dark: {palette.Info.Dark};
            --theme-palette-info-contrast-text: {palette.Info.ContrastText};

            --theme-palette-success-main: {palette.Success.Main};
            --theme-palette-success-light: {palette.Success.Light};
            --theme-palette-success-dark: {palette.Success.Dark};
            --theme-palette-success-contrast-text: {palette.Success.ContrastText};

            --theme-palette-main-background-default: {palette.Main.Background};

            --theme-palette-text-color: {palette.Text.Color};

                        --theme-palette-background-level1: {palette.Background.Level1};
            --theme-palette-background-level2: {palette.Background.Level2};

        */

        public static string BuildCommon(Theme theme)
        {
            var palette = theme.Palette;

            var typography = theme.Typography;

            return  Wrap($@"
            --theme-palette-common-white: {palette.Common.White};
            --theme-palette-common-black: {palette.Common.Black};

            --theme-spacing: {theme.Spacing.Value()};
            --theme-shape-border-radius: {theme.Shape.BorderRadius};
            --theme-transition-box-shadow: {theme.Transitions.Make("box-shadow")};

            --theme-font-size: {typography.FontSize};
            --theme-html-font-size: {typography.HtmlFontSize};
            --theme-zindex-appbar: {theme.ZIndex.AppBar};
            --theme-zindex-drawer: {theme.ZIndex.Drawer};
            --theme-font-size-coef: calc(var(--theme-font-size) / 14);
            --theme-font-size-rem-factor: calc(var(--theme-font-size-coef) / var(--theme-html-font-size));

            --theme-shadow0: {theme.Shadows[0]};
            --theme-shadow1: {theme.Shadows[1]};
            --theme-shadow2: {theme.Shadows[2]};
            --theme-shadow3: {theme.Shadows[3]};
            --theme-shadow4: {theme.Shadows[4]};
            --theme-shadow5: {theme.Shadows[5]};
            --theme-shadow6: {theme.Shadows[6]};
            --theme-shadow7: {theme.Shadows[7]};
            --theme-shadow8: {theme.Shadows[8]};
            --theme-shadow9: {theme.Shadows[9]};
            --theme-shadow10: {theme.Shadows[10]};
            --theme-shadow11: {theme.Shadows[11]};
            --theme-shadow12: {theme.Shadows[12]};
            --theme-shadow13: {theme.Shadows[13]};
            --theme-shadow14: {theme.Shadows[14]};
            --theme-shadow15: {theme.Shadows[15]};
            --theme-shadow16: {theme.Shadows[16]};
            --theme-shadow17: {theme.Shadows[17]};
            --theme-shadow18: {theme.Shadows[18]};
            --theme-shadow19: {theme.Shadows[19]};
            --theme-shadow20: {theme.Shadows[20]};
            --theme-shadow21: {theme.Shadows[21]};
            --theme-shadow22: {theme.Shadows[22]};
            --theme-shadow23: {theme.Shadows[23]};
            --theme-shadow24: {theme.Shadows[24]};

            --theme-typography-font-size: var(--theme-font-size);
            --theme-typography-html-font-size: var(--theme-html-font-size);

            --theme-typography-font-size-20: {typography.PxToRem(20)};
            --theme-typography-font-size-12: {typography.PxToRem(12)};

            --theme-typography-font-family: {typography.FontFamily};
            --theme-typography-font-size-medium: var(--theme-typography-font-size-20);
            --theme-typography-font-size-normal: var(--theme-typography-font-size-12);
            --theme-typography-font-weight-light: {typography.FontWeightLight};
            --theme-typography-font-weight-regular: {typography.FontWeightRegular};
            --theme-typography-font-weight-medium: {typography.FontWeightMedium};
            --theme-typography-font-weight-bold: {typography.FontWeightBold};

            --theme-typography-body1-font-family: {typography.Body1.FontFamily};
            --theme-typography-body1-font-size: {typography.Body1.FontSize};
            --theme-typography-body1-font-weight: {typography.Body1.FontWeight};
            --theme-typography-body1-line-height: {typography.Body1.LineHeight};
            --theme-typography-body1-letter-spacing: {typography.Body1.LetterSpacing};

            --theme-typography-body2-font-family: {typography.Body2.FontFamily};
            --theme-typography-body2-font-size: {typography.Body2.FontSize};
            --theme-typography-body2-font-weight: {typography.Body2.FontWeight};
            --theme-typography-body2-line-height: {typography.Body2.LineHeight};
            --theme-typography-body2-letter-spacing: {typography.Body2.LetterSpacing};

            --theme-typography-caption-font-family: {typography.Caption.FontFamily};
            --theme-typography-caption-font-size: {typography.Caption.FontSize};
            --theme-typography-caption-font-weight: {typography.Caption.FontWeight};
            --theme-typography-caption-line-height: {typography.Caption.LineHeight};
            --theme-typography-caption-letter-spacing: {typography.Caption.LetterSpacing};

            --theme-typography-h1-font-family: {typography.H1.FontFamily};
            --theme-typography-h1-font-size: {typography.H1.FontSize};
            --theme-typography-h1-font-weight: {typography.H1.FontWeight};
            --theme-typography-h1-line-height: {typography.H1.LineHeight};
            --theme-typography-h1-letter-spacing: {typography.H1.LetterSpacing};

            --theme-typography-h2-font-family: {typography.H2.FontFamily};
            --theme-typography-h2-font-size: {typography.H2.FontSize};
            --theme-typography-h2-font-weight: {typography.H2.FontWeight};
            --theme-typography-h2-line-height: {typography.H2.LineHeight};
            --theme-typography-h2-letter-spacing: {typography.H2.LetterSpacing};

            --theme-typography-h3-font-family: {typography.H3.FontFamily};
            --theme-typography-h3-font-size: {typography.H3.FontSize};
            --theme-typography-h3-font-weight: {typography.H3.FontWeight};
            --theme-typography-h3-line-height: {typography.H3.LineHeight};
            --theme-typography-h3-letter-spacing: {typography.H3.LetterSpacing};

            --theme-typography-h4-font-family: {typography.H4.FontFamily};
            --theme-typography-h4-font-size: {typography.H4.FontSize};
            --theme-typography-h4-font-weight: {typography.H4.FontWeight};
            --theme-typography-h4-line-height: {typography.H4.LineHeight};
            --theme-typography-h4-letter-spacing: {typography.H4.LetterSpacing};

            --theme-typography-h5-font-family: {typography.H5.FontFamily};
            --theme-typography-h5-font-size: {typography.H5.FontSize};
            --theme-typography-h5-font-weight: {typography.H5.FontWeight};
            --theme-typography-h5-line-height: {typography.H5.LineHeight};
            --theme-typography-h5-letter-spacing: {typography.H5.LetterSpacing};

            --theme-typography-h6-font-family: {typography.H6.FontFamily};
            --theme-typography-h6-font-size: {typography.H6.FontSize};
            --theme-typography-h6-font-weight: {typography.H6.FontWeight};
            --theme-typography-h6-line-height: {typography.H6.LineHeight};
            --theme-typography-h6-letter-spacing: {typography.H6.LetterSpacing};

            --theme-typography-subtitle1-font-family: {typography.Subtitle1.FontFamily};
            --theme-typography-subtitle1-font-size: {typography.Subtitle1.FontSize};
            --theme-typography-subtitle1-font-weight: {typography.Subtitle1.FontWeight};
            --theme-typography-subtitle1-line-height: {typography.Subtitle1.LineHeight};
            --theme-typography-subtitle1-letter-spacing: {typography.Subtitle1.LetterSpacing};

            --theme-typography-subtitle2-font-family: {typography.Subtitle2.FontFamily};
            --theme-typography-subtitle2-font-size: {typography.Subtitle2.FontSize};
            --theme-typography-subtitle2-font-weight: {typography.Subtitle2.FontWeight};
            --theme-typography-subtitle2-line-height: {typography.Subtitle2.LineHeight};
            --theme-typography-subtitle2-letter-spacing: {typography.Subtitle2.LetterSpacing};

            --theme-typography-overline-font-family: {typography.Overline.FontFamily};
            --theme-typography-overline-font-size: {typography.Overline.FontSize};
            --theme-typography-overline-font-weight: {typography.Overline.FontWeight};
            --theme-typography-overline-line-height: {typography.Overline.LineHeight};
            --theme-typography-overline-letter-spacing: {typography.Overline.LetterSpacing};
            --theme-typography-overline-text-transform: {typography.Overline.TextTransform};

            --theme-typography-button-font-family: {typography.Button.FontFamily};
            --theme-typography-button-font-size: {typography.Button.FontSize};
            --theme-typography-button-font-weight: {typography.Button.FontWeight};
            --theme-typography-button-line-height: {typography.Button.LineHeight};
            --theme-typography-button-letter-spacing: {typography.Button.LetterSpacing};
            --theme-typography-button-text-transform: {typography.Button.TextTransform};
            ");
        }

        public static string BuildScheme(Theme theme)
        {
            var palette = theme.Palette;

            var isDark = theme.IsDark();

            return  Wrap($@"
            --theme-mode-dark: {(isDark ? 1 : 0)};

            --theme-palette-common-background: {(isDark ? palette.Common.White : palette.Common.Black)};
            {Variables("--theme-palette-common", palette.Common.Custom)}

            --theme-palette-switch-color: {(isDark ? palette.Grey.X400 : palette.Grey.X50)};
            --theme-palette-switch-disabled-color: {(isDark ? palette.Grey.X800 : palette.Grey.X400)};
            --theme-palette-switch-disabled-opacity: {(isDark ? 0.1 : 0.12)};

            --theme-palette-text-primary: {palette.Text.Primary};
            --theme-palette-text-secondary: {palette.Text.Secondary};
            --theme-palette-text-disabled: {palette.Text.Disabled};
            --theme-palette-text-hint: {palette.Text.Hint};
            {Variables("--theme-palette-text", palette.Text.Custom)}

            --theme-palette-background-paper: {palette.Background.Paper};
            --theme-palette-background-default: {palette.Background.Default};
            {Variables("--theme-palette-background", palette.Background.Custom)}

            --theme-palette-action-active: {palette.Action.Active};
            --theme-palette-action-hover: {palette.Action.Hover};
            --theme-palette-action-hover-opacity: {palette.Action.HoverOpacity};
            --theme-palette-action-selected: {palette.Action.Selected};
            --theme-palette-action-disabled: {palette.Action.Disabled};
            --theme-palette-action-disabled-background: {palette.Action.DisabledBackground};
            {Variables("--theme-palette-action", palette.Action.Custom)}

            --theme-palette-primary-main: {palette.Primary.Main};
            --theme-palette-primary-light: {palette.Primary.Light};
            --theme-palette-primary-dark: {palette.Primary.Dark};
            --theme-palette-primary-contrast-text: {palette.Primary.ContrastText};
            --theme-palette-primary-alternate: {(isDark ? palette.Primary.Light : palette.Primary.Dark)};
            --theme-palette-primary-hover: {palette.Primary.Main.Fade(palette.Action.HoverOpacity)};
            --theme-palette-primary-background: {(isDark ? palette.Primary.Main.Darken(0.5m) : palette.Primary.Main.Lighten(0.62m))};
            {Variables("--theme-palette-primary", palette.Primary.Custom)}

            --theme-palette-secondary-main: {palette.Secondary.Main};
            --theme-palette-secondary-light: {palette.Secondary.Light};
            --theme-palette-secondary-dark: {palette.Secondary.Dark};
            --theme-palette-secondary-contrast-text: {palette.Secondary.ContrastText};
            --theme-palette-secondary-hover: {palette.Secondary.Main.Fade(palette.Action.HoverOpacity)};
            --theme-palette-secondary-border: {palette.Secondary.Main.Fade(0.5m)};
            --theme-palette-secondary-background:  {(isDark ? palette.Secondary.Main.Darken(0.5m) : palette.Secondary.Main.Lighten(0.62m))};
            --theme-palette-secondary-alternate: {(isDark ? palette.Secondary.Light : palette.Secondary.Dark)};
            {Variables("--theme-palette-secondary", palette.Secondary.Custom)}

            --theme-palette-error-main: {palette.Error.Main};
            --theme-palette-error-light: {palette.Error.Light};
            --theme-palette-error-dark: {palette.Error.Dark};
            --theme-palette-error-contrast-text: {palette.Error.ContrastText};
            {Variables("--theme-palette-error", palette.Error.Custom)}

            --theme-palette-divider: {palette.Divider};
            --theme-palette-divider-background-color: {palette.Divider.Fade(0.08m)};
            --theme-palette-divider-border-bottom: {(isDark ? palette.Divider.Fade(1).Darken(0.68m) : palette.Divider.Fade(1).Lighten(0.88m) )};

            --theme-palette-border-outlined: {(isDark ? "rgba(255, 255, 255, 0.23)" : "rgba(0, 0, 0, 0.23)")};

            --theme-palette-table-row-background-selected: {(isDark ? "rgba(255, 255, 255, 0.08)" : "rgba(0, 0, 0, 0.04)")};
            --theme-palette-table-row-background-hover:  {(isDark ? "rgba(255, 255, 255, 0.14)" : "rgba(0, 0, 0, 0.07)")};

            --theme-palette-grey50: {palette.Grey.X50};
            --theme-palette-grey300: {palette.Grey.X300};
            --theme-palette-grey300-contrast-text: {PaletteFactory.ToContrastText(palette.Grey.X300, palette.ContrastThreshold)};
            --theme-palette-greyA100: {palette.Grey.A100};
            --theme-palette-grey-contrast-text-default: {PaletteFactory.ToContrastText(isDark ? palette.Grey.X900 : palette.Grey.X100, palette.ContrastThreshold)};
            --theme-palette-grey-background-default: {(isDark ? palette.Grey.X900 : palette.Grey.X100)};
            --theme-palette-avatar-background: {(isDark ? palette.Grey.X600 : palette.Grey.X400)};

            --theme-custom-light-or-dark: {palette.Custom.LightOrDark};
            --theme-custom-light-or-dark-contrast-text: {palette.Custom.LightOrDarkContrastText};
            --theme-custom-content-background-color: {palette.Custom.ContentBackground};
            --theme-custom-content-background-default: {palette.Custom.ContentBackgroundDefault};
            --theme-custom-palette-common-alternate: {palette.Custom.PaletteCommonAlternate};
            --theme-custom-palette-opacity: {palette.Custom.PaletteOpacity};
            --theme-custom-layout-backward: {palette.Custom.LayoutBackward};
            --theme-custom-layout-forward: {palette.Custom.LayoutForward};
            --theme-custom-palette-primary-main: {palette.Custom.PrimaryMain};
            --theme-custom-palette-primary-contrast-text: {palette.Custom.PrimaryContrastText};
            ");
        }

        private static string Variables(string prefix, IDictionary<string, string> values)
        {
            var variables = values.Select(value => $"{prefix}-custom-{value.Key}: {value.Value};");

            return string.Join("\n", variables);
        }
    }
}