using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class EasingFactory
    {
        public static Easing CreateEasing(EasingConfig config)
        {
            var easing = new Easing
            {
                EaseInOut = config?.EaseInOut ?? "cubic-bezier(0.4, 0, 0.2, 1)",

                EaseOut = config?.EaseOut ?? "cubic-bezier(0.0, 0, 0.2, 1)",

                EaseIn = config?.EaseIn ?? "cubic-bezier(0.4, 0, 1, 1)",

                Sharp = config?.Sharp ?? "cubic-bezier(0.4, 0, 0.6, 1)"
            };

            return easing;
        }
    }
}