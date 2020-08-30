using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Skclusive.Material.Theme
{
    internal class StyleProducerComparator : IEqualityComparer<IStyleProducer>
    {
        public bool Equals([AllowNull] IStyleProducer left, [AllowNull] IStyleProducer right)
        {
            return left.GetType().Equals(right.GetType());
        }

        public int GetHashCode([DisallowNull] IStyleProducer obj)
        {
            return obj.GetType().GetHashCode();
        }
    }

    public class ThemeProducer : IThemeProducer
    {
        public ThemeProducer(IEnumerable<IStyleProducer> styleProducers)
        {
            StyleProducers = styleProducers.Distinct(new StyleProducerComparator()).ToList();
        }

        private IList<IStyleProducer> StyleProducers { set; get; }

        private static string Wrap(string style)
        {
            return @"
                :root {" + style + @"
                }";
        }

        public virtual string BuildMediaScheme(ThemeValue theme)
        {
            var scheme = theme.IsDark() ? "dark" : "light";

            return @$"@media (prefers-color-scheme: {scheme}) {{
                {BuildScheme(theme)}
            }}";
        }

        public virtual string BuildCommon(ThemeValue theme)
        {
            var palette = theme.Palette;

            var typography = theme.Typography;

            return Wrap($@"
            --theme-palette-common-white: {palette.Common.White.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-common-black: {palette.Common.Black.ToString(CultureInfo.InvariantCulture)};

            --theme-spacing: {theme.Spacing.Value().ToString(CultureInfo.InvariantCulture)};
            --theme-shape-border-radius: {theme.Shape.BorderRadius.ToString(CultureInfo.InvariantCulture)};
            --theme-transition-box-shadow: {theme.Transitions.Make("box-shadow").ToString(CultureInfo.InvariantCulture)};

            --theme-font-size: {typography.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-html-font-size: {typography.HtmlFontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-zindex-appbar: {theme.ZIndex.AppBar.ToString(CultureInfo.InvariantCulture)};
            --theme-zindex-drawer: {theme.ZIndex.Drawer.ToString(CultureInfo.InvariantCulture)};
            --theme-font-size-coef: calc(var(--theme-font-size) / 14);
            --theme-font-size-rem-factor: calc(var(--theme-font-size-coef) / var(--theme-html-font-size));

            --theme-breakpoints-values-xs: {theme.Breakpoints.Values.ExtraSmall.ToString(CultureInfo.InvariantCulture)};
            --theme-breakpoints-values-sm: {theme.Breakpoints.Values.Small.ToString(CultureInfo.InvariantCulture)};
            --theme-breakpoints-values-md: {theme.Breakpoints.Values.Medium.ToString(CultureInfo.InvariantCulture)};
            --theme-breakpoints-values-lg: {theme.Breakpoints.Values.Large.ToString(CultureInfo.InvariantCulture)};
            --theme-breakpoints-values-xl: {theme.Breakpoints.Values.ExtraLarge.ToString(CultureInfo.InvariantCulture)};

            --theme-shadow0: {theme.Shadows[0].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow1: {theme.Shadows[1].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow2: {theme.Shadows[2].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow3: {theme.Shadows[3].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow4: {theme.Shadows[4].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow5: {theme.Shadows[5].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow6: {theme.Shadows[6].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow7: {theme.Shadows[7].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow8: {theme.Shadows[8].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow9: {theme.Shadows[9].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow10: {theme.Shadows[10].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow11: {theme.Shadows[11].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow12: {theme.Shadows[12].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow13: {theme.Shadows[13].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow14: {theme.Shadows[14].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow15: {theme.Shadows[15].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow16: {theme.Shadows[16].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow17: {theme.Shadows[17].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow18: {theme.Shadows[18].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow19: {theme.Shadows[19].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow20: {theme.Shadows[20].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow21: {theme.Shadows[21].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow22: {theme.Shadows[22].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow23: {theme.Shadows[23].ToString(CultureInfo.InvariantCulture)};
            --theme-shadow24: {theme.Shadows[24].ToString(CultureInfo.InvariantCulture)};

            --theme-typography-font-size: var(--theme-font-size);
            --theme-typography-html-font-size: var(--theme-html-font-size);

            --theme-typography-font-family: {typography.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-font-size-medium: {typography.PxToRem(20).ToString(CultureInfo.InvariantCulture)};
            --theme-typography-font-size-normal: {typography.PxToRem(12).ToString(CultureInfo.InvariantCulture)};
            --theme-typography-font-weight-light: {typography.FontWeightLight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-font-weight-regular: {typography.FontWeightRegular.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-font-weight-medium: {typography.FontWeightMedium.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-font-weight-bold: {typography.FontWeightBold.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-body1-font-family: {typography.Body1.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-body1-font-size: {typography.Body1.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-body1-font-weight: {typography.Body1.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-body1-line-height: {typography.Body1.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-body1-letter-spacing: {typography.Body1.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-body2-font-family: {typography.Body2.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-body2-font-size: {typography.Body2.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-body2-font-weight: {typography.Body2.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-body2-line-height: {typography.Body2.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-body2-letter-spacing: {typography.Body2.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-caption-font-family: {typography.Caption.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-caption-font-size: {typography.Caption.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-caption-font-weight: {typography.Caption.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-caption-line-height: {typography.Caption.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-caption-letter-spacing: {typography.Caption.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-h1-font-family: {typography.H1.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h1-font-size: {typography.H1.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h1-font-weight: {typography.H1.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h1-line-height: {typography.H1.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h1-letter-spacing: {typography.H1.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-h2-font-family: {typography.H2.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h2-font-size: {typography.H2.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h2-font-weight: {typography.H2.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h2-line-height: {typography.H2.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h2-letter-spacing: {typography.H2.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-h3-font-family: {typography.H3.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h3-font-size: {typography.H3.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h3-font-weight: {typography.H3.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h3-line-height: {typography.H3.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h3-letter-spacing: {typography.H3.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-h4-font-family: {typography.H4.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h4-font-size: {typography.H4.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h4-font-weight: {typography.H4.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h4-line-height: {typography.H4.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h4-letter-spacing: {typography.H4.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-h5-font-family: {typography.H5.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h5-font-size: {typography.H5.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h5-font-weight: {typography.H5.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h5-line-height: {typography.H5.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h5-letter-spacing: {typography.H5.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-h6-font-family: {typography.H6.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h6-font-size: {typography.H6.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h6-font-weight: {typography.H6.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h6-line-height: {typography.H6.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-h6-letter-spacing: {typography.H6.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-subtitle1-font-family: {typography.Subtitle1.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-subtitle1-font-size: {typography.Subtitle1.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-subtitle1-font-weight: {typography.Subtitle1.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-subtitle1-line-height: {typography.Subtitle1.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-subtitle1-letter-spacing: {typography.Subtitle1.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-subtitle2-font-family: {typography.Subtitle2.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-subtitle2-font-size: {typography.Subtitle2.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-subtitle2-font-weight: {typography.Subtitle2.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-subtitle2-line-height: {typography.Subtitle2.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-subtitle2-letter-spacing: {typography.Subtitle2.LetterSpacing.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-overline-font-family: {typography.Overline.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-overline-font-size: {typography.Overline.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-overline-font-weight: {typography.Overline.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-overline-line-height: {typography.Overline.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-overline-letter-spacing: {typography.Overline.LetterSpacing.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-overline-text-transform: {typography.Overline.TextTransform.ToString(CultureInfo.InvariantCulture)};

            --theme-typography-button-font-family: {typography.Button.FontFamily.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-button-font-size: {typography.Button.FontSize.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-button-font-weight: {typography.Button.FontWeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-button-line-height: {typography.Button.LineHeight.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-button-letter-spacing: {typography.Button.LetterSpacing.ToString(CultureInfo.InvariantCulture)};
            --theme-typography-button-text-transform: {typography.Button.TextTransform.ToString(CultureInfo.InvariantCulture)};
            ");
        }

        public virtual string BuildScheme(ThemeValue theme)
        {
            var palette = theme.Palette;

            string ToContrastText(string color)
            {
                return color.ToContrastText(palette.ContrastThreshold);
            }

            var isDark = theme.IsDark();

            return Wrap($@"
            --theme-mode-dark: {(isDark ? 1 : 0).ToString(CultureInfo.InvariantCulture)};

            --theme-palette-common-background: {(isDark ? palette.Common.White : palette.Common.Black).ToString(CultureInfo.InvariantCulture)};
            {Variables("--theme-palette-common", palette.Common.Custom)}

            --theme-palette-text-primary: {palette.Text.Primary.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-text-secondary: {palette.Text.Secondary.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-text-disabled: {palette.Text.Disabled.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-text-hint: {palette.Text.Hint.ToString(CultureInfo.InvariantCulture)};
            {Variables("--theme-palette-text", palette.Text.Custom)}

            --theme-palette-background-paper: {palette.Background.Paper.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-background-default: {palette.Background.Default.ToString(CultureInfo.InvariantCulture)};
            {Variables("--theme-palette-background", palette.Background.Custom)}

            --theme-palette-action-active: {palette.Action.Active.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-action-hover: {palette.Action.Hover.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-action-hover-opacity: {palette.Action.HoverOpacity.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-action-selected: {palette.Action.Selected.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-action-disabled: {palette.Action.Disabled.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-action-disabled-background: {palette.Action.DisabledBackground.ToString(CultureInfo.InvariantCulture)};
            {Variables("--theme-palette-action", palette.Action.Custom)}

            --theme-palette-primary-main: {palette.Primary.Main.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-primary-light: {palette.Primary.Light.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-primary-dark: {palette.Primary.Dark.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-primary-contrast-text: {palette.Primary.ContrastText.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-primary-alternate: {(isDark ? palette.Primary.Light : palette.Primary.Dark).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-primary-hover: {palette.Primary.Main.Fade(palette.Action.HoverOpacity).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-primary-background: {(isDark ? palette.Primary.Main.Darken(0.5m) : palette.Primary.Main.Lighten(0.62m)).ToString(CultureInfo.InvariantCulture)};
            {Variables("--theme-palette-primary", palette.Primary.Custom)}

            --theme-palette-secondary-main: {palette.Secondary.Main.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-secondary-light: {palette.Secondary.Light.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-secondary-dark: {palette.Secondary.Dark.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-secondary-contrast-text: {palette.Secondary.ContrastText.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-secondary-hover: {palette.Secondary.Main.Fade(palette.Action.HoverOpacity).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-secondary-border: {palette.Secondary.Main.Fade(0.5m).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-secondary-background:  {(isDark ? palette.Secondary.Main.Darken(0.5m) : palette.Secondary.Main.Lighten(0.62m)).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-secondary-alternate: {(isDark ? palette.Secondary.Light : palette.Secondary.Dark).ToString(CultureInfo.InvariantCulture)};
            {Variables("--theme-palette-secondary", palette.Secondary.Custom)}

            --theme-palette-error-main: {palette.Error.Main.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-error-light: {palette.Error.Light.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-error-dark: {palette.Error.Dark.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-error-contrast-text: {palette.Error.ContrastText.ToString(CultureInfo.InvariantCulture)};
            {Variables("--theme-palette-error", palette.Error.Custom)}

            --theme-palette-divider: {palette.Divider.ToString(CultureInfo.InvariantCulture)};

            --theme-palette-grey50: {palette.Grey.X50.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey50-contrast-text: {ToContrastText(palette.Grey.X50).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey100: {palette.Grey.X100.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey100-contrast-text: {ToContrastText(palette.Grey.X100).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey200: {palette.Grey.X200.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey200-contrast-text: {ToContrastText(palette.Grey.X200).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey300: {palette.Grey.X300.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey300-contrast-text: {ToContrastText(palette.Grey.X300).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey400: {palette.Grey.X400.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey400-contrast-text: {ToContrastText(palette.Grey.X400).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey500: {palette.Grey.X500.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey500-contrast-text: {ToContrastText(palette.Grey.X500).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey600: {palette.Grey.X600.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey600-contrast-text: {ToContrastText(palette.Grey.X600).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey700: {palette.Grey.X700.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey700-contrast-text: {ToContrastText(palette.Grey.X700).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey800: {palette.Grey.X800.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey800-contrast-text: {ToContrastText(palette.Grey.X800).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey900: {palette.Grey.X900.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey900-contrast-text: {ToContrastText(palette.Grey.X900).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-greyA100: {palette.Grey.A100.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-greyA100-contrast-text: {ToContrastText(palette.Grey.A100).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-greyA200: {palette.Grey.A200.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-greyA200-contrast-text: {ToContrastText(palette.Grey.A200).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-greyA400: {palette.Grey.A400.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-greyA400-contrast-text: {ToContrastText(palette.Grey.A400).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-greyA700: {palette.Grey.A700.ToString(CultureInfo.InvariantCulture)};
            --theme-palette-greyA700-contrast-text: {ToContrastText(palette.Grey.A700).ToString(CultureInfo.InvariantCulture)};

            --theme-palette-grey-contrast-text-default: {ToContrastText(isDark ? palette.Grey.X900 : palette.Grey.X100).ToString(CultureInfo.InvariantCulture)};
            --theme-palette-grey-background-default: {(isDark ? palette.Grey.X900 : palette.Grey.X100).ToString(CultureInfo.InvariantCulture)};

            --theme-custom-light-or-dark: {palette.Custom.LightOrDark.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-light-or-dark-contrast-text: {palette.Custom.LightOrDarkContrastText.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-content-background-color: {palette.Custom.ContentBackground.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-content-background-default: {palette.Custom.ContentBackgroundDefault.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-palette-common-alternate: {palette.Custom.PaletteCommonAlternate.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-palette-opacity: {palette.Custom.PaletteOpacity.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-layout-backward: {palette.Custom.LayoutBackward.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-layout-forward: {palette.Custom.LayoutForward.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-palette-primary-main: {palette.Custom.PrimaryMain.ToString(CultureInfo.InvariantCulture)};
            --theme-custom-palette-primary-contrast-text: {palette.Custom.PrimaryContrastText.ToString(CultureInfo.InvariantCulture)};

            {Styles(theme)}
          ");
        }

        protected virtual string Variables(string prefix, IDictionary<string, string> values)
        {
            var variables = values.Select(value => $"{prefix}-custom-{value.Key}: {value.Value.ToString(CultureInfo.InvariantCulture)};");

            return string.Join("\n", variables);
        }

        protected virtual string Styles(ThemeValue theme)
        {
            var variables = StyleProducers.SelectMany(producer => producer.Variables(theme));

            var styles = variables.Select(variable => $"{variable.Key}: {variable.Value.ToString(CultureInfo.InvariantCulture)};");

            return string.Join("\n", styles);
        }
    }
}