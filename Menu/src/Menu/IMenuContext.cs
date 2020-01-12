using Skclusive.Core.Component;

namespace Skclusive.Material.Menu
{
    public interface IMenuContext
    {
        int ActiveIndex { get; }

        int CreateIndex();

        MenuVariant Variant { get; }

        bool AutoFocusItem { get; }

        void MarkActiveIndex(int index);

        IReference ContentAnchorRef { get; }
    }

    public class MenuContextBuilder
    {
        private class MenuContext : IMenuContext
        {
            private int Index = 0;

            public IReference ContentAnchorRef { get; internal set; }

            public int ActiveIndex { get; internal set; } = -1;

            public MenuVariant Variant { get; internal set; }

            public bool AutoFocusItem { get; internal set; }

            public int CreateIndex()
            {
                return Index++;
            }

            public void MarkActiveIndex(int index)
            {
                ActiveIndex = index;
            }
        }

        private readonly MenuContext _context = new MenuContext();

        public IMenuContext Build()
        {
            return _context;
        }

        public MenuContextBuilder WithVariant(MenuVariant variant)
        {
            _context.Variant = variant;

            return this;
        }

        public MenuContextBuilder WithAutoFocusItem(bool autoFocusItem)
        {
            _context.AutoFocusItem = autoFocusItem;

            return this;
        }

        public MenuContextBuilder WithContentAnchorRef(IReference contentAnchorRef)
        {
            _context.ContentAnchorRef = contentAnchorRef;

            return this;
        }

        public MenuContextBuilder With(IMenuContext context)
        {
            WithContentAnchorRef(context.ContentAnchorRef);
            WithVariant(context.Variant);

            return this;
        }

        public MenuContextBuilder WithLast(IMenuContext context)
        {
            if (context != null)
            {
                _context.ActiveIndex = context.ActiveIndex;
                WithContentAnchorRef(context.ContentAnchorRef);
                WithVariant(context.Variant);
            }

            return this;
        }
    }
}