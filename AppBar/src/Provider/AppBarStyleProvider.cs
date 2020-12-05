using Skclusive.Core.Component;

namespace Skclusive.Material.AppBar
{
    public class AppBarStyleProvider : StyleTypeProvider
    {
        public AppBarStyleProvider() : base(priority: 280, typeof(AppBarStyle))
        {
        }
    }
}