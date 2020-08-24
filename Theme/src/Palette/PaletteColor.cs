using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class PaletteColor
    {
        [JsonPropertyName("contrastText")]
        public string ContrastText { get; set; }

        [JsonPropertyName("dark")]
        public string Dark { get; set; }

        [JsonPropertyName("light")]
        public string Light { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }
    }
}