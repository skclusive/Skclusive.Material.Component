using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class Transitions
    {
        [JsonPropertyName("easing")]
        public Easing Easing { get; set; } = new Easing();

        [JsonPropertyName("duration")]
        public Duration Duration { get; set; } = new Duration();

        [JsonIgnore]
        public Func<string[], string, short?, short?, string> Create { set; get; }

        [JsonIgnore]
        public Func<double, int> AutoHeightDuration { set; get; }
    }
}