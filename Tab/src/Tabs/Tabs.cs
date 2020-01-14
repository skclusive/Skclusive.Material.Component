using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Tab
{
    public class TabsComponent : MaterialComponent
    {
        public TabsComponent() : base("Tabs")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public TabsVariant Variant { set; get; } = TabsVariant.Standard;

        [Parameter]
        public ScrollButton ScrollButton { set; get; } = ScrollButton.Auto;

        [Parameter]
        public Orientation Orientation { set; get; } = Orientation.Horizontal;

        [Parameter]
        public bool Centered { set; get; }

        [Parameter]
        public Color IndicatorColor { set; get; } = Color.Secondary;

        [Parameter]
        public Color TextColor { set; get; } = Color.Inherit;

        [Parameter]
        public object Value { set; get; }

        [Parameter]
        public IReference TabsRef { get; set; } = new Reference();

        [Parameter]
        public IReference ContainerRef { get; set; } = new Reference();

        [Parameter]
        public EventCallback<object> OnChange { set; get; }

        [Parameter]
        public string ScrollerStyle { set; get; }

        [Parameter]
        public string ScrollerClass { set; get; }

        [Parameter]
        public string ContainerStyle { set; get; }

        [Parameter]
        public string ContainerClass { set; get; }

        [Parameter]
        public string IndicatorStyle { set; get; }

        [Parameter]
        public string IndicatorClass { set; get; }

        protected override void OnInitialized()
        {
            Value = Value ?? -1;
        }

        protected RenderFragment Indicator => (RenderTreeBuilder builder) =>
        {
            builder.OpenRegion(0);
                builder.OpenComponent<TabIndicator>(0);
                    builder.AddAttribute(1, "Class", _IndicatorClass);
                    builder.AddAttribute(2, "Style", _IndicatorStyle);
                    builder.AddAttribute(3, "Orientation", Orientation);
                    builder.AddAttribute(4, "Color", IndicatorColor);
                builder.CloseComponent();
            builder.CloseRegion();
        };

        protected ITabsContext TabsContext => new TabsContextBuilder()
            .WithFullWidth(Variant == TabsVariant.FullWidth)
            .WithVariant(Variant)
            .WithIndicator(Indicator)
            .WithTextColor(TextColor)
            .WithOnChange(OnChange)
            .WithValue(Value)
            .Build();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Orientation == Orientation.Vertical)
                yield return $"{Orientation.Vertical}";
            }
        }


        protected virtual string _ScrollerStyle
        {
            get => CssUtil.ToStyle(ScrollerStyles, ScrollerStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ScrollerStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ScrollerClass
        {
            get => CssUtil.ToClass($"{Selector}-Scroller", ScrollerClasses, ScrollerClass);
        }

        protected virtual IEnumerable<string> ScrollerClasses
        {
            get
            {
                var scrollable = Variant == TabsVariant.Scrollable;

                yield return string.Empty;

                if (!scrollable)
                yield return "Fixed";

                if (scrollable)
                yield return $"{TabsVariant.Scrollable}";
            }
        }

        protected virtual string _ContainerStyle
        {
            get => CssUtil.ToStyle(ContainerStyles, ContainerStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ContainerStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ContainerClass
        {
            get => CssUtil.ToClass($"{Selector}-Container", ContainerClasses, ContainerClass);
        }

        protected virtual IEnumerable<string> ContainerClasses
        {
            get
            {
                var scrollable = Variant == TabsVariant.Scrollable;

                yield return string.Empty;

                if (!scrollable && Centered)
                yield return $"{nameof(Centered)}";

                if (Orientation == Orientation.Vertical)
                yield return $"{Orientation.Vertical}";
            }
        }

        protected virtual string _IndicatorStyle
        {
            get => CssUtil.ToStyle(IndicatorStyles, IndicatorStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> IndicatorStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _IndicatorClass
        {
            get => CssUtil.ToClass($"{Selector}-Indicator", IndicatorClasses, IndicatorClass);
        }

        protected virtual IEnumerable<string> IndicatorClasses
        {
            get
            {
                yield return string.Empty;
            }
        }
    }

    public enum TabsVariant
    {
        Scrollable,

        FullWidth,

        Standard
    }

    public enum ScrollButton
    {
        Auto,

        Desktop,

        On,

        Off
    }
}
