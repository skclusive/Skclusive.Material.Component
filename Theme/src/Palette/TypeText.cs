using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class TypeText
    {
        [JsonPropertyName("disabled")]
        public string Disabled { get; set; }

        [JsonPropertyName("hint")]
        public string Hint { get; set; }

        [JsonPropertyName("primary")]
        public string Primary { get; set; }

        [JsonPropertyName("secondary")]
        public string Secondary { get; set; }
    }
}