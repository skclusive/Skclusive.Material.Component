using System.Collections.Generic;

namespace Skclusive.Material.Tooltip
{
    public class PopperOptions
    {
        public string Placement { get; set; } = PopperPlacementStrings.Bottom;
        public IList<object> Modifiers { get; } = new List<object>(); // Not supported
        public string Strategy { get; set; } = PopperStrategyStrings.Absolute;

        public override string ToString()
        {
            return $"{Placement} (Strategy: {Strategy})";
        }
    }
}
