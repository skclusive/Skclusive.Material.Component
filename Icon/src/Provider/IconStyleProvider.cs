using Skclusive.Core.Component;

namespace Skclusive.Material.Icon
{
    public class IconStyleProvider : StyleTypeProvider
    {
        public IconStyleProvider() : base(priority: 80, typeof(SvgIconStyle))
        {
        }
    }
}