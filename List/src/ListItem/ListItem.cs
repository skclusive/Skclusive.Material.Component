using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.List
{
    public class ListItemComponent : MaterialComponentBase
    {
        public ListItemComponent() : base("ListItem")
        {
        }

        /// <summary>
        /// ChildContent of the current component which gets component <see cref="IListItemContext" />.
        /// </summary>
        [Parameter]
        public RenderFragment<IListItemContext> ChildContent { get; set; }

        /// <summary>
        /// Reference attached to the child element of the component.
        /// </summary>
        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        /// <summary>
        /// If <c>true</c>, the text will not wrap, but instead will truncate with a text overflow ellipsis.
        /// <remarks>
        /// Note that text overflow can only happen with block or inline-block level elements
        /// (the element needs to have a width in order to overflow).
        /// </remarks>
        /// </summary>
        [Parameter]
        public bool NoWrap { set; get; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.AlignItems" /> which defines the <c>align-items</c> style property..
        /// </summary>
        [Parameter]
        public AlignItems AlignItems { set; get; } = AlignItems.Center;

        /// <summary>
        /// If <c>true</c>, the list item will be focused during the first mount.
        /// Focus will also be triggered if the value changes from false to true.
        /// </summary>
        [Parameter]
        public bool AutoFocus { set; get; }

        /// <summary>
        /// If <c>true</c>, the list item will be a button (using <c>ButtonBase</c>). Props intended
        /// for <c>ButtonBase</c> can then be applied to <c>ListItem</c>.
        /// </summary>
        [Parameter]
        public bool Button { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, compact vertical padding designed for keyboard and mouse input will be used for
        /// the list and list items.
        /// The prop is available to descendant components as the <c>dense</c> context.
        /// </summary>
        [Parameter]
        public bool? Dense { set; get; }

        /// <summary>
        /// If <c>true</c>, the left and right padding is removed.
        /// </summary>
        [Parameter]
        public bool DisableGutters { set; get; }

        /// <summary>
        /// If <c>true</c>, a 1px light border is added to the bottom of the list item.
        /// </summary>
        [Parameter]
        public bool Divider { set; get; } = false;

        /// <summary>
        /// This prop can help a person know which element has the keyboard focus.
        /// The class name will be applied when the element gain the focus through a keyboard interaction.
        /// It's a polyfill for the [CSS :focus-visible selector](https://drafts.csswg.org/selectors-4/#the-focus-visible-pseudo).
        /// The rationale for using this feature [is explained here](https://github.com/WICG/focus-visible/blob/master/explainer.md).
        /// A [polyfill can be used](https://github.com/WICG/focus-visible) to apply a `focus-visible` class to other components
        /// if needed.
        /// </summary>
        [Parameter]
        public string FocusVisibleClass { set; get; }

        /// <summary>
        /// Secondary Action content.
        /// </summary>
        [Parameter]
        public RenderFragment SecondaryActionContent { set; get; }

        /// <summary>
        /// Use to apply selected styling.
        /// </summary>
        [Parameter]
        public bool Selected { set; get; } = false;

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string ContainerComponent { set; get; } = "li";

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
        /// <c>style</c> applied on the <c>Dense</c> element.
        /// </summary>
        [Parameter]
        public string DenseStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Dense</c> element.
        /// </summary>
        [Parameter]
        public string DenseClass { set; get; }

        [CascadingParameter]
        public IListContext Context { set; get; }

        [Inject]
        private DomHelpers DomHelpers { get; set; }

        protected IListItemContext GetItemContext(IComponentContext context) => new ListItemContextBuilder()
            .With(context)
            .WithClass(_Class)
            .WithStyle(_Style)
            .WithRefBack(ChildRef)
            .WithButton(Button)
            .WithOnClick(HandleClick)
            .WithFocusVisibleClass(_FocusVisibleClass)
            .Build();

        protected string _Component
        {
            get
            {
                var component = Component ?? "li";
                if (string.IsNullOrWhiteSpace(component) && Button)
                {
                    component = "div";
                }
                if (component == "li" && (HasSecondaryAction && ContainerComponent == "li"))
                {
                    component = "div";
                }
                return component;
            }
        }

        protected bool IsDense => Dense ?? Context?.Dense ?? false;

        protected bool HasSecondaryAction => SecondaryActionContent != null;

        public IListContext ChildContext => new ListContextBuilder()
            .WithDense(IsDense)
            .WithAlignItems(AlignItems)
            .Build();

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                if (IsDense)
                {
                    foreach (var item in CssUtil.ToStyles(DenseStyle))
                        yield return item;
                }
            }
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (IsDense)
                {
                    yield return "Dense";

                    if (!string.IsNullOrWhiteSpace(DenseClass))
                        yield return DenseClass;
                }

                if (!DisableGutters)
                    yield return "Gutters";

                if (Divider)
                    yield return $"{nameof(Divider)}";

                if (Button)
                    yield return $"{nameof(Button)}";

                if (AlignItems == AlignItems.FlexStart)
                    yield return $"{nameof(AlignItems)}-{AlignItems}";

                if (HasSecondaryAction)
                    yield return $"SecondaryAction";

                if (Selected)
                    yield return $"{nameof(Selected)}";
            }
        }

        protected virtual string _FocusVisibleClass
        {
            get => CssUtil.ToClass($"{Selector}-FocusVisible", FocusVisibleClasses, FocusVisibleClass);
        }

        protected virtual IEnumerable<string> FocusVisibleClasses
        {
            get
            {
                yield return string.Empty;
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
                yield return string.Empty;
            }
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (AutoFocus)
            {
                var elementRef = RootRef.Current;

                await DomHelpers.FocusAsync(elementRef);
            }
        }
    }
}
