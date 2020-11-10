using Skclusive.Core.Component;

namespace Skclusive.Material.Avatar
{
    public interface IAvatarContext : IComponentContext
    {
    }

    public class AvatarContextBuilder : ComponentContextBuilder<AvatarContextBuilder, IAvatarContext>
    {
        protected class AvatarContext : ComponentContext, IAvatarContext
        {
        }

        public AvatarContextBuilder() : base(new AvatarContext())
        {
        }

        protected override AvatarContextBuilder This()
        {
            return this;
        }
    }
}