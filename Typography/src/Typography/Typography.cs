using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using System.Collections.Generic;
using Skclusive.Core.Component;
using Microsoft.AspNetCore.Components.Web;

namespace Skclusive.Material.Typography
{
    public class Typography : MaterialComponent
    {
        public Typography() : base("Typography")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; }

        /// <summary>
        /// The <see cref="TypographyVariant"> variant to use.
        /// </summary>
        [Parameter]
        public TypographyVariant Variant { set; get; } = TypographyVariant.Body1;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Align" /> which set the <c>text-align</c> on the component.
        /// </summary>
        [Parameter]
        public Align Align { set; get; } = Align.Inherit;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Display" /> which controls the display type.
        /// </summary>
        [Parameter]
        public Display Display { set; get; } = Display.Initial;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Initial;

        /// <summary>
        /// If <c>true</c>, the text will have a bottom margin.
        /// </summary>
        [Parameter]
        public bool GutterBottom { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the text will not wrap, but instead will truncate with a text overflow ellipsis.
        /// <remarks>
        /// Note that text overflow can only happen with block or inline-block level elements
        /// (the element needs to have a width in order to overflow).
        /// </remarks>
        /// </summary>
        [Parameter]
        public bool NoWrap { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the text will have a bottom margin.
        /// </summary>
        [Parameter]
        public bool Paragraph { set; get; } = false;

        protected string _Component
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Component))
                {
                    return Component;
                }

                if (Paragraph)
                {
                    return "p";
                }

                if (VariantComponents.ContainsKey(Variant))
                {
                    return VariantComponents[Variant];
                }

                return "span";
            }
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Variant != TypographyVariant.Inherit)
                    yield return Variant.ToString();

                if (Color != Color.Initial)
                    yield return $"{nameof(Color)}-{Color}";

                if (NoWrap)
                    yield return nameof(NoWrap);

                if (Paragraph)
                    yield return nameof(Paragraph);

                if (GutterBottom)
                    yield return nameof(GutterBottom);

                if (Align != Align.Inherit)
                    yield return $"{nameof(Align)}-{Align}";

                if (Display != Display.Initial)
                    yield return $"{nameof(Display)}-{Display}";
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenElement(0, _Component);
            builder.AddAttribute(1, "class", _Class);
            builder.AddAttribute(2, "style", _Style);
            if (OnClick.HasDelegate)
                builder.AddAttribute(3, "onclick", EventCallback.Factory.Create(this, HandleClick));
            if (OnMouseLeave.HasDelegate)
                builder.AddAttribute(4, "onmouseleave", EventCallback.Factory.Create(this, HandleMouseLeaveAsync));
            if (OnMouseEnter.HasDelegate)
                builder.AddAttribute(5, "onmouseenter", EventCallback.Factory.Create(this, HandleMouseEnterAsync));
            if (OnFocus.HasDelegate)
                builder.AddAttribute(6, "onfocus", EventCallback.Factory.Create<FocusEventArgs>(this, HandleFocusAsync));
            if (OnBlur.HasDelegate)
                builder.AddAttribute(7, "onblur", EventCallback.Factory.Create<FocusEventArgs>(this, HandleBlurAsync));
            if (!string.IsNullOrWhiteSpace(Id))
                builder.AddAttribute(8, "id", Id);
            builder.AddMultipleAttributes(9, Attributes);
            builder.AddContent(8, ChildContent);
            builder.AddElementReferenceCapture(10, (__value) => {
                RootRef.Current = (ElementReference)__value;
            });
            builder.CloseElement();
        }

        private static readonly IDictionary<TypographyVariant, string> VariantComponents = new Dictionary<TypographyVariant, string>()
        {
            { TypographyVariant.Caption, "span" },

            { TypographyVariant.H1, "h1" },

            { TypographyVariant.H2, "h2" },

            { TypographyVariant.H3, "h3" },

            { TypographyVariant.H4, "h4" },

            { TypographyVariant.H5, "h5" },

            { TypographyVariant.H6, "h6" },

            { TypographyVariant.Subtitle1, "h6" },

            { TypographyVariant.Subtitle2, "h6" },

            { TypographyVariant.Body1, "p" },

            { TypographyVariant.Body2, "p" }
        };
    }
}
