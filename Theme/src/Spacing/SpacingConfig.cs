using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class SpacingConfig
    {
        [JsonPropertyName("input")]
        public short? Input { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonIgnore]
        public Func<short, decimal> Transform { set; get; }
    }
}