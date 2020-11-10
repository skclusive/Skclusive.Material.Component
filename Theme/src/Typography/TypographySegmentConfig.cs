using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class TypographySegmentConfig
    {
        [JsonPropertyName("fontFamily")]
        public string FontFamily { get; set; }

        [JsonPropertyName("fontWeight")]
        public short? FontWeight { get; set; }

        [JsonPropertyName("fontSize")]
        public string FontSize { get; set; }

        [JsonPropertyName("lineHeight")]
        public decimal? LineHeight { get; set; }

        [JsonPropertyName("letterSpacing")]
        public string LetterSpacing { get; set; }

        [JsonPropertyName("textTransform")]
        public string TextTransform { get; set; }
    }
}