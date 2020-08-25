using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class TypeAction
    {
        [JsonPropertyName("active")]
        public string Active { get; set; }

        [JsonPropertyName("disabled")]
        public string Disabled { get; set; }

        [JsonPropertyName("disabledBackground")]
        public string DisabledBackground { get; set; }

        [JsonPropertyName("hover")]
        public string Hover { get; set; }

        [JsonPropertyName("hoverOpacity")]
        public decimal HoverOpacity { get; set; }

        [JsonPropertyName("selected")]
        public string Selected { get; set; }

        [JsonPropertyName("custom")]
        public IDictionary<string, string> Custom { get; set; }
    }
}