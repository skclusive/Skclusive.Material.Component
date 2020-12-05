using Skclusive.Core.Component;

namespace Skclusive.Material.Avatar
{
    public class AvatarStyleProvider : StyleTypeProvider
    {
        public AvatarStyleProvider() : base(priority: 60, typeof(AvatarStyle))
        {
        }
    }
}