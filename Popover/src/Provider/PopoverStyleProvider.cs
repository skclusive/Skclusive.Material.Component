using Skclusive.Core.Component;

namespace Skclusive.Material.Popover
{
    public class PopoverStyleProvider : StyleTypeProvider
    {
        public PopoverStyleProvider() : base(priority: 250, typeof(PopoverStyle))
        {
        }
    }
}