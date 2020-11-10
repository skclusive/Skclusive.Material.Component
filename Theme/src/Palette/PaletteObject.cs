using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class PaletteObject
    {
        [JsonPropertyName("action")]
        public PaletteAction Action { get; set; }

        [JsonPropertyName("background")]
        public PaletteBackground Background { get; set; }

        [JsonPropertyName("divider")]
        public string Divider { get; set; }

        [JsonPropertyName("text")]
        public PaletteText Text { get; set; }

        [JsonPropertyName("custom")]
        public PaletteCustom Custom { get; set; }
    }
}