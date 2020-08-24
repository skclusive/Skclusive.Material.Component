using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class TypographyConfig
    {
        [JsonPropertyName("htmlFontSize")]
        public short? HtmlFontSize { get; set; }

        [JsonPropertyName("fontFamily")]
        public string FontFamily { get; set; }

        [JsonPropertyName("fontSize")]
        public short? FontSize { get; set; }

        [JsonPropertyName("fontWeightLight")]
        public short? FontWeightLight { get; set; }

        [JsonPropertyName("fontWeightRegular")]
        public short? FontWeightRegular { get; set; }

        [JsonPropertyName("fontWeightMedium")]
        public short? FontWeightMedium { get; set; }

        [JsonPropertyName("fontWeightBold")]
        public short? FontWeightBold { get; set; }

        [JsonPropertyName("h1")]
        public TypographySegmentConfig H1 { get; set; }

        [JsonPropertyName("h2")]
        public TypographySegmentConfig H2 { get; set; }

        [JsonPropertyName("h3")]
        public TypographySegmentConfig H3 { get; set; }

        [JsonPropertyName("h4")]
        public TypographySegmentConfig H4 { get; set; }

        [JsonPropertyName("h5")]
        public TypographySegmentConfig H5 { get; set; }

        [JsonPropertyName("h6")]
        public TypographySegmentConfig H6 { get; set; }

        [JsonPropertyName("subtitle1")]
        public TypographySegmentConfig Subtitle1 { get; set; }

        [JsonPropertyName("subtitle2")]
        public TypographySegmentConfig Subtitle2 { get; set; }

        [JsonPropertyName("body1")]
        public TypographySegmentConfig Body1 { get; set; }

        [JsonPropertyName("body2")]
        public TypographySegmentConfig Body2 { get; set; }

        [JsonPropertyName("button")]
        public TypographySegmentConfig Button { get; set; }

        [JsonPropertyName("caption")]
        public TypographySegmentConfig Caption { get; set; }

        [JsonPropertyName("overline")]
        public TypographySegmentConfig Overline { get; set; }

        // [JsonPropertyName("allVariants")]
        // public TypographySegmentConfig AllVariants { get; set; }

        [JsonIgnore]
        public Func<short, string> PxToRem { get; set; }
    }
}