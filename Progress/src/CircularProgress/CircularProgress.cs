using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Skclusive.Material.Progress
{
    public class CircularProgressComponent : MaterialComponentBase
    {
        public CircularProgressComponent() : base("CircularProgress")
        {
        }

        /// <summary>
        /// The <see cref="CircularProgressVariant" /> to use.
        /// Use Indeterminate when there is no progress value.
        /// </summary>
        [Parameter]
        public CircularProgressVariant Variant { set; get; } = CircularProgressVariant.Indeterminate;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Primary;

        /// <summary>
        /// If <c>true</c>, the shrink animation is disabled.
        /// This only works if variant is <c>Indeterminate</c>.
        /// </summary>
        [Parameter]
        public bool DisableShrink { set; get; } = false;

        // [Parameter]
        // public int Maximum { set; get; } = 100;

        // [Parameter]
        // public int Minimum { set; get; } = 0;

        /// <summary>
        /// The size of the circle.
        /// If using a number, the pixel unit is assumed.
        /// If using a string, you need to provide the CSS unit, e.g '3rem'.
        /// </summary>
        [Parameter]
        public int Size { set; get; } = 40;

        /// <summary>
        /// The value of the progress indicator for the determinate and static variants.
        /// Value between 0 and 100.
        /// </summary>
        [Parameter]
        public decimal Value { set; get; } = 0;

        /// <summary>
        /// The thickness of the circle.
        /// </summary>
        [Parameter]
        public decimal Thickness { set; get; } = 3.6M;

        /// <summary>
        /// <c>style</c> applied on the <c>Svg</c> element.
        /// </summary>
        [Parameter]
        public string SvgStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Svg</c> element.
        /// </summary>
        [Parameter]
        public string SvgClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Circle</c> element.
        /// </summary>
        [Parameter]
        public string CircleStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Circle</c> element.
        /// </summary>
        [Parameter]
        public string CircleClass { set; get; }

        public decimal Relative => Value;
        //{
        //    get
        //    {
        //        return GetRelative(Value, Minimum, Maximum);
        //    }
        //}

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Color != Color.Inherit)
                    yield return $"{nameof(Color)}-{Color}";

                if (Variant == CircularProgressVariant.Indeterminate || Variant == CircularProgressVariant.Static)
                    yield return $"{Variant}";
            }
        }

        protected string Transform
        {
            get
            {
                decimal transform = Variant == CircularProgressVariant.Static ? -90 : EaseOut(Relative / 70) * 270;

                return $"rotate({transform.ToString(CultureInfo.InvariantCulture)}deg)";
            }
        }

        protected string ValueNow => $"{Math.Round(Relative).ToString(CultureInfo.InvariantCulture)}";

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("width", $"{Size.ToString(CultureInfo.InvariantCulture)}px");

                yield return Tuple.Create<string, object>("height", $"{Size.ToString(CultureInfo.InvariantCulture)}px");

                if (Variant == CircularProgressVariant.Determinate || Variant == CircularProgressVariant.Static)
                {
                    yield return Tuple.Create<string, object>("transform", Transform);
                }
            }
        }

        protected string ViewBox => $"{(SIZE / 2).ToString(CultureInfo.InvariantCulture)} {(SIZE / 2).ToString(CultureInfo.InvariantCulture)} {SIZE.ToString(CultureInfo.InvariantCulture)} {SIZE.ToString(CultureInfo.InvariantCulture)}";

        protected decimal Cx => SIZE;

        protected decimal Cy => SIZE;

        protected decimal Radius => (SIZE - Thickness) / 2;

        protected decimal Circumference => 2 * ((decimal)Math.PI) * Radius;

        protected string StrokeDashoffset
        {
            get
            {
                var offset = Variant == CircularProgressVariant.Static ?
                    (100 - Relative) / 100 * Circumference
                    : EaseIn((100 - Relative) / 100) * Circumference;

                return $"{offset.ToString(CultureInfo.InvariantCulture)}px";
            }
        }

        protected virtual string _CircleStyle
        {
            get => CssUtil.ToStyle(CircleStyles, CircleStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> CircleStyles
        {
            get
            {
                if (Variant == CircularProgressVariant.Determinate || Variant == CircularProgressVariant.Static)
                {
                    yield return Tuple.Create<string, object>("stroke-dasharray", Circumference);

                    yield return Tuple.Create<string, object>("stroke-dashoffset", StrokeDashoffset);
                }
            }
        }

        protected virtual string _CircleClass
        {
            get => CssUtil.ToClass($"{Selector}-Circle", CircleClasses, CircleClass);
        }

        protected virtual IEnumerable<string> CircleClasses
        {
            get
            {
                yield return string.Empty;

                if (Variant == CircularProgressVariant.Indeterminate || Variant == CircularProgressVariant.Static)
                    yield return $"{Variant}";

                if (DisableShrink)
                    yield return $"{nameof(DisableShrink)}";
            }
        }

        protected virtual string _SvgClass
        {
            get => CssUtil.ToClass($"{Selector}-Svg", SvgClasses, SvgClass);
        }

        protected virtual IEnumerable<string> SvgClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected virtual string _SvgStyle
        {
            get => CssUtil.ToStyle(SvgStyles, SvgStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> SvgStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        public static readonly decimal SIZE = 44;

        static decimal GetRelative(decimal value, int min, int max)
        {
            return (Math.Min(Math.Max(min, value), max) - min) / (max - min);
        }

        static decimal EaseOut(decimal value)
        {
            var t = GetRelative(value, 0, 1);
            // https://gist.github.com/gre/1650294
            t = (t -= 1) * t * t + 1;
            return t;
        }

        static decimal EaseIn(decimal value)
        {
            return value * value;
        }
    }
}
