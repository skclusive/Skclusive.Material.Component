using Skclusive.Core.Component;

namespace Skclusive.Material.Tab
{
    public class TabStyleProvider : StyleTypeProvider
    {
        public TabStyleProvider() : base
        (
            priority: 170,
            typeof(TabIndicatorStyle),
            typeof(TabScrollButtonStyle),
            typeof(TabStyle),
            typeof(TabsStyle)
        )
        {
        }
    }
}