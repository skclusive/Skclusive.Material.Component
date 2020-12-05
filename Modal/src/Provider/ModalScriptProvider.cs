using Skclusive.Core.Component;

namespace Skclusive.Material.Modal
{
    public class ModalScriptProvider : ScriptTypeProvider
    {
        public ModalScriptProvider() : base(priority: 210, typeof(ModalScript))
        {
        }
    }
}