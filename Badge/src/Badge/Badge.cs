using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Badge
{
    public class BadgeComponent : MaterialComponent
    {
        public BadgeComponent() : base("Badge")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "span";

        /// <summary>
        /// badge value to be displayed.
        /// </summary>
        [Parameter]
        public string Nib { set; get; }

        /// <summary>
        /// The <see cref="NibVariant"> variant to use.
        /// </summary>
        [Parameter]
        public NibVariant Variant { set; get; } = NibVariant.Standard;

        /// <summary>
        /// The <see cref="NibOverlap"> overlap to use.
        /// </summary>
        [Parameter]
        public NibOverlap Overlap { set; get; } = NibOverlap.Rectangle;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Horizontal" /> anchor of the badge.
        /// </summary>
        [Parameter]
        public Horizontal Horizontal { set; get; } = Horizontal.Right;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Vertical" /> anchor of the badge.
        /// </summary>
        [Parameter]
        public Vertical Vertical { set; get; } = Vertical.Top;

        /// <summary>
        /// Controls whether the badge is hidden when <see cref="Nib" /> is zero.
        /// </summary>
        [Parameter]
        public bool ShowZero { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the badge will be invisible.
        /// </summary>
        [Parameter]
        public bool? Invisible { set; get; }

        /// <summary>
        /// Max count to show.
        /// </summary>
        [Parameter]
        public int Max { set; get; } = 99;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Default;

        /// <summary>
        /// <c>style</c> applied on the <c>Nib</c> element.
        /// </summary>
        [Parameter]
        public string NibStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Nib</c> element.
        /// </summary>
        [Parameter]
        public string NibClass { set; get; }

        /// <summary>
        /// If the badge value is component use <c>NibContent</c>
        /// </summary>
        [Parameter]
        public RenderFragment NibContent { set; get; }

        protected bool CanRenderContent => Variant != NibVariant.Dot && NibContent != null;

        protected int? NibNumber
        {
            get => int.TryParse(Nib, out int result) ? (int?)result : null;
        }

        protected bool NibInvisible
        {
            get
            {
                if (Invisible.HasValue)
                {
                    return Invisible.Value;
                }

                var nibNumber = NibNumber;

                if (nibNumber.HasValue && nibNumber.Value == 0 && !ShowZero)
                {
                    return true;
                }

                if (string.IsNullOrEmpty(Nib) && NibContent == null && Variant != NibVariant.Dot)
                {
                    return true;
                }

                return false;
            }
        }

        protected string NibDisplay
        {
            get
            {
                if (Variant == NibVariant.Dot)
                {
                    return string.Empty;
                }

                var nibNumber = NibNumber;

                if (nibNumber.HasValue && nibNumber.Value > Max)
                {
                    return $"{Max}+";
                }

                return Nib;
            }
        }

        protected virtual string _NibStyle
        {
            get => CssUtil.ToStyle(NibStyles, NibStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> NibStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _NibClass
        {
            get => CssUtil.ToClass(Selector, NibClasses, NibClass);
        }

        protected virtual IEnumerable<string> NibClasses
        {
            get
            {
                yield return nameof(Nib);

                if (Color != Color.Default)
                    yield return $"{nameof(Nib)}-{Color}";

                if (NibInvisible)
                    yield return $"{nameof(Nib)}-{nameof(Invisible)}";

                if (Variant == NibVariant.Dot)
                    yield return $"{nameof(Nib)}-{Variant}";

                yield return $"{nameof(Nib)}-{Vertical}-{Horizontal}-{Overlap}";
            }
        }
    }

    public enum NibVariant
    {
        Dot,

        Standard
    }

    public enum NibOverlap
    {
        Circle,

        Rectangle
    }
}
