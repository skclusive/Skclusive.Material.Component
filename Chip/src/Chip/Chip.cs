using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Material.Button;
using Skclusive.Material.Core;
using Skclusive.Script.DomHelpers;
using TouchPoint = Skclusive.Material.Button.TouchPoint;

namespace Skclusive.Material.Chip
{
    public class ChipComponent : MaterialComponentBase
    {
        public ChipComponent() : base("Chip")
        {
        }

        /// <summary>
        /// If `true`, the chip will hover on mouse over and ripple on click.
        /// </summary>
        [Parameter]
        public bool IsClickable { get; set; } = true;

        /// <summary>
        /// If `true`, show a clickable delete icon and hide the chip when deleted.
        /// </summary>
        [Parameter]
        public bool IsDeletable { get; set; }

        /// <summary>
        /// If `true`, the chip is not rendered. Usually this is a result of clicking the delete button of a deletable chip.
        /// </summary>
        [Parameter]
        public bool IsDeleted { get; set; }

        [Parameter]
        public EventCallback<bool> IsDeletedChanged { get; set; }

        /// <summary>
        /// The <see cref="ButtonType" /> of the button.
        /// </summary>
        [Parameter]
        public ButtonType Type { set; get; } = ButtonType.Button;

        /// <summary>
        /// The <see cref="ButtonVariant" /> of the button.
        /// </summary>
        [Parameter]
        public ButtonVariant Variant { set; get; } = ButtonVariant.Text; // TODO: define ChipVariant

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Size" /> of the button.
        /// </summary>
        [Parameter]
        public Size Size { set; get; } = Size.Medium;

        /// <summary>
        /// If `true`, the button will take up the full width of its container.
        /// </summary>
        [Parameter]
        public bool FullWidth { set; get; }

        /// <summary>
        /// Element placed before the children.
        /// </summary>
        [Parameter]
        public RenderFragment StartIcon { set; get; }

        /// <summary>
        /// Element placed after the children.
        /// </summary>
        [Parameter]
        public RenderFragment EndIcon { set; get; }

        /// <summary>
        /// The <c>style</c> applied on the start icon.
        /// </summary>
        [Parameter]
        public string StartIconStyle { set; get; }

        /// <summary>
        /// The <c>class</c> applied on the start icon.
        /// </summary>
        [Parameter]
        public string StartIconClass { set; get; }

        /// <summary>
        /// The <c>style</c> applied on the end icon.
        /// </summary>
        [Parameter]
        public string EndIconStyle { set; get; }

        /// <summary>
        /// The <c>class</c> applied on the end icon.
        /// </summary>
        [Parameter]
        public string EndIconClass { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return Variant.ToString();

                if (Color != Color.Default && Color != Color.Inherit)
                    yield return $"{Variant}-{Color}";

                if (Size != Size.Medium)
                    yield return $"{nameof(Size)}-{Size}";

                if (Size != Size.Medium)
                    yield return $"{Variant}-{nameof(Size)}-{Size}";

                if (Color == Color.Inherit)
                    yield return $"{nameof(Color)}-{nameof(Color.Inherit)}";

                if (FullWidth)
                    yield return nameof(FullWidth);

                if (!IsClickable)
                    yield return $"Basic";

                if (IsDeleted)
                    yield return "Deleted";

            }
        }

        protected virtual string _FocusVisibleClass
        {
            get => CssUtil.ToClass(Selector, FocusVisibleClasses, FocusVisibleClass);
        }

        protected virtual IEnumerable<string> FocusVisibleClasses
        {
            get
            {
                yield return "FocusVisible";
            }
        }

        protected virtual string _StartIconStyle
        {
            get => CssUtil.ToStyle(StartIconStyles, StartIconStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> StartIconStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _StartIconClass
        {
            get => CssUtil.ToClass(Selector, StartIconClasses, StartIconClass);
        }

        protected virtual IEnumerable<string> StartIconClasses
        {
            get
            {
                yield return nameof(StartIcon);

                yield return $"Icon-{nameof(Size)}-{Size}";
            }
        }

        protected virtual string _EndIconStyle
        {
            get => CssUtil.ToStyle(EndIconStyles, EndIconStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> EndIconStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _EndIconClass
        {
            get => CssUtil.ToClass(Selector, EndIconClasses, EndIconClass);
        }

        protected virtual IEnumerable<string> EndIconClasses
        {
            get
            {
                yield return nameof(EndIcon);

                yield return $"Icon-{nameof(Size)}-{Size}";

                if (IsDeletable)
                    yield return "EndIcon-Delete";
            }
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
        //[Parameter]
        internal bool DisableRipple => !IsClickable;

        /// <summary>
        /// If <c>true</c>, the touch ripple effect will be disabled.
        /// </summary>
        //[Parameter]
        internal bool DisableTouchRipple => !IsClickable;

        /// <summary>
        /// If <c>true</c>, the  keyboard focus ripple will be disabled.
        /// <c>disableRipple</c> must also be true.
        /// </summary>
        //[Parameter]
        internal bool DisableFocusRipple => !IsClickable;

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

        protected virtual void _OnDeleteClick(MouseEventArgs e)
        {
            if (!IsDeletable)
                return;
            OnDeleteClick.InvokeAsync(e);
            IsDeleted = true;
            this.StateHasChanged();
            IsDeletedChanged.InvokeAsync(true);
        }

        [Parameter]
        public EventCallback<MouseEventArgs> OnDeleteClick { get; set; }
    }
}
