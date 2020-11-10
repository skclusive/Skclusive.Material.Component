using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class DurationConfig
    {
        [JsonPropertyName("shortest")]
        public short? Shortest { get; set; }

        [JsonPropertyName("shorter")]
        public short? Shorter { get; set; }

        [JsonPropertyName("short")]
        public short? Short { get; set; }

        // most basic recommended timing
        [JsonPropertyName("standard")]
        public short? Standard { get; set; }

        // this is to be used in complex animations
        [JsonPropertyName("complex")]
        public short? Complex { get; set; }

        // recommended when something is entering screen
        [JsonPropertyName("enteringScreen")]
        public short? EnteringScreen { get; set; }

        // recommended when something is leaving screen
        [JsonPropertyName("leavingScreen")]
        public short? LeavingScreen { get; set; }
    }
}