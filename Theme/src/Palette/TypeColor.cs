using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public partial class TypeColor
    {
        [JsonPropertyName("100")]
        public string X100 { get; set; }

        [JsonPropertyName("200")]
        public string X200 { get; set; }

        [JsonPropertyName("300")]
        public string X300 { get; set; }

        [JsonPropertyName("400")]
        public string X400 { get; set; }

        [JsonPropertyName("50")]
        public string X50 { get; set; }

        [JsonPropertyName("500")]
        public string X500 { get; set; }

        [JsonPropertyName("600")]
        public string X600 { get; set; }

        [JsonPropertyName("700")]
        public string X700 { get; set; }

        [JsonPropertyName("800")]
        public string X800 { get; set; }

        [JsonPropertyName("900")]
        public string X900 { get; set; }

        [JsonPropertyName("A100")]
        public string A100 { get; set; }

        [JsonPropertyName("A200")]
        public string A200 { get; set; }

        [JsonPropertyName("A400")]
        public string A400 { get; set; }

        [JsonPropertyName("A700")]
        public string A700 { get; set; }

        public TypeColor()
        {
        }

        public TypeColor(TypeColor color)
        {
            X50 = color.X50;

            X100 = color.X100;

            X200 = color.X200;

            X300 = color.X300;

            X400 = color.X400;

            X500 = color.X500;

            X600 = color.X600;

            X700 = color.X700;

            X800 = color.X800;

            X900 = color.X900;

            A100 = color.A100;

            A200 = color.A200;

            A400 = color.A400;

            A700 = color.A700;
        }
    }
}