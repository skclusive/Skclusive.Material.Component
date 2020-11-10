using Skclusive.Core.Component;

namespace Skclusive.Material.Menu
{
    public class MenuStyleProvider : StyleTypeProvider
    {
        public MenuStyleProvider() : base(typeof(MenuStyle), typeof(MenuItemStyle))
        {
        }
    }
}