using Skclusive.Core.Component;

namespace Skclusive.Material.Dialog
{
    public class DialogStyleProvider : StyleTypeProvider
    {
        public DialogStyleProvider() : base
        (
            priority: 220,
            typeof(DialogStyle),
            typeof(DialogActionsStyle),
            typeof(DialogContentStyle),
            typeof(DialogContentTextStyle),
            typeof(DialogTitleStyle)
        )
        {
        }
    }
}