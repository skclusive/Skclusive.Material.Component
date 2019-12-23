using Skclusive.Core.Component;

namespace Skclusive.Material.Table
{
    public interface ITableContext
    {
        Padding Padding { get; }

        Size Size { get; }

        bool StickyHeader { get; }
    }

    public class TableContextBuilder
    {
        private class TableContext : ITableContext
        {
            public Padding Padding { get; internal set; }

            public Size Size { get; internal set; }

            public bool StickyHeader { get; internal set; }
        }

        private readonly TableContext context = new TableContext();

        public ITableContext Build()
        {
            return context;
        }

        public TableContextBuilder WithPadding(Padding padding)
        {
            context.Padding = padding;

            return this;
        }

        public TableContextBuilder WithSize(Size size)
        {
            context.Size = size;

            return this;
        }

        public TableContextBuilder WithStickyHeader(bool stickyHeader)
        {
            context.StickyHeader = stickyHeader;

            return this;
        }

        public TableContextBuilder With(ITableContext context)
        {
            WithPadding(context.Padding)
            .WithSize(context.Size)
            .WithStickyHeader(context.StickyHeader);

            return this;
        }
    }
}