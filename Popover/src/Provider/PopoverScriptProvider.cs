using Skclusive.Core.Component;

namespace Skclusive.Material.Popover
{
    public class PopoverScriptProvider : ScriptTypeProvider
    {
        public PopoverScriptProvider() : base(priority: 250, typeof(PopoverScript))
        {
        }
    }
}