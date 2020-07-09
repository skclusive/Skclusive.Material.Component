using System;

namespace Skclusive.Material.Tooltip
{
    public static class PopperStrategyStrings
    {
        public const string Absolute = "absolute";
        public const string Fixed = "fixed";

        public static string MapToString(this PopperStrategy popperStrategy)
        {
            switch (popperStrategy)
            {
                case PopperStrategy.Absolute:
                    return Absolute;
                case PopperStrategy.Fixed:
                    return Fixed;
                default:
                    throw new ArgumentOutOfRangeException(nameof(popperStrategy), popperStrategy, null);
            }
        }
    }
}
