using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class TypeBackground
    {
        [JsonPropertyName("default")]
        public string Default { get; set; }

        [JsonPropertyName("paper")]
        public string Paper { get; set; }
    }
}