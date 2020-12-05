using Skclusive.Core.Component;

namespace Skclusive.Material.Transition
{
    public class TransitionStyleProvider : StyleTypeProvider
    {
        public TransitionStyleProvider() : base(priority: 130, typeof(CollapseContainerStyle))
        {
        }
    }
}