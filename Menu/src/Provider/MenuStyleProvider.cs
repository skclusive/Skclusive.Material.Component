using Skclusive.Core.Component;

namespace Skclusive.Material.Menu
{
    public class MenuStyleProvider : StyleTypeProvider
    {
        public MenuStyleProvider() : base(priority: 260, typeof(MenuStyle), typeof(MenuItemStyle))
        {
        }
    }
}