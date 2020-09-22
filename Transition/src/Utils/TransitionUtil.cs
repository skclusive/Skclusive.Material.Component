using System.Collections.Generic;
using System.Globalization;

namespace Skclusive.Material.Transition
{
    public enum TransitionEasing
    {
        EasingOut,

        EasingSharp
    }

    public class TransitionUtil
    {
        private static readonly IDictionary<TransitionEasing, string> EASING_MAPPING = new Dictionary<TransitionEasing, string>
        {
            { TransitionEasing.EasingOut, "cubic-bezier(0, 0, 0.2, 1)" },
            { TransitionEasing.EasingSharp, "cubic-bezier(0.4, 0, 0.6, 1)" },
        };


        public static string CreateTransition(string action, double duration, int delay, TransitionEasing easing = TransitionEasing.EasingOut)
        {
            return $"{action} {duration.ToString(CultureInfo.InvariantCulture)}ms {EASING_MAPPING[easing]} {delay.ToString(CultureInfo.InvariantCulture)}ms";
        }
    }
}
