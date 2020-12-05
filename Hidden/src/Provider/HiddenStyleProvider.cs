using Skclusive.Core.Component;

namespace Skclusive.Material.Hidden
{
    public class HiddenStyleProvider : StyleTypeProvider
    {
        public HiddenStyleProvider() : base(priority: 1000, typeof(HiddenStyle))
        {
        }
    }
}