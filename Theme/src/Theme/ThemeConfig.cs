using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class ThemeConfig
    {
        [JsonPropertyName("shape")]
        public ShapeConfig Shape { set; get; }

        [JsonPropertyName("breakpoints")]
        public BreakpointsConfig Breakpoints { set; get; }

        [JsonPropertyName("direction")]
        public Direction? Direction { set; get; }

        [JsonPropertyName("palette")]
        public PaletteConfig Palette { set; get; }

        [JsonPropertyName("spacing")]
        public SpacingConfig Spacing { set; get; }

        [JsonPropertyName("transitions")]
        public TransitionsConfig Transitions { set; get; }

        [JsonPropertyName("zIndex")]
        public ZIndexConfig ZIndex { set; get; }

        [JsonPropertyName("typography")]
        public TypographyConfig Typography { set; get; }

        [JsonIgnore]
        public Func<Palette, TypographyConfig> TypographyFunc { set; get; }

        [JsonPropertyName("shadows")]
        public string[] Shadows { set; get; }
    }
}