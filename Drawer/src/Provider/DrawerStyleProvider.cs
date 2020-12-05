using Skclusive.Core.Component;

namespace Skclusive.Material.Drawer
{
    public class DrawerStyleProvider : StyleTypeProvider
    {
        public DrawerStyleProvider() : base(priority: 230, typeof(DrawerStyle))
        {
        }
    }
}