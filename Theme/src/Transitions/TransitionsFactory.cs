using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class TransitionsFactory
    {
        public static Transitions CreateTransitions(TransitionsConfig config)
        {
            var duration = DurationFactory.CreateDuration(config?.Duration);

            var easing = EasingFactory.CreateEasing(config?.Easing);

            var created = config?.Create ?? ((string[] props, string _easing, short? _duration, short? delay) =>
            {
                var __duration = _duration ?? duration.Standard;

                var __easing = _easing ?? easing.EaseInOut;

                return string.Join(",", props.Select(prop => $"{prop} {__duration}ms {__easing} {delay ?? 0}ms"));
            });

            var autoHeightDuration = config?.AutoHeightDuration ?? ((double height) =>
            {
                if (height <= 0)
                {
                    return 0;
                }

                double divider = (double)height / 36;

                return Convert.ToInt32(Decimal.Round((decimal)(4 + 15 * Math.Pow(divider, 0.25) + divider / 5) * 10));
            });

            return new Transitions
            {
                Duration = duration,

                Easing = easing,

                Create = created,

                AutoHeightDuration = autoHeightDuration
            };
        }
    }
}