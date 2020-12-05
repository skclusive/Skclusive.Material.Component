using Skclusive.Core.Component;

namespace Skclusive.Material.Badge
{
    public class BadgeStyleProvider : StyleTypeProvider
    {
        public BadgeStyleProvider() : base(priority: 50, typeof(BadgeStyle))
        {
        }
    }
}