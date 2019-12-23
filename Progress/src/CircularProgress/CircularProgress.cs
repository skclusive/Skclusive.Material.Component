using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;

namespace Skclusive.Material.Progress
{
    public class CircularProgressComponent : MaterialComponentBase
    {
        public CircularProgressComponent() : base("CircularProgress")
        {
        }

        [Parameter]
        public CircularVariant Variant { set; get; } = CircularVariant.Indeterminate;

        [Parameter]
        public Color Color { set; get; } = Color.Primary;

        [Parameter]
        public bool DisableShrink { set; get; } = false;

        [Parameter]
        public int Maximum { set; get; } = 100;

        [Parameter]
        public int Minimum { set; get; } = 0;

        [Parameter]
        public int Size { set; get; } = 40;

        [Parameter]
        public decimal Value { set; get; } = 0;

        [Parameter]
        public decimal Thickness { set; get; } = 3.6M;

        [Parameter]
        public string SvgClass { set; get; }

        [Parameter]
        public string CircleStyle { set; get; }

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

                if (Variant == CircularVariant.Indeterminate || Variant == CircularVariant.Static)
                    yield return $"{Variant}";
            }
        }

        protected string Transform
        {
            get
            {
                decimal transform = Variant == CircularVariant.Static ? -90 : EaseOut(Relative / 70) * 270;

                return $"rotate({transform}deg)";
            }
        }

        protected string ValueNow => $"{Math.Round(Relative)}";
        
        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("width", $"{Size}px");

                yield return Tuple.Create<string, object>("height", $"{Size}px");

                if (Variant == CircularVariant.Determinate || Variant == CircularVariant.Static)
                {
                    yield return Tuple.Create<string, object>("transform", Transform);
                }
            }
        }

        protected string ViewBox => $"{SIZE / 2} {SIZE / 2} {SIZE} {SIZE}";

        protected decimal Cx => SIZE;

        protected decimal Cy => SIZE;

        protected decimal Radius => (SIZE - Thickness) / 2;

        protected decimal Circumference => 2 * ((decimal)Math.PI) * Radius;

        protected string StrokeDashoffset
        {
            get
            {
                var offset = Variant == CircularVariant.Static ?
                    (100 - Relative) / 100 * Circumference
                    : EaseIn((100 - Relative) / 100) * Circumference;

                return $"{offset}px";
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
                if (Variant == CircularVariant.Determinate || Variant == CircularVariant.Static)
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

                if (Variant == CircularVariant.Indeterminate || Variant == CircularVariant.Static)
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

    public enum CircularVariant
    {
        Determinate,

        Indeterminate,

        Static
    }
}
