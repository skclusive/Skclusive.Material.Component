namespace Skclusive.Material.Theme
{
    public class ThemeBuilder
    {
        public static readonly ThemeConfig COMMON = BuildCommon();

        public static readonly ThemeConfig LIGHT = BuildLight();

        public static readonly ThemeConfig DARK = BuildDark();

        public static ThemeConfig BuildCommon()
        {
            var fontFamily = @"""Roboto"", ""Helvetica"", ""Arial"", sans-serif";

            return new ThemeConfig
            {
                Name = "ThemeCommon",

                FontSize = "14",

                HtmlFontSize = "16",

                Spacing = "8",

                ShapeBorderRadius = "4",

                TransitionBoxShadow = "box-shadow 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms",

                ZindexAppBar = "1100",

                ZindexDrawer = "1200",

                Shadow0 = "none",

                Shadow1 = "0px 2px 1px -1px rgba(0, 0, 0, 0.2), 0px 1px 1px 0px rgba(0, 0, 0, 0.14), 0px 1px 3px 0px rgba(0, 0, 0, 0.12)",

                Shadow2 = "0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12)",

                Shadow3 = "0px 3px 3px -2px rgba(0, 0, 0, 0.2), 0px 3px 4px 0px rgba(0, 0, 0, 0.14), 0px 1px 8px 0px rgba(0, 0, 0, 0.12)",

                Shadow4 = "0px 2px 4px -1px rgba(0, 0, 0, 0.2), 0px 4px 5px 0px rgba(0, 0, 0, 0.14), 0px 1px 10px 0px rgba(0, 0, 0, 0.12)",

                Shadow5 = "0px 3px 5px -1px rgba(0, 0, 0, 0.2), 0px 5px 8px 0px rgba(0, 0, 0, 0.14), 0px 1px 14px 0px rgba(0, 0, 0, 0.12)",

                Shadow6 = "0px 3px 5px -1px rgba(0, 0, 0, 0.2), 0px 6px 10px 0px rgba(0, 0, 0, 0.14), 0px 1px 18px 0px rgba(0, 0, 0, 0.12)",

                Shadow7 = "0px 4px 5px -2px rgba(0, 0, 0, 0.2), 0px 7px 10px 1px rgba(0, 0, 0, 0.14), 0px 2px 16px 1px rgba(0, 0, 0, 0.12)",

                Shadow8 = "0px 5px 5px -3px rgba(0, 0, 0, 0.2), 0px 8px 10px 1px rgba(0, 0, 0, 0.14), 0px 3px 14px 2px rgba(0, 0, 0, 0.12)",

                Shadow9 = "0px 5px 6px -3px rgba(0, 0, 0, 0.2), 0px 9px 12px 1px rgba(0, 0, 0, 0.14), 0px 3px 16px 2px rgba(0, 0, 0, 0.12)",

                Shadow10 = "0px 6px 6px -3px rgba(0, 0, 0, 0.2), 0px 10px 14px 1px rgba(0, 0, 0, 0.14), 0px 4px 18px 3px rgba(0, 0, 0, 0.12)",

                Shadow11 = "0px 6px 7px -4px rgba(0, 0, 0, 0.2), 0px 11px 15px 1px rgba(0, 0, 0, 0.14), 0px 4px 20px 3px rgba(0, 0, 0, 0.12)",

                Shadow12 = "0px 7px 8px -4px rgba(0, 0, 0, 0.2), 0px 12px 17px 2px rgba(0, 0, 0, 0.14), 0px 5px 22px 4px rgba(0, 0, 0, 0.12)",

                Shadow13 = "0px 7px 8px -4px rgba(0, 0, 0, 0.2), 0px 13px 19px 2px rgba(0, 0, 0, 0.14), 0px 5px 24px 4px rgba(0, 0, 0, 0.12)",

                Shadow14 = "0px 7px 9px -4px rgba(0, 0, 0, 0.2), 0px 14px 21px 2px rgba(0, 0, 0, 0.14), 0px 5px 26px 4px rgba(0, 0, 0, 0.12)",

                Shadow15 = "0px 8px 9px -5px rgba(0, 0, 0, 0.2), 0px 15px 22px 2px rgba(0, 0, 0, 0.14), 0px 6px 28px 5px rgba(0, 0, 0, 0.12)",

                Shadow16 = "0px 8px 10px -5px rgba(0, 0, 0, 0.2), 0px 16px 24px 2px rgba(0, 0, 0, 0.14), 0px 6px 30px 5px rgba(0, 0, 0, 0.12)",

                Shadow17 = "0px 8px 11px -5px rgba(0, 0, 0, 0.2), 0px 17px 26px 2px rgba(0, 0, 0, 0.14), 0px 6px 32px 5px rgba(0, 0, 0, 0.12)",

                Shadow18 = "0px 9px 11px -5px rgba(0, 0, 0, 0.2), 0px 18px 28px 2px rgba(0, 0, 0, 0.14), 0px 7px 34px 6px rgba(0, 0, 0, 0.12)",

                Shadow19 = "0px 9px 12px -6px rgba(0, 0, 0, 0.2), 0px 19px 29px 2px rgba(0, 0, 0, 0.14), 0px 7px 36px 6px rgba(0, 0, 0, 0.12)",

                Shadow20 = "0px 10px 13px -6px rgba(0, 0, 0, 0.2), 0px 20px 31px 3px rgba(0, 0, 0, 0.14), 0px 8px 38px 7px rgba(0, 0, 0, 0.12)",

                Shadow21 = "0px 10px 13px -6px rgba(0, 0, 0, 0.2), 0px 21px 33px 3px rgba(0, 0, 0, 0.14), 0px 8px 40px 7px rgba(0, 0, 0, 0.12)",

                Shadow22 = "0px 10px 14px -6px rgba(0, 0, 0, 0.2), 0px 22px 35px 3px rgba(0, 0, 0, 0.14), 0px 8px 42px 7px rgba(0, 0, 0, 0.12)",

                Shadow23 = "0px 11px 14px -7px rgba(0, 0, 0, 0.2), 0px 23px 36px 3px rgba(0, 0, 0, 0.14), 0px 9px 44px 8px rgba(0, 0, 0, 0.12)",

                Shadow24 = "0px 11px 15px -7px rgba(0, 0, 0, 0.2), 0px 24px 38px 3px rgba(0, 0, 0, 0.14), 0px 9px 46px 8px rgba(0, 0, 0, 0.12)",

                Typography = new TypographyConfigs
                {
                    FontFamily = fontFamily,

                    FontSizeMedium = "1.25rem",

                    FontSizeNormal = "0.75rem",

                    FontWeightLight = "300",

                    FontWeightRegular = "400",

                    FontWeightMedium = "500",

                    FontWeightBold = "700",

                    Body1 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "1rem",

                        FontWeight = "400",

                        LineHeight = "1.5",

                        LetterSpacing = "0.00938em"
                    },

                    Body2 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "0.875rem",

                        FontWeight = "400",

                        LineHeight = "1.43",

                        LetterSpacing = "0.01071em"
                    },

                    Caption = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "0.75rem",

                        FontWeight = "400",

                        LineHeight = "1.66",

                        LetterSpacing = "0.03333em"
                    },

                    H1 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "6rem",

                        FontWeight = "300",

                        LineHeight = "1",

                        LetterSpacing = "-0.01562em"
                    },

                    H2 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "3.75rem",

                        FontWeight = "300",

                        LineHeight = "1",

                        LetterSpacing = "-0.00833em"
                    },

                    H3 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "3rem",

                        FontWeight = "400",

                        LineHeight = "1.04",

                        LetterSpacing = "0em"
                    },

                    H4 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "2.125rem",

                        FontWeight = "400",

                        LineHeight = "1.17",

                        LetterSpacing = "0.00735em"
                    },

                    H5 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "1.5rem",

                        FontWeight = "400",

                        LineHeight = "1.33",

                        LetterSpacing = "00em"
                    },

                    H6 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "1.25rem",

                        FontWeight = "500",

                        LineHeight = "1.6",

                        LetterSpacing = "0.0075em"
                    },

                    Subtitle1 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "1rem",

                        FontWeight = "400",

                        LineHeight = "1.75",

                        LetterSpacing = "0.00938em"
                    },

                    Subtitle2 = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "0.875rem",

                        FontWeight = "500",

                        LineHeight = "1.57",

                        LetterSpacing = "0.00714em"
                    },

                    Overline = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "0.75rem",

                        FontWeight = "400",

                        LineHeight = "2.66",

                        LetterSpacing = "0.08333em",

                        TextTransform = "uppercase"
                    },

                    Button = new TypographyConfig
                    {
                        FontFamily = fontFamily,

                        FontSize = "0.875rem",

                        FontWeight = "500",

                        LineHeight = "1.75",

                        LetterSpacing = "0.02857em",

                        TextTransform = "uppercase"
                    }
                },

                Palette = new PaletteConfig
                {
                    Common = new CommonConfig
                    {
                        White = "#fff",

                        Black = "#000",

                        Color = "''", /* need to find */
                    }
                }
            };
        }

        public static ThemeConfig BuildLight()
        {
            var theme = BuildCommon();

            theme.IsDark = false;

            theme.Name = "ThemeLight";

            theme.Palette = new PaletteConfig
            {
                Common = new CommonConfig
                {
                    White = "#fff",

                    Black = "#000",

                    Color = "''", /* need to find */

                    Background = "#000"
                },

                Main = new MainConfig
                {
                    Background = "#fff"
                },

                Switch = new SwitchConfig
                {
                    Color = "#fafafa",  /*--theme-palette-grey-50*/

                    DisabledColor = "#bdbdbd",  /*--theme-palette-grey-400*/

                    DisabledOpacity = "0.12"
                },

                Text = new TextConfig
                {
                    Color = "''", /* need to find */

                    Primary = "rgba(0, 0, 0, 0.87)",

                    PrimaryHover = "rgba(0, 0, 0, 0.08)",

                    Secondary = "rgba(0, 0, 0, 0.54)",

                    Disabled = "rgba(0, 0, 0, 0.38)",

                    Hint = "rgba(0, 0, 0, 0.38)"
                },

                Background = new BackgroundConfig
                {
                    Paper = "#fff",

                    Default = "#fff",

                    Level1 = "#fff",

                    Level2 = "#f5f5f5"
                },

                Action = new ActionConfig
                {
                    Active = "rgba(0, 0, 0, 0.54)",

                    Hover = "rgba(0, 0, 0, 0.08)",

                    HoverOpacity = "0.08",

                    Selected = "rgba(0, 0, 0, 0.14)",

                    Disabled = "rgba(0, 0, 0, 0.26)",

                    DisabledBackground = "rgba(0, 0, 0, 0.12)"
                },

                Primary = new PrimaryConfig
                {
                    Main = "#1976d2",

                    Light = "rgb(71, 145, 219)",

                    Dark = "rgb(17, 82, 147)",

                    ContrastText = "#fff",

                    Alternate = "rgb(17, 82, 147)",

                    Current = "rgb(17, 82, 147)",

                    MainHover = "rgba(25, 118, 210, 0.08)",

                    MainBorder = "rgba(25, 118, 210, 0.5)",

                    MainBackground = "rgb(167, 202, 237)"
                },

                Secondary = new SecondaryConfig
                {
                    Main = "rgb(220, 0, 78)",

                    Light = "rgb(227, 51, 113)",

                    Dark = "rgb(154, 0, 54)",

                    Current = "rgb(154, 0, 54)",  /* need to find */

                    MainHover = "rgba(220, 0, 78, 0.08)",

                    MainBorder = "rgba(220, 0, 78, 0.5)",

                    MainBackground = "rgb(241, 158, 187)",

                    ContrastText = "#fff"
                },

                Error = new ColorConfig
                {
                    Light = "#e57373",

                    Main = "#f44336",

                    Dark = "#d32f2f",

                    ContrastText = "#fff"
                },

                Warning = new ColorConfig
                {
                    Light = "#ffb74d",

                    Main = "#ff9800",

                    Dark = "#f57c00",

                    ContrastText = "rgba(0, 0, 0, 0.87)"
                },

                Info = new ColorConfig
                {
                    Light = "#64b5f6",

                    Main = "#2196f3",

                    Dark = "#1976d2",

                    ContrastText = "#fff"
                },

                Success = new ColorConfig
                {
                    Light = "#81c784",

                    Main = "#4caf50",

                    Dark = "#388e3c",

                    ContrastText = "rgba(0, 0, 0, 0.87)"
                },

                Divider = new DividerConfig
                {
                    Color = "rgba(0, 0, 0, 0.12)",

                    Background = "rgba(0, 0, 0, 0.08)",

                    BorderBottom = "rgba(224, 224, 224, 1)"
                },

                Border = new BorderConfig
                {
                    Outlined = "rgba(0, 0, 0, 0.23)",

                    Bottom = "rgba(0, 0, 0, 0.42)"
                },

                Table = new TableConfig
                {
                    RowHover = "rgba(0, 0, 0, 0.07)",

                    RowSelected = "rgba(0, 0, 0, 0.04)"
                },

                Grey = new GreyConfig
                {
                    C300 = "#e0e0e0",  /* need to find */

                    C50 = "#fafafa",  /* need to find */

                    A100 = "#d5d5d5",  /* need to find */

                    ContrastTextC300 = "rgba(0, 0, 0, 0.87)",   /* need to find */

                    Background = "#f5f5f5",

                    Color = "#bdbdbd",

                    LightOrDark = "#e0e0e0",

                    LightOrDarkContrastText = "rgba(0, 0, 0, 0.87)"
                },

                Custom = new CustomConfig
                {
                    ContentBackground = "#f4f6f8",

                    ContentBackgroundDefault = "#f5f5f5",

                    PaletteOpacity = "0.38",

                    PaletteCommonAlternate = "#000",

                    LayoutBackward = "#f5f5f5",

                    LayoutForward = "#fff",

                    PrimaryMain = "#1976d2",

                    PrimaryContrastText = "#fff"
                }
            };

            return theme;
        }

        public static ThemeConfig BuildDark()
        {
            var theme = BuildCommon();

            theme.IsDark = true;

            theme.Name = "ThemeDark";

            theme.Palette = new PaletteConfig
            {
                Common = new CommonConfig
                {
                    White = "#fff",

                    Black = "#000",

                    Color = "''", /* need to find */

                    Background = "#fff"
                },

                Main = new MainConfig
                {
                    Background = "#212121"
                },

                Switch = new SwitchConfig
                {
                    Color = "#bdbdbd",  /*--theme-palette-grey-400*/

                    DisabledColor = "#424242",  /*--theme-palette-grey-800*/

                    DisabledOpacity = "0.1"
                },

                Text = new TextConfig
                {
                    Color = "''", /* need to find */

                    Primary = "#fff",

                    PrimaryHover = "rgba(255, 255, 255, 0.1)",

                    Secondary = "rgba(255, 255, 255, 0.7)",

                    Disabled = "rgba(255, 255, 255, 0.5)",

                    Hint = "rgba(255, 255, 255, 0.5)"
                },

                Background = new BackgroundConfig
                {
                    Paper = "#424242",

                    Default = "#121212", // or "#303030"?

                    Level1 = "#212121",

                    Level2 = "#333"
                },

                Action = new ActionConfig
                {
                    Active = "#fff",

                    Hover = "rgba(255, 255, 255, 0.1)",

                    HoverOpacity = "0.1",

                    Selected = "rgba(255, 255, 255, 0.2)",

                    Disabled = "rgba(255, 255, 255, 0.3)",

                    DisabledBackground = "rgba(255, 255, 255, 0.12)"
                },

                Primary = new PrimaryConfig
                {
                    Main = "#90caf9",

                    Light = "rgb(166, 212, 250)",

                    Dark = "rgb(100, 141, 174)",

                    ContrastText = "rgba(0, 0, 0, 0.87)",

                    Alternate = "rgb(166, 212, 250)",

                    Current = "rgb(100, 141, 174)",

                    MainHover = "rgba(144, 202, 249, 0.1)",

                    MainBorder = "rgba(144, 202, 249, 0.5)",

                    MainBackground = "rgb(72, 101, 124)"
                },

                Secondary = new SecondaryConfig
                {
                    Main = "#f48fb1",

                    Light = "rgb(246, 165, 192)",

                    Dark = "rgb(170, 100, 123)",

                    ContrastText = "rgba(0, 0, 0, 0.87)",

                    MainHover = "rgba(244, 143, 177, 0.1)",

                    MainBorder = "rgba(244, 143, 177, 0.5)",

                    MainBackground = "rgb(122, 71, 88)",

                    Current = "rgb(154, 0, 54)"  /* need to find */
                },

                Error = new ColorConfig
                {
                    Light = "#e57373",

                    Main = "#f44336",

                    Dark = "#d32f2f",

                    ContrastText = "#fff"
                },

                Warning = new ColorConfig
                {
                    Light = "#ffb74d",

                    Main = "#ff9800",

                    Dark = "#f57c00",

                    ContrastText = "rgba(0, 0, 0, 0.87)"
                },

                Info = new ColorConfig
                {
                    Light = "#64b5f6",

                    Main = "#2196f3",

                    Dark = "#1976d2",

                    ContrastText = "#fff"
                },

                Success = new ColorConfig
                {
                    Light = "#81c784",

                    Main = "#4caf50",

                    Dark = "#388e3c",

                    ContrastText = "rgba(0, 0, 0, 0.87)"
                },

                Divider = new DividerConfig
                {
                    Color = "rgba(255, 255, 255, 0.12)",

                    Background = "rgba(255, 255, 255, 0.08)",

                    BorderBottom = "rgba(81, 81, 81, 1)"
                },

                Border = new BorderConfig
                {
                    Outlined = "rgba(255, 255, 255, 0.23)",

                    Bottom = "rgba(255, 255, 255, 0.7)"
                },

                Table = new TableConfig
                {
                    RowHover = "rgba(255, 255, 255, 0.14)",

                    RowSelected = "rgba(255, 255, 255, 0.08)"
                },

                Grey = new GreyConfig
                {
                    C300 = "#e0e0e0",

                    C50 = "#fafafa",

                    A100 = "#d5d5d5",

                    ContrastTextC300 = "rgba(0, 0, 0, 0.87)",

                    Background = "#212121",

                    Color = "#757575",

                    LightOrDark = "#616161",

                    LightOrDarkContrastText = "#fff"
                },

                Custom = new CustomConfig
                {
                    ContentBackground = "rgb(18, 18, 18)",

                    ContentBackgroundDefault = "#333",

                    PaletteOpacity = "0.3",

                    PaletteCommonAlternate = "#fff",

                    LayoutBackward = "#333",

                    LayoutForward = "#424242",

                    PrimaryMain = "#333",

                    PrimaryContrastText = "#fff"
                }
            };

            return theme;
        }
    }
}