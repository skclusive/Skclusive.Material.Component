using System;

namespace Skclusive.Material.Tooltip
{
    public static class PopperPlacementStrings
    {
        public const string Auto = "auto";
        public const string AutoStart = "auto-start";
        public const string AutoEnd = "auto-end";
        public const string Top = "top";
        public const string TopStart = "top-start";
        public const string TopEnd = "top-end";
        public const string Bottom = "bottom";
        public const string BottomStart = "bottom-start";
        public const string BottomEnd = "bottom-end";
        public const string Right = "right";
        public const string RightStart = "right-start";
        public const string RightEnd = "right-end";
        public const string Left = "left";
        public const string LeftStart = "left-start";
        public const string LeftEnd = "left-end";

        public static string MapToString(this PopperPlacement popperPlacement)
        {
            switch (popperPlacement)
            {
                case PopperPlacement.Auto:
                    return Auto;
                case PopperPlacement.AutoStart:
                    return AutoStart;
                case PopperPlacement.AutoEnd:
                    return AutoEnd;
                case PopperPlacement.Top:
                    return Top;
                case PopperPlacement.TopStart:
                    return TopStart;
                case PopperPlacement.TopEnd:
                    return TopEnd;
                case PopperPlacement.Bottom:
                    return Bottom;
                case PopperPlacement.BottomStart:
                    return BottomStart;
                case PopperPlacement.BottomEnd:
                    return BottomEnd;
                case PopperPlacement.Right:
                    return Right;
                case PopperPlacement.RightStart:
                    return RightStart;
                case PopperPlacement.RightEnd:
                    return RightEnd;
                case PopperPlacement.Left:
                    return Left;
                case PopperPlacement.LeftStart:
                    return LeftStart;
                case PopperPlacement.LeftEnd:
                    return LeftEnd;
                default:
                    throw new ArgumentOutOfRangeException(nameof(popperPlacement), popperPlacement, null);
            }
        }
    }
}
