using Skclusive.Core.Component;

namespace Skclusive.Material.Modal
{
    public class ModalStyleProvider : StyleTypeProvider
    {
        public ModalStyleProvider() : base
        (
            priority: 210,
            typeof(BackdropStyle),
            typeof(SimpleBackdropStyle)
        )
        {
        }
    }
}