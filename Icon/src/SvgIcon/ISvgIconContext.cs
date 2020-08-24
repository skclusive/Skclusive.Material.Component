using Skclusive.Core.Component;

namespace Skclusive.Material.Icon
{
    public interface ISvgIconContext : IComponentContext
    {
    }

    public class SvgIconContextBuilder : ComponentContextBuilder<SvgIconContextBuilder, ISvgIconContext>
    {
        protected class SvgIconContext : ComponentContext, ISvgIconContext
        {
        }

        public SvgIconContextBuilder() : base(new SvgIconContext())
        {
        }

        protected override SvgIconContextBuilder This()
        {
            return this;
        }
    }
}