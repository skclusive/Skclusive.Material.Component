using Skclusive.Core.Component;

namespace Skclusive.Material.Tab
{
    public class TabStyleProvider : StyleTypeProvider
    {
        public TabStyleProvider() : base
        (
            typeof(TabIndicatorStyle),
            typeof(TabScrollButtonStyle),
            typeof(TabStyle),
            typeof(TabsStyle)
        )
        {
        }
    }
}