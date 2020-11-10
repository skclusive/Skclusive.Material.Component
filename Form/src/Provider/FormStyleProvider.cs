using Skclusive.Core.Component;

namespace Skclusive.Material.Form
{
    public class FormStyleProvider : StyleTypeProvider
    {
        public FormStyleProvider() : base
        (
            typeof(FormControlStyle),
            typeof(FormControlLabelStyle),
            typeof(FormGroupStyle),
            typeof(FormHelperTextStyle),
            typeof(FormLabelStyle)
        )
        {
        }
    }
}