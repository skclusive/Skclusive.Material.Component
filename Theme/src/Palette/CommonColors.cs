using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class CommonColors
    {
        [JsonPropertyName("black")]
        public string Black { get; set; }

        [JsonPropertyName("white")]
        public string White { get; set; }

        [JsonPropertyName("custom")]
        public IDictionary<string, string> Custom { get; set; }
    }
}