using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using System.Collections.Generic;
using Skclusive.Core.Component;

namespace Skclusive.Material.Typography
{
    public class Typography : MaterialComponent
    {
        public Typography() : base("Typography")
        {
        }

        [Parameter]
        public TypographyVariant Variant { set; get; } = TypographyVariant.Body1;

        [Parameter]
        public Align Align { set; get; } = Align.Inherit;

        [Parameter]
        public Display Display { set; get; } = Display.Initial;

        [Parameter]
        public Color Color { set; get; } = Color.Initial;

        [Parameter]
        public bool GutterBottom { set; get; } = false;

        [Parameter]
        public bool NoWrap { set; get; } = false;

        [Parameter]
        public bool Paragraph { set; get; } = false;

        [Parameter]
        public string Component { set; get; }

        protected string _Component
        {
            get
            {
                if(!string.IsNullOrWhiteSpace(Component))
                {
                    return Component;
                }

                if(Paragraph)
                {
                    return "p";
                }

                if(VariantComponents.ContainsKey(Variant))
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
            builder.AddContent(3, "\n");
            builder.AddContent(4, ChildContent);
            builder.AddContent(5, "\n");
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

    public enum TypographyVariant
    {
        H1,

        H2,

        H3,

        H4,

        H5,

        H6,

        Subtitle1,

        Subtitle2,

        Body1,

        Body2,

        Caption,

        Button,

        Overline,

        SrOnly,

        Inherit
    }
}
