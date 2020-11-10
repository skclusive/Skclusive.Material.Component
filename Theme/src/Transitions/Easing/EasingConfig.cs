using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class EasingConfig
    {
          // This is the most common easing curve.
        [JsonPropertyName("easeInOut")]
        public string EaseInOut { get; set; }

        // Objects enter the screen at full velocity from off-screen and
        // slowly decelerate to a resting point.
        [JsonPropertyName("easeOut")]
        public string EaseOut { get; set; }

        // Objects leave the screen at full velocity. They do not decelerate when off-screen.
        [JsonPropertyName("easeIn")]
        public string EaseIn { get; set; }

        // The sharp curve is used by objects that may return to the screen at any time.
        [JsonPropertyName("sharp")]
        public string Sharp { get; set; }
    }
}