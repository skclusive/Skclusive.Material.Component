namespace Skclusive.Material.Tooltip
{
    public class PopperOptions
    {
        public string Placement { get; set; } = PopperPlacementStrings.Bottom;
        //public IList<PopperModifier> Modifiers { get; set; } = new List<PopperModifier>();
        public string Strategy { get; set; } = PopperStrategyStrings.Absolute;

        public override string ToString()
        {
            return $"{Placement} (Strategy: {Strategy})";
        }
    }
}
