using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public enum Breakpoint
    {
        [EnumMember(Value = "xs")]

        ExtraSmall,

        [EnumMember(Value = "sm")]
        Small,

        [EnumMember(Value = "md")]
        Medium,

        [EnumMember(Value = "lg")]
        Large,

        [EnumMember(Value = "xl")]
        ExtraLarge
    }
}