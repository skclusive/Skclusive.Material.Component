using Skclusive.Core.Component;

namespace Skclusive.Material.Transition
{
    public class TransitionScriptProvider : ScriptTypeProvider
    {
        public TransitionScriptProvider() : base(priority: 130, typeof(TransitionScript))
        {
        }
    }
}