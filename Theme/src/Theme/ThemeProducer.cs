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

        public static string BuildMediaScheme(ThemeConfig theme)
        {
            var scheme = theme.IsDark ? "dark" : "light";

            return @$"@media (prefers-color-scheme: {scheme}) {{
                {BuildScheme(theme)}
            }}";
        }

        public static string BuildCommon(ThemeConfig theme)
        {
            var palette = theme.Palette;

            var typography = theme.Typography;

            return  Wrap(@$"
            --theme-palette-common-white: {palette.Common.White};
            --theme-palette-common-black: {palette.Common.Black};

            --theme-spacing: {theme.Spacing};
            --theme-shape-border-radius: {theme.ShapeBorderRadius};
            --theme-transition-box-shadow: {theme.TransitionBoxShadow};

            --theme-font-size: {theme.FontSize};
            --theme-html-font-size: {theme.HtmlFontSize};
            --theme-zindex-appbar: {theme.ZindexAppBar};
            --theme-zindex-drawer: {theme.ZindexDrawer};
            --theme-font-size-coef: calc(var(--theme-font-size) / 14);
            --theme-font-size-rem-factor: calc(
                var(--theme-font-size-coef) / var(--theme-html-font-size)
            );

            --theme-shadow0: {theme.Shadow0};
            --theme-shadow1: {theme.Shadow1};
            --theme-shadow2: {theme.Shadow2};
            --theme-shadow3: {theme.Shadow3};
            --theme-shadow4: {theme.Shadow4};
            --theme-shadow5: {theme.Shadow5};
            --theme-shadow6: {theme.Shadow6};
            --theme-shadow7: {theme.Shadow7};
            --theme-shadow8: {theme.Shadow8};
            --theme-shadow9: {theme.Shadow9};
            --theme-shadow10: {theme.Shadow10};
            --theme-shadow11: {theme.Shadow11};
            --theme-shadow12: {theme.Shadow12};
            --theme-shadow13: {theme.Shadow13};
            --theme-shadow14: {theme.Shadow14};
            --theme-shadow15: {theme.Shadow15};
            --theme-shadow16: {theme.Shadow16};
            --theme-shadow17: {theme.Shadow17};
            --theme-shadow18: {theme.Shadow18};
            --theme-shadow19: {theme.Shadow19};
            --theme-shadow20: {theme.Shadow20};
            --theme-shadow21: {theme.Shadow21};
            --theme-shadow22: {theme.Shadow22};
            --theme-shadow23: {theme.Shadow23};
            --theme-shadow24: {theme.Shadow24};

            --theme-typography-font-size: var(--theme-font-size);
            --theme-typography-html-font-size: var(--theme-html-font-size);

            --theme-typography-font-family: {typography.FontFamily};
            --theme-typography-font-size-medium: {typography.FontSizeMedium};
            --theme-typography-font-size-normal: {typography.FontSizeNormal};
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

        public static string BuildScheme(ThemeConfig theme)
        {
            var palette = theme.Palette;

            return  Wrap(@$"
            --theme-mode-dark: {(theme.IsDark ? 1 : 0)};

            --theme-palette-color: {palette.Common.Color};
            --theme-palette-common-background: {palette.Common.Background};

            --theme-palette-main-background-default: {palette.Main.Background};

            --theme-palette-switch-color: {palette.Switch.Color};
            --theme-palette-switch-disabled-color: {palette.Switch.DisabledColor};
            --theme-palette-switch-disabled-opacity: {palette.Switch.DisabledOpacity};

            --theme-palette-text-color: {palette.Text.Color};
            --theme-palette-text-primary: {palette.Text.Primary};
            --theme-palette-text-primary-hover: {palette.Text.PrimaryHover};
            --theme-palette-text-secondary: {palette.Text.Secondary};
            --theme-palette-text-disabled: {palette.Text.Disabled};
            --theme-palette-text-hint: {palette.Text.Hint};

            --theme-palette-background-paper: {palette.Background.Paper};
            --theme-palette-background-default: {palette.Background.Default};
            --theme-palette-background-level1: {palette.Background.Level1};
            --theme-palette-background-level2: {palette.Background.Level2};

            --theme-palette-action-active: {palette.Action.Active};
            --theme-palette-action-hover: {palette.Action.Hover};
            --theme-palette-action-hover-opacity: {palette.Action.HoverOpacity};
            --theme-palette-action-selected: {palette.Action.Selected};
            --theme-palette-action-disabled: {palette.Action.Disabled};
            --theme-palette-action-disabled-background: {palette.Action.DisabledBackground};

            --theme-palette-primary-main: {palette.Primary.Main};
            --theme-palette-primary-light: {palette.Primary.Light};
            --theme-palette-primary-dark: {palette.Primary.Dark};
            --theme-palette-primary-contrast-text: {palette.Primary.ContrastText};
            --theme-palette-primary-alternate: {palette.Primary.Alternate};
            --theme-palette-primary-current: {palette.Primary.Current};
            --theme-palette-primary-main-hover: {palette.Primary.MainHover};
            --theme-palette-primary-main-border: {palette.Primary.MainBorder};
            --theme-palette-primary-main-background: {palette.Primary.MainBackground};

            --theme-palette-secondary-main: {palette.Secondary.Main};
            --theme-palette-secondary-light: {palette.Secondary.Light};
            --theme-palette-secondary-dark: {palette.Secondary.Dark};
            --theme-palette-secondary-contrast-text: {palette.Secondary.ContrastText};
            --theme-palette-secondary-main-hover: {palette.Secondary.MainHover};
            --theme-palette-secondary-main-border: {palette.Secondary.MainBorder};
            --theme-palette-secondary-main-background: {palette.Secondary.MainBackground};
            --theme-palette-secondary-current: {palette.Secondary.Current};

            --theme-palette-error-main: {palette.Error.Main};
            --theme-palette-error-light: {palette.Error.Light};
            --theme-palette-error-dark: {palette.Error.Dark};
            --theme-palette-error-contrast-text: {palette.Error.ContrastText};

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

            --theme-palette-divider: {palette.Divider.Color};
            --theme-palette-divider-background-color: {palette.Divider.Background};
            --theme-palette-divider-border-bottom: {palette.Divider.BorderBottom};

            --theme-palette-border-outlined: {palette.Border.Outlined};
            --theme-palette-border-bottom: {palette.Border.Bottom};

            --theme-palette-table-row-background-selected: {palette.Table.RowSelected};
            --theme-palette-table-row-background-hover: {palette.Table.RowHover};

            --theme-palette-grey300: {palette.Grey.C300};
            --theme-palette-grey-50: {palette.Grey.C50};
            --theme-palette-grey-A100: {palette.Grey.A100};
            --theme-palette-grey300-contrast-text: {palette.Grey.ContrastTextC300};
            --theme-palette-grey-background-default: {palette.Grey.Background};
            --theme-palette-grey: {palette.Grey.Color};
            --theme-palette-grey-light-or-dark: {palette.Grey.LightOrDark};
            --theme-palette-grey-light-or-dark-contrast-text: {palette.Grey.LightOrDarkContrastText};

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
    }
}