using Skclusive.Core.Component;

namespace Skclusive.Material.Divider
{
    public class DividerStyleProvider : StyleTypeProvider
    {
        public DividerStyleProvider() : base(priority: 40, typeof(DividerStyle))
        {
        }
    }
}