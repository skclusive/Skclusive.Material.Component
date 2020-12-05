using Skclusive.Core.Component;

namespace Skclusive.Material.Button
{
    public class ButtonStyleProvider : StyleTypeProvider
    {
        public ButtonStyleProvider() : base
        (
            priority: 140,
            typeof(ButtonBaseStyle),
            typeof(FabStyle),
            typeof(IconButtonStyle),
            typeof(RippleStyle),
            typeof(TouchRippleStyle),
            typeof(ButtonStyle)
        )
        {
        }
    }
}