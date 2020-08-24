using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class ZIndex
    {
        [JsonPropertyName("mobileStepper")]
        public short MobileStepper { get; set; }

        [JsonPropertyName("speedDial")]
        public short SpeedDial { get; set; }

        [JsonPropertyName("appBar")]
        public short AppBar { get; set; }

        [JsonPropertyName("drawer")]
        public short Drawer { get; set; }

        [JsonPropertyName("modal")]
        public short Modal { get; set; }

        [JsonPropertyName("snackbar")]
        public short Snackbar { get; set; }

        [JsonPropertyName("tooltip")]
        public short Tooltip { get; set; }
    }
}