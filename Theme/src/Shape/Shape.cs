using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class Shape
    {
        [JsonPropertyName("borderRadius")]
        public short BorderRadius { get; set; }
    }
}