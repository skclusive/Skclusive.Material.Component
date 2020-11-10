using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class Typography
    {
        [JsonPropertyName("htmlFontSize")]
        public short HtmlFontSize { get; set; }

        [JsonPropertyName("fontFamily")]
        public string FontFamily { get; set; }

        [JsonPropertyName("fontSize")]
        public short FontSize { get; set; }

        [JsonPropertyName("fontWeightLight")]
        public short FontWeightLight { get; set; }

        [JsonPropertyName("fontWeightRegular")]
        public short FontWeightRegular { get; set; }

        [JsonPropertyName("fontWeightMedium")]
        public short FontWeightMedium { get; set; }

        [JsonPropertyName("fontWeightBold")]
        public short FontWeightBold { get; set; }

        [JsonPropertyName("h1")]
        public TypographySegment H1 { get; set; }

        [JsonPropertyName("h2")]
        public TypographySegment H2 { get; set; }

        [JsonPropertyName("h3")]
        public TypographySegment H3 { get; set; }

        [JsonPropertyName("h4")]
        public TypographySegment H4 { get; set; }

        [JsonPropertyName("h5")]
        public TypographySegment H5 { get; set; }

        [JsonPropertyName("h6")]
        public TypographySegment H6 { get; set; }

        [JsonPropertyName("subtitle1")]
        public TypographySegment Subtitle1 { get; set; }

        [JsonPropertyName("subtitle2")]
        public TypographySegment Subtitle2 { get; set; }

        [JsonPropertyName("body1")]
        public TypographySegment Body1 { get; set; }

        [JsonPropertyName("body2")]
        public TypographySegment Body2 { get; set; }

        [JsonPropertyName("button")]
        public TypographySegment Button { get; set; }

        [JsonPropertyName("caption")]
        public TypographySegment Caption { get; set; }

        [JsonPropertyName("overline")]
        public TypographySegment Overline { get; set; }

        [JsonIgnore]
        public Func<short, string> PxToRem { get; set; }
    }
}