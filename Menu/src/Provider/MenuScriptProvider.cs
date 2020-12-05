using Skclusive.Core.Component;

namespace Skclusive.Material.Menu
{
    public class MenuScriptProvider : ScriptTypeProvider
    {
        public MenuScriptProvider() : base(priority: 260, typeof(MenuScript))
        {
        }
    }
}