using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class Theme
    {
        [JsonPropertyName("shape")]
        public Shape Shape { set; get; }

        [JsonPropertyName("breakpoints")]
        public Breakpoints Breakpoints { set; get; }

        [JsonPropertyName("direction")]
        public Direction Direction { set; get; }

        [JsonPropertyName("palette")]
        public Palette Palette { set; get; }

        [JsonPropertyName("spacing")]
        public Spacing Spacing { set; get; }

        [JsonPropertyName("transitions")]
        public Transitions Transitions { set; get; }

        [JsonPropertyName("zIndex")]
        public ZIndex ZIndex { set; get; }

        [JsonPropertyName("typography")]
        public Typography Typography { set; get; }

        [JsonPropertyName("shadows")]
        public string[] Shadows { set; get; }
    }
}