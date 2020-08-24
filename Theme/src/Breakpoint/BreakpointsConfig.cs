using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class BreakpointsConfig
    {
        [JsonPropertyName("unit")]
        public string Unit { set; get;}

        [JsonPropertyName("step")]
        public int? Step { set; get; }

        [JsonPropertyName("values")]
        public BreakpointValues Values { set; get; }

        [JsonIgnore]
        public Func<Breakpoint, string> Up { set; get; }

        [JsonIgnore]
        public Func<Breakpoint, string> Down { set; get; }

        [JsonIgnore]
        public Func<Breakpoint, Breakpoint, string> Between { set; get; }

        [JsonIgnore]
        public Func<Breakpoint, string> Only { set; get; }

        [JsonIgnore]
        public Func<Breakpoint, int> Width { set; get; }
    }
}