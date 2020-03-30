namespace Skclusive.Material.Theme
{
    public class ThemeConfig
    {
        public string Name { set; get; }

        public string Spacing { set; get; }

        public string ShapeBorderRadius { set; get; }

        public string TransitionBoxShadow { set; get; }

        public string FontSize { set; get; }

        public string HtmlFontSize { set; get; }

        public string ZindexAppBar { set; get; }

        public string ZindexDrawer { set; get; }

        public string Shadow0 { set; get; }

        public string Shadow1 { set; get; }

        public string Shadow2 { set; get; }

        public string Shadow3 { set; get; }

        public string Shadow4 { set; get; }

        public string Shadow5 { set; get; }

        public string Shadow6 { set; get; }

        public string Shadow7 { set; get; }

        public string Shadow8 { set; get; }

        public string Shadow9 { set; get; }

        public string Shadow10 { set; get; }

        public string Shadow11 { set; get; }

        public string Shadow12 { set; get; }

        public string Shadow13 { set; get; }

        public string Shadow14 { set; get; }

        public string Shadow15 { set; get; }

        public string Shadow16 { set; get; }

        public string Shadow17 { set; get; }

        public string Shadow18 { set; get; }

        public string Shadow19 { set; get; }

        public string Shadow20 { set; get; }

        public string Shadow21 { set; get; }

        public string Shadow22 { set; get; }

        public string Shadow23 { set; get; }

        public string Shadow24 { set; get; }

        public bool IsDark { set; get; }

        public TypographyConfigs Typography { set; get; }

        public PaletteConfig Palette { set; get; }
    }

    public class TypographyConfig
    {
        public string FontSize { set; get; }

        public string FontFamily { set; get; }

        public string FontWeight { set; get; }

        public string LineHeight { set; get; }

        public string LetterSpacing { set; get; }

        public string TextTransform { set; get; }
    }

    public class TypographyConfigs
    {
        public string FontFamily { set; get; }

        public string FontSizeMedium { set; get; }

        public string FontSizeNormal { set; get; }

        public string FontWeightLight { set; get; }

        public string FontWeightRegular { set; get; }

        public string FontWeightMedium { set; get; }

        public string FontWeightBold { set; get; }

        public TypographyConfig Button { set; get; }

        public TypographyConfig Overline { set; get; }

        public TypographyConfig Subtitle1 { set; get; }

        public TypographyConfig Subtitle2 { set; get; }

        public TypographyConfig Caption { set; get; }

        public TypographyConfig Body1 { set; get; }

        public TypographyConfig Body2 { set; get; }

        public TypographyConfig H1 { set; get; }

        public TypographyConfig H2 { set; get; }

        public TypographyConfig H3 { set; get; }

        public TypographyConfig H4 { set; get; }

        public TypographyConfig H5 { set; get; }

        public TypographyConfig H6 { set; get; }
    }

    public class PaletteConfig
    {
        public CommonConfig Common { set; get; }

        public MainConfig Main { set; get; }

        public PrimaryConfig Primary { set; get; }

        public SecondaryConfig Secondary { set; get; }

        public ColorConfig Error { set; get; }

        public ColorConfig Warning { set; get; }

        public ColorConfig Info { set; get; }

        public ColorConfig Success { set; get; }

        public SwitchConfig Switch { set; get; }

        public TextConfig Text { set; get; }

        public BackgroundConfig Background { set; get; }

        public ActionConfig Action { set; get; }

        public DividerConfig Divider { set; get; }

        public BorderConfig Border { set; get; }

        public TableConfig Table { set; get; }

        public GreyConfig Grey { set; get; }

        public CustomConfig Custom { set; get; }
    }

    public class CommonConfig
    {
        public string Color { set; get; }

        public string White { set; get; }

        public string Black { set; get; }

        public string Background { set; get; }
    }

    public class SwitchConfig
    {
        public string Color { set; get; }

        public string DisabledColor { set; get; }

        public string DisabledOpacity { set; get; }
    }

    public class TextConfig
    {
        public string Color { set; get; }

        public string Primary { set; get; }

        public string PrimaryHover { set; get; }

        public string Disabled { set; get; }

        public string Secondary { set; get; }

        public string Hint { set; get; }
    }

    public class BackgroundConfig
    {
        public string Paper { set; get; }

        public string Default { set; get; }

        public string Level1 { set; get; }

        public string Level2 { set; get; }
    }

    public class ActionConfig
    {
        public string Active { set; get; }

        public string Hover { set; get; }

        public string HoverOpacity { set; get; }

        public string Selected { set; get; }

        public string Disabled { set; get; }

        public string DisabledBackground { set; get; }
    }

    public class ColorConfig
    {
        public string Main { set; get; }

        public string Light { set; get; }

        public string Dark { set; get; }

        public string ContrastText { set; get; }
    }

    public class PrimaryConfig : ColorConfig
    {
        public string Alternate { set; get; }

        public string Current { set; get; }

        public string MainHover { set; get; }

        public string MainBorder { set; get; }

        public string MainBackground { set; get; }
    }

    public class SecondaryConfig : ColorConfig
    {
        public string Current { set; get; }

        public string MainHover { set; get; }

        public string MainBorder { set; get; }

        public string MainBackground { set; get; }
    }

    public class DividerConfig
    {
        public string Color { set; get; }

        public string Background { set; get; }

        public string BorderBottom { set; get; }
    }

    public class BorderConfig
    {
        public string Outlined { set; get; }

        public string Bottom { set; get; }
    }

    public class MainConfig
    {
        public string Background { set; get; }
    }

    public class TableConfig
    {
        public string RowSelected { set; get; }

        public string RowHover { set; get; }
    }

    public class GreyConfig
    {
        public string C300 { set; get; }

        public string C50 { set; get; }

        public string A100 { set; get; }

        public string ContrastTextC300 { set; get; }

        public string Background { set; get; }

        public string Color { set; get; }

        public string LightOrDark { set; get; }

        public string LightOrDarkContrastText { set; get; }
    }

    public class CustomConfig
    {
        public string PrimaryMain { set; get; }

        public string PrimaryContrastText { set; get; }

        public string ContentBackground { set; get; }

        public string ContentBackgroundDefault { set; get; }

        public string PaletteCommonAlternate { set; get; }

        public string PaletteOpacity { set; get; }

        public string LayoutBackward { set; get; }

        public string LayoutForward { set; get; }
    }
}