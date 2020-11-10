using Skclusive.Core.Component;

namespace Skclusive.Material.List
{
    public class ListStyleProvider : StyleTypeProvider
    {
        public ListStyleProvider() : base
        (
            typeof(ListStyle),
            typeof(ListItemStyle),
            typeof(ListItemAvatarStyle),
            typeof(ListItemIconStyle),
            typeof(ListItemSecondaryActionStyle),
            typeof(ListItemTextStyle),
            typeof(ListSubheaderStyle)
        )
        {
        }
    }
}