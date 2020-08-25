using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class TypeObject
    {
        [JsonPropertyName("action")]
        public TypeAction Action { get; set; }

        [JsonPropertyName("background")]
        public TypeBackground Background { get; set; }

        [JsonPropertyName("divider")]
        public string Divider { get; set; }

        [JsonPropertyName("text")]
        public TypeText Text { get; set; }

        [JsonPropertyName("custom")]
        public TypeCustom Custom { get; set; }
    }
}