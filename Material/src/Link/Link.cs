using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Typography;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Component
{
    public class LinkComponent : MaterialComponent
    {
        public LinkComponent() : base("Link")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "a";

        /// <summary>
        /// The <see cref="LinkVariant"> variant to use.
        /// </summary>
        [Parameter]
        public LinkVariant Variant { set; get; } = LinkVariant.Inherit;

        /// <summary>
        /// Controls when the link should have an underline.
        /// </summary>
        [Parameter]
        public Underline Underline { set; get; } = Underline.Hover;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Primary;

        /// <summary>
        /// The URL to link to when clicked.
        /// </summary>
        [Parameter]
        public string Href { set; get; }

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

        protected TypographyVariant _Variant => (TypographyVariant)Enum.Parse(typeof(TypographyVariant), Variant.ToString());

        protected bool FocusVisible { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (FocusVisible)
                    yield return nameof(FocusVisible);

                if (Component == "button")
                    yield return "Button";

                yield return $"{nameof(Underline)}-{Underline}";
            }
        }

        protected override void HandleFocus(FocusEventArgs args)
        {
            FocusVisible = true;

            base.HandleFocus(args);
        }

        protected override void HandleBlur(FocusEventArgs args)
        {
            FocusVisible = false;

            base.HandleBlur(args);
        }
    }
}
