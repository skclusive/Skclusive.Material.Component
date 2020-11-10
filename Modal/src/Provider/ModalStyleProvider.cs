using Skclusive.Core.Component;

namespace Skclusive.Material.Modal
{
    public class ModalStyleProvider : StyleTypeProvider
    {
        public ModalStyleProvider() : base
        (
            typeof(BackdropStyle),
            typeof(SimpleBackdropStyle)
        )
        {
        }
    }
}