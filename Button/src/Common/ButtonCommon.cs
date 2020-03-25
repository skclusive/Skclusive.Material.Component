using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using Skclusive.Core.Component;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Skclusive.Material.Button
{
    public abstract class ButtonCommonComponent : MaterialComponentBase
    {
        protected ButtonCommonComponent(string selector) : base(selector)
        {
        }

        /// <summary>
        /// Reference attached to the child element of the component.
        /// </summary>
        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        /// <summary>
        /// ChildContent of the current component which gets component <see cref="IComponentContext" />.
        /// </summary>
        [Parameter]
        public RenderFragment<IComponentContext> ChildContent { get; set; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; }

        /// <summary>
        /// If `true`, the ripple effect will be disabled.
        ///
        /// ⚠️ Without a ripple there is no styling for :focus-visible by default. Be sure
        /// to highlight the element by applying separate styles with the `focusVisibleClassName`.
        /// </summary>
        [Parameter]
        public bool DisableRipple { set; get; }

        /// <summary>
        /// If <c>true</c>, the touch ripple effect will be disabled.
        /// </summary>
        [Parameter]
        public bool DisableTouchRipple { set; get; }

        /// <summary>
        /// If <c>true</c>, the  keyboard focus ripple will be disabled.
        /// <c>disableRipple</c> must also be true.
        /// </summary>
        [Parameter]
        public bool DisableFocusRipple { set; get; }

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
        /// The <c>class</c> applied to the label.
        /// </summary>
        [Parameter]
        public string LabelClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the label.
        /// </summary>
        [Parameter]
        public string LabelStyle { set; get; }

        /// <summary>
        /// The URL to link to when the button is clicked.
        /// If defined, an <c>a</c> element will be used as the root node.
        /// </summary>
        [Parameter]
        public string Href { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Default;

        protected virtual string _LabelClass
        {
            get => CssUtil.ToClass(Selector, LabelClasses, LabelClass);
        }

        protected virtual IEnumerable<string> LabelClasses
        {
            get
            {
                yield return "Label";
            }
        }

        protected virtual string _LabelStyle
        {
            get => CssUtil.ToStyle(LabelStyles, LabelStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> LabelStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }
    }
}
