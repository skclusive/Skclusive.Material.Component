using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class Palette
    {
        [JsonPropertyName("action")]
        public TypeAction Action { get; set; }

        [JsonPropertyName("background")]
        public TypeBackground Background { get; set; }

        [JsonPropertyName("common")]
        public CommonColors Common { get; set; }

        [JsonPropertyName("contrastThreshold")]
        public decimal ContrastThreshold { get; set; }

        [JsonPropertyName("divider")]
        public string Divider { get; set; }

        [JsonPropertyName("error")]
        public PaletteColor Error { get; set; }

        [JsonPropertyName("grey")]
        public TypeColor Grey { get; set; }

        [JsonPropertyName("primary")]
        public PaletteColor Primary { get; set; }

        [JsonPropertyName("secondary")]
        public PaletteColor Secondary { get; set; }

        [JsonPropertyName("text")]
        public TypeText Text { get; set; }

        [JsonPropertyName("tonalOffset")]
        public decimal TonalOffset { get; set; }

        [JsonPropertyName("type")]
        public PaletteType Type { get; set; }

        [JsonPropertyName("custom")]
        public TypeCustom Custom { get; set; }
    }
}