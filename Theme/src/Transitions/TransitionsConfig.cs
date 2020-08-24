using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class TransitionsConfig
    {
        [JsonPropertyName("easing")]
        public EasingConfig Easing { get; set; }

        [JsonPropertyName("duration")]
        public DurationConfig Duration { get; set; }

        [JsonIgnore]
        public Func<string[], string, short?, short?, string> Create { set; get; }

        [JsonIgnore]
        public Func<double, int> AutoHeightDuration { set; get; }
   }
}