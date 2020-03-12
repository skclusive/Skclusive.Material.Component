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
        public string Badge { set; get; }

        /// <summary>
        /// If the badge value is component use <c>BadgeContent</c>
        /// </summary>
        [Parameter]
        public RenderFragment BadgeContent { set; get; }

        /// <summary>
        /// The <see cref="BadgeVariant"> variant to use.
        /// </summary>
        [Parameter]
        public BadgeVariant Variant { set; get; } = BadgeVariant.Standard;

        /// <summary>
        /// The <see cref="BadgeOverlap"> overlap to use.
        /// </summary>
        [Parameter]
        public BadgeOverlap Overlap { set; get; } = BadgeOverlap.Rectangle;

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
        /// Controls whether the badge is hidden when <see cref="Badge" /> is zero.
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
        /// <c>style</c> applied on the <c>Badge</c> element.
        /// </summary>
        [Parameter]
        public string BadgeStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Badge</c> element.
        /// </summary>
        [Parameter]
        public string BadgeClass { set; get; }

        protected bool CanRenderContent => Variant != BadgeVariant.Dot && BadgeContent != null;

        protected int? BadgeNumber
        {
            get => int.TryParse(Badge, out int result) ? (int?)result : null;
        }

        protected bool BadgeInvisible
        {
            get
            {
                if (Invisible.HasValue)
                {
                    return Invisible.Value;
                }

                var nibNumber = BadgeNumber;

                if (nibNumber.HasValue && nibNumber.Value == 0 && !ShowZero)
                {
                    return true;
                }

                if (string.IsNullOrEmpty(Badge) && BadgeContent == null && Variant != BadgeVariant.Dot)
                {
                    return true;
                }

                return false;
            }
        }

        protected string BadgeDisplay
        {
            get
            {
                if (Variant == BadgeVariant.Dot)
                {
                    return string.Empty;
                }

                var nibNumber = BadgeNumber;

                if (nibNumber.HasValue && nibNumber.Value > Max)
                {
                    return $"{Max}+";
                }

                return Badge;
            }
        }

        protected virtual string _BadgeStyle
        {
            get => CssUtil.ToStyle(BadgeStyles, BadgeStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> BadgeStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _BadgeClass
        {
            get => CssUtil.ToClass(Selector, BadgeClasses, BadgeClass);
        }

        protected virtual IEnumerable<string> BadgeClasses
        {
            get
            {
                yield return nameof(Badge);

                if (Color != Color.Default)
                    yield return $"{nameof(Color)}-{Color}";

                if (BadgeInvisible)
                    yield return $"{nameof(Invisible)}";

                if (Variant == BadgeVariant.Dot)
                    yield return $"{Variant}";

                yield return $"{Vertical}-{Horizontal}-{Overlap}";
            }
        }
    }
}
