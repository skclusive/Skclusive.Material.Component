using Skclusive.Core.Component;

namespace Skclusive.Material.Toolbar
{
    public class ToolbarStyleProvider : StyleTypeProvider
    {
        public ToolbarStyleProvider() : base(priority: 100, typeof(ToolbarStyle))
        {
        }
    }
}