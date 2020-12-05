using Skclusive.Core.Component;

namespace Skclusive.Material.Input
{
    public class InputStyleProvider : StyleTypeProvider
    {
        public InputStyleProvider() : base
        (
            priority: 270,
            typeof(InputAdornmentStyle),
            typeof(InputLabelStyle),
            typeof(InputBaseStyle),
            typeof(InputStyle),
            typeof(FilledInputStyle),
            typeof(NotchedOutlineStyle),
            typeof(OutlinedInputStyle)
        )
        {
        }
    }
}