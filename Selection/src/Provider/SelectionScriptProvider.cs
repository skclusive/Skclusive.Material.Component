using Skclusive.Core.Component;

namespace Skclusive.Material.Selection
{
    public class SelectionScriptProvider : ScriptTypeProvider
    {
        public SelectionScriptProvider() : base(priority: 170, typeof(SelectionScript))
        {
        }
    }
}