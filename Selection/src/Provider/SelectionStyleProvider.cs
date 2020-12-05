using Skclusive.Core.Component;

namespace Skclusive.Material.Selection
{
    public class SelectionStyleProvider : StyleTypeProvider
    {
        public SelectionStyleProvider() : base
        (
            priority: 170,
            typeof(SwitchBaseStyle),
            typeof(SwitchStyle),
            typeof(CheckboxStyle),
            typeof(RadioStyle)
        )
        {
        }
    }
}