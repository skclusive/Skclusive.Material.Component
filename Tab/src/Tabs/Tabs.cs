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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// The <see cref="TabsVariant" /> variant to use.
        /// </summary>
        [Parameter]
        public TabsVariant Variant { set; get; } = TabsVariant.Standard;

        /// <summary>
        /// The <see cref="ScrollButton" /> that determines behavior of scroll buttons when tabs are set to scroll:
        /// <remarks>
        /// - `auto` will only present them when not all the items are visible.
        /// - `desktop` will only present them on medium and larger viewports.
        /// - `on` will always present them.
        /// - `off` will never present them.
        /// </remarks>
        /// </summary>
        [Parameter]
        public ScrollButton ScrollButton { set; get; } = ScrollButton.Auto;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Orientation" /> of the component. The tabs orientation (layout flow direction).
        /// </summary>
        [Parameter]
        public Orientation Orientation { set; get; } = Orientation.Horizontal;

        /// <summary>
        /// If <c>true</c>, the tabs will be centered.
        /// This property is intended for large views.
        /// </summary>
        [Parameter]
        public bool Centered { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> that determines the color of the indicator.
        /// </summary>
        [Parameter]
        public Color IndicatorColor { set; get; } = Color.Secondary;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> that determines the color of the <c>Tab</c>.
        /// </summary>
        [Parameter]
        public Color TextColor { set; get; } = Color.Inherit;

        /// <summary>
        /// The value of the currently selected <c>Tab</c>.
        /// If you don't want any selected <c>Tab</c>, you can set this property to <c>false</c>.
        /// </summary>
        [Parameter]
        public object Value { set; get; }

        /// <summary>
        /// Reference attached to the Tabs element of the component.
        /// </summary>
        [Parameter]
        public IReference TabsRef { get; set; } = new Reference();

        /// <summary>
        /// Reference attached to the container element of the component.
        /// </summary>
        [Parameter]
        public IReference ContainerRef { get; set; } = new Reference();

        /// <summary>
        /// Callback fired when the value changes.
        /// </summary>
        [Parameter]
        public EventCallback<object> OnChange { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Scroller</c> element.
        /// </summary>
        [Parameter]
        public string ScrollerStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Scroller</c> element.
        /// </summary>
        [Parameter]
        public string ScrollerClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Container</c> element.
        /// </summary>
        [Parameter]
        public string ContainerStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Container</c> element.
        /// </summary>
        [Parameter]
        public string ContainerClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Indicator</c> element.
        /// </summary>
        [Parameter]
        public string IndicatorStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Indicator</c> element.
        /// </summary>
        [Parameter]
        public string IndicatorClass { set; get; }

        /// <summary>
        /// the indicator content.
        /// </summary>
        [Parameter]
        public RenderFragment IndicatorContent { set; get; }

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
                    builder.AddAttribute(5, "ChildContent", IndicatorContent);
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
