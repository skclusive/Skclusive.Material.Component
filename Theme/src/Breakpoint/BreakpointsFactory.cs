using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public static class BreakpointsFactory
    {
        public static Breakpoints CreateBreakpoints(BreakpointsConfig config)
        {
            var unit = config?.Unit ?? "px";

            var step = config?.Step ?? 5;

            var values = config?.Values ?? new BreakpointValues
            {
                ExtraSmall = 0,

                Small = 600,

                Medium = 960,

                Large = 1280,

                ExtraLarge = 1920
            };

            Func<Breakpoint, string> up = (breakpoint) =>
            {
                var value = ValueByBreakpoint(values, breakpoint);

                return $"@media (min-width:{value}{unit})";
            };

            Func<Breakpoint, string> down = (breakpoint) =>
            {
                if (breakpoint == Breakpoint.ExtraLarge)
                {
                    return up(Breakpoint.ExtraSmall);
                }

                var value = ValueByBreakpoint(values, NextBreakpoint(breakpoint));

                return $"@media (max-width:{Decimal.Round((decimal)value - (decimal)step / 100, 2)}{unit})";
            };

            Func<Breakpoint, int> width = (breakpoint) =>
            {
                return ValueByBreakpoint(values, breakpoint);
            };

            Func<Breakpoint, Breakpoint, string> between = (start, end) =>
            {
                if (end == Breakpoint.ExtraLarge)
                {
                    return up(start);
                }
                var startValue = ValueByBreakpoint(values, start);

                var endValue = ValueByBreakpoint(values, NextBreakpoint(end));

                return $"@media (min-width:{startValue}{unit}) and (max-width:{Decimal.Round((decimal)endValue - (decimal)step / 100, 2)}{unit})";
            };

            Func<Breakpoint, string> only = (breakpoint) =>
            {
                return between(breakpoint, breakpoint);
            };

            var breakpoints = new Breakpoints
            {
                Values = values,

                Keys = new Breakpoint[]
                {
                    Breakpoint.ExtraSmall,

                    Breakpoint.Small,

                    Breakpoint.Medium,

                    Breakpoint.Large,

                    Breakpoint.ExtraLarge
                },

                Up = up,

                Width = width,

                Between = between,

                Only = only,

                Down = down
            };

            return breakpoints;
        }

        public static Breakpoint NextBreakpoint(Breakpoint breakpoint)
        {
            switch (breakpoint)
            {
                case Breakpoint.ExtraSmall:
                    return Breakpoint.Small;
                case Breakpoint.Small:
                    return Breakpoint.Medium;
                case Breakpoint.Medium:
                    return Breakpoint.Large;
                case Breakpoint.Large:
                    return Breakpoint.ExtraLarge;
                case Breakpoint.ExtraLarge:
                    return Breakpoint.Small;
            }

            throw new Exception("not valid breakpoint");
        }

        public static int ValueByBreakpoint(BreakpointValues values, Breakpoint breakpoint)
        {
            switch (breakpoint)
            {
                case Breakpoint.ExtraSmall:
                    return values.ExtraSmall;
                case Breakpoint.Small:
                    return values.Small;
                case Breakpoint.Medium:
                    return values.Medium;
                case Breakpoint.Large:
                    return values.Large;
                case Breakpoint.ExtraLarge:
                    return values.ExtraLarge;
            }

            throw new Exception("not valid breakpoint");
        }
    }
}