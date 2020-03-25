using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Skclusive.Core.Component;
using System;
using System.Linq;

namespace Skclusive.Material.Button
{
    public class ButtonComponent : ButtonCommonComponent
    {
        public ButtonComponent() : base("Button")
        {
        }

        protected ElementReference Button { set; get; }

        /// <summary>
        /// The <see cref="ButtonType" /> of the button.
        /// </summary>
        [Parameter]
        public ButtonType Type { set; get; } = ButtonType.Button;

        /// <summary>
        /// The <see cref="ButtonVariant" /> of the button.
        /// </summary>
        [Parameter]
        public ButtonVariant Variant { set; get; } = ButtonVariant.Text;

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
            }
        }
    }
}
