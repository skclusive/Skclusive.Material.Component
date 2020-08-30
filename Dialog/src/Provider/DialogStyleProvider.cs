using Skclusive.Core.Component;

namespace Skclusive.Material.Dialog
{
    public class DialogStyleProvider : StyleTypeProvider
    {
        public DialogStyleProvider() : base
        (
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