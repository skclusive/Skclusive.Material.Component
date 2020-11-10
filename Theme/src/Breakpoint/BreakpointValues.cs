using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class BreakpointValues
    {
        [JsonPropertyName("xs")]
        public short ExtraSmall { set; get; }

        [JsonPropertyName("sm")]
        public short Small { set; get; }

        [JsonPropertyName("md")]
        public short Medium { set; get; }

        [JsonPropertyName("lg")]
        public short Large { set; get; }

        [JsonPropertyName("xl")]
        public short ExtraLarge { set; get; }
    }
}