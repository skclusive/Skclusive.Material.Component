using Skclusive.Core.Component;

namespace Skclusive.Material.Link
{
    public class LinkStyleProvider : StyleTypeProvider
    {
        public LinkStyleProvider() : base(priority: 200, typeof(LinkStyle))
        {
        }
    }
}