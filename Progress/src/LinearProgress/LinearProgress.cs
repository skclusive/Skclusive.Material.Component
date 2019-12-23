using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;

namespace Skclusive.Material.Progress
{
    public class LinearProgressComponent : MaterialComponentBase
    {
        public LinearProgressComponent() : base("LinearProgress")
        {
        }

        [Parameter]
        public LinearVariant Variant { set; get; } = LinearVariant.Indeterminate;

        [Parameter]
        public Color Color { set; get; } = Color.Primary;

        [Parameter]
        public decimal Value { set; get; } = 0;

        [Parameter]
        public double ValueBuffer { set; get; }

        [Parameter]
        public string Bar1Style { set; get; }

        [Parameter]
        public string Bar2Style { set; get; }

        [Parameter]
        public string Bar1Class { set; get; }

        [Parameter]
        public string Bar2Class { set; get; }

        [Parameter]
        public string DashedClass { set; get; }

        protected string ValueNow
        {
            get
            {
                decimal? value = null;
                if (Variant == LinearVariant.Determinate || Variant == LinearVariant.Buffer)
                {
                    value = Math.Round(Value);
                }
                return value != null ? $"{value}" : null;
            }
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Color == Color.Primary || Color == Color.Secondary)
                    yield return $"{nameof(Color)}-{Color}";

                yield return $"{Variant}";
            }
        }

        protected virtual string _Bar1Style
        {
            get => CssUtil.ToStyle(Bar1Styles, Bar1Style);
        }

        protected virtual IEnumerable<Tuple<string, object>> Bar1Styles
        {
            get
            {
                if (Variant == LinearVariant.Determinate || Variant == LinearVariant.Buffer)
                {
                    yield return Tuple.Create<string, object>("transform", $"translateX({Value - 100})");
                }
            }
        }

        protected virtual string _Bar2Style
        {
            get => CssUtil.ToStyle(Bar2Styles, Bar2Style);
        }

        protected virtual IEnumerable<Tuple<string, object>> Bar2Styles
        {
            get
            {
                if (Variant == LinearVariant.Buffer)
                {
                    yield return Tuple.Create<string, object>("transform", $"translateX({ValueBuffer - 100})");
                }
            }
        }


        protected virtual string _DashedClass
        {
            get => CssUtil.ToClass($"{Selector}-Dashed", DashedClasses, DashedClass);
        }

        protected virtual IEnumerable<string> DashedClasses
        {
            get
            {
                yield return string.Empty;

                if (Color == Color.Primary || Color == Color.Secondary)
                    yield return $"{nameof(Color)}-{Color}";
            }
        }

        protected virtual string _Bar1Class
        {
            get => CssUtil.ToClass(Selector, Bar1Classes, Bar1Class);
        }

        protected virtual IEnumerable<string> Bar1Classes
        {
            get
            {
                yield return "Bar";

                if (Color == Color.Primary || Color == Color.Secondary)
                    yield return $"Bar-{nameof(Color)}-{Color}";

                if (Variant == LinearVariant.Indeterminate || Variant == LinearVariant.Query)
                    yield return $"Bar1-{nameof(LinearVariant.Indeterminate)}";

                if (Variant == LinearVariant.Determinate)
                    yield return $"Bar1-{nameof(LinearVariant.Determinate)}";

                if (Variant == LinearVariant.Buffer)
                    yield return $"Bar1-{nameof(LinearVariant.Buffer)}";
            }
        }

        protected virtual string _Bar2Class
        {
            get => CssUtil.ToClass(Selector, Bar2Classes, Bar2Class);
        }

        protected virtual IEnumerable<string> Bar2Classes
        {
            get
            {
                yield return "Bar";

                if (Color == Color.Primary || Color == Color.Secondary)
                {
                    if (Variant != LinearVariant.Buffer)
                        yield return $"Bar-{nameof(Color)}-{Color}";

                    if (Variant == LinearVariant.Buffer)
                        yield return $"{nameof(Color)}-{Color}";
                }

                if (Variant == LinearVariant.Indeterminate || Variant == LinearVariant.Query)
                    yield return $"Bar2-{nameof(LinearVariant.Indeterminate)}";

                if (Variant == LinearVariant.Buffer)
                    yield return $"Bar2-{nameof(LinearVariant.Buffer)}";
            }
        }
    }

    public enum LinearVariant
    {
        Determinate,

        Indeterminate,

        Buffer,

        Query
    }
}
