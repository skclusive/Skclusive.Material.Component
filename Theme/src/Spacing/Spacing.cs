using System;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class Spacing
    {
        public Spacing()
            : this(8, "px")
        {
        }

        public Spacing(short input, string unit)
            : this ((factor) => factor * input, unit)
        {
            Input = input;
        }

        public Spacing(Func<short, decimal> transform, string unit = "px")
        {
            Transform = transform;

            Unit = unit;
        }

        private Func<short, decimal> Transform { set; get; }

        [JsonPropertyName("input")]
        public short? Input { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        private string _Transform(short value, bool unit)
        {
            var suffix = unit ? Unit : string.Empty;
            return $"{Transform(value).ToCleanString(leadingZero: true)}{suffix}";
        }

        public string Value(bool unit = false)
        {
            return Value(1, unit);
        }

        public string Value(short value, bool unit = false)
        {
            return _Transform(value, unit);
        }

        public string Value(short value1, short value2)
        {
            return $"{_Transform(value1, true)} {_Transform(value2, true)}";
        }

        public string Value(short value1, short value2, short value3)
        {
            return $"{_Transform(value1, true)} {_Transform(value2, true)} {_Transform(value3, true)}";
        }

        public string Value(short value1, short value2, short value3, short value4)
        {
            return $"{_Transform(value1, true)} {_Transform(value2, true)} {_Transform(value3, true)} {_Transform(value4, true)}";
        }
    }
}