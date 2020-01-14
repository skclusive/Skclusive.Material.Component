using Skclusive.Core.Component;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Material.Tab
{
    public interface ITabsContext
    {
        object CreateValue();

        object Value { get; }

        TabsVariant Variant { get; }

        bool FullWidth { get; }

        RenderFragment Indicator { get; }

        Color TextColor { get; }

        EventCallback<object> OnChange { get; }
    }

    public class TabsContextBuilder
    {
        private class TabsContext : ITabsContext
        {
            private int Index = 0;

            public object Value { get; internal set; }

            public TabsVariant Variant { get; internal set; }

            public bool FullWidth { get; internal set; }

            public RenderFragment Indicator { get; internal set; }

            public Color TextColor { get; internal set; }

            public EventCallback<object> OnChange { get; internal set; }

            public object CreateValue()
            {
                return Index++;
            }
        }

        private readonly TabsContext _context = new TabsContext();

        public ITabsContext Build()
        {
            return _context;
        }

        public TabsContextBuilder WithVariant(TabsVariant variant)
        {
            _context.Variant = variant;

            return this;
        }

        public TabsContextBuilder WithFullWidth(bool fullWidth)
        {
            _context.FullWidth = fullWidth;

            return this;
        }

        public TabsContextBuilder WithValue(object value)
        {
            _context.Value = value;

            return this;
        }

        public TabsContextBuilder WithIndicator(RenderFragment indicator)
        {
            _context.Indicator = indicator;

            return this;
        }

        public TabsContextBuilder WithTextColor(Color textColor)
        {
            _context.TextColor = textColor;

            return this;
        }

        public TabsContextBuilder WithOnChange(EventCallback<object> onChange)
        {
            _context.OnChange = onChange;

            return this;
        }

        public TabsContextBuilder With(ITabsContext context)
        {
            WithVariant(context.Variant);
            WithFullWidth(context.FullWidth);
            WithIndicator(context.Indicator);
            WithTextColor(context.TextColor);
            WithOnChange(context.OnChange);

            return this;
        }
    }
}