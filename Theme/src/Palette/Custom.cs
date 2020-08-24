using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class Custom
    {
        [JsonPropertyName("lightOrDark")]
        public string LightOrDark { set; get; }

        [JsonPropertyName("lightOrDarkContrastText")]
        public string LightOrDarkContrastText { set; get; }

        [JsonPropertyName("primaryMain")]
        public string PrimaryMain { set; get; }

        [JsonPropertyName("primaryContrastText")]
        public string PrimaryContrastText { set; get; }

        [JsonPropertyName("contentBackground")]
        public string ContentBackground { set; get; }

        [JsonPropertyName("contentBackgroundDefault")]
        public string ContentBackgroundDefault { set; get; }

        [JsonPropertyName("paletteCommonAlternate")]
        public string PaletteCommonAlternate { set; get; }

        [JsonPropertyName("paletteOpacity")]
        public string PaletteOpacity { set; get; }

        [JsonPropertyName("layoutBackward")]
        public string LayoutBackward { set; get; }

        [JsonPropertyName("layoutForward")]
        public string LayoutForward { set; get; }
    }
}