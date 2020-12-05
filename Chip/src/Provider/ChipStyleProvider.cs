using Skclusive.Core.Component;

namespace Skclusive.Material.Chip
{
    public class ChipStyleProvider : StyleTypeProvider
    {
        public ChipStyleProvider() : base(priority: 120, typeof(ChipStyle))
        {
        }
    }
}