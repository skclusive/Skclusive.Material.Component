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

        [Parameter]
        public string Component { set; get; } = "span";

        [Parameter]
        public string Nib { set; get; }

        [Parameter]
        public NibVariant Variant { set; get; } = NibVariant.Standard;

        [Parameter]
        public NibOverlap Overlap { set; get; } = NibOverlap.Rectangle;

        [Parameter]
        public Horizontal Horizontal { set; get; } = Horizontal.Right;

        [Parameter]
        public Vertical Vertical { set; get; } = Vertical.Top;

        [Parameter]
        public bool ShowZero { set; get; } = false;

        [Parameter]
        public bool? Invisible { set; get; }

        [Parameter]
        public int Max { set; get; } = 99;

        [Parameter]
        public Color Color { set; get; } = Color.Default;

        [Parameter]
        public string NibStyle { set; get; }

        [Parameter]
        public string NibClass { set; get; }

        protected int? NibNumber
        {
            get => int.TryParse(Nib, out int result) ? (int?)result : null;
        }

        protected bool NibInvisible
        {
            get
            {
                if(Invisible.HasValue)
                {
                    return Invisible.Value;
                }

                var nibNumber = NibNumber;

                if(nibNumber.HasValue && nibNumber.Value == 0 && !ShowZero)
                {
                    return true;
                }

                if(string.IsNullOrWhiteSpace(Nib) && Variant != NibVariant.Dot)
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
                if(Variant == NibVariant.Dot)
                {
                    return string.Empty;
                }

                var nibNumber = NibNumber;

                if(nibNumber.HasValue && nibNumber.Value > Max)
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

                if(NibInvisible)
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

    public enum Horizontal
    {
        Left,

        Right
    }

    public enum Vertical
    {
        Bottom,

        Top
    }
}
