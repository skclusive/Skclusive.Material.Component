using Skclusive.Core.Component;

namespace Skclusive.Material.List
{
    public interface IListContext
    {
        bool Dense { get; }

        AlignItems AlignItems { get; }
    }

    public class ListContextBuilder
    {
        private class ListContext : IListContext
        {
            public bool Dense { get; internal set; }

            public AlignItems AlignItems { get; internal set; }
        }

        private readonly ListContext context = new ListContext();

        public IListContext Build()
        {
            return context;
        }

        public ListContextBuilder WithDense(bool dense)
        {
            context.Dense = dense;

            return this;
        }

        public ListContextBuilder WithAlignItems(AlignItems alignItems)
        {
            context.AlignItems = alignItems;

            return this;
        }

        public ListContextBuilder With(IListContext context)
        {
            WithDense(context.Dense);
            WithAlignItems(context.AlignItems);

            return this;
        }
    }
}