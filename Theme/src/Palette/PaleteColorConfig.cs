using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class PaletteColorConfig : PaletteShade
    {
        [JsonPropertyName("contrastText")]
        public string ContrastText { get; set; }

        [JsonPropertyName("dark")]
        public string Dark { get; set; }

        [JsonPropertyName("light")]
        public string Light { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("custom")]
        public IDictionary<string, string> Custom { get; set; }

        public PaletteColorConfig()
        {
        }

        public PaletteColorConfig(PaletteShade color) : base(color)
        {
        }

        public PaletteColorConfig(PaletteColorConfig color) : base(color)
        {
            Main = color.Main;

            Light = color.Light;

            Dark = color.Dark;

            ContrastText = color.ContrastText;
        }
    }
}