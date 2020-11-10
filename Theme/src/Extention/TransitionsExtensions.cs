
using System;
using System.Globalization;
using System.Text;

namespace Skclusive.Material.Theme
{
    public static class TransitionsExtensions
    {
        public static string Make(this Transitions transitions, string prop, string easing, short? duration, short? delay)
        {
            return transitions.Create(new string [] { prop }, easing, duration, delay);
        }

        public static string Make(this Transitions transitions, string prop)
        {
            return transitions.Make(prop, null, null, null);
        }

        public static string Make(this Transitions transitions)
        {
            return transitions.Make("all");
        }

        public static string Make(this Transitions transitions, string easing, short? duration, short? delay)
        {
            return transitions.Make("all", easing, duration, delay);
        }
    }
}