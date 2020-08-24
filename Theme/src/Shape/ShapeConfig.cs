using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class ShapeConfig
    {
        [JsonPropertyName("borderRadius")]
        public short? BorderRadius { get; set; }
    }
}