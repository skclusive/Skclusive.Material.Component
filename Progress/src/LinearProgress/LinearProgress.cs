using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Skclusive.Material.Progress
{
    public class LinearProgressComponent : MaterialComponentBase
    {
        public LinearProgressComponent() : base("LinearProgress")
        {
        }

        /// <summary>
        /// The <see cref="LinearProgressVariant"> variant to use.
        /// Use Indeterminate or query when there is no progress value.
        /// </summary>
        [Parameter]
        public LinearProgressVariant Variant { set; get; } = LinearProgressVariant.Indeterminate;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Primary;

        /// <summary>
        /// The value of the progress indicator for the determinate and buffer variants.
        /// Value between 0 and 100.
        /// </summary>
        [Parameter]
        public decimal Value { set; get; } = 0;

        /// <summary>
        /// The value for the buffer variant.
        /// Value between 0 and 100.
        /// </summary>
        [Parameter]
        public decimal ValueBuffer { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Bar1</c> element.
        /// </summary>
        [Parameter]
        public string Bar1Style { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Bar1</c> element.
        /// </summary>
        [Parameter]
        public string Bar1Class { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Bar2</c> element.
        /// </summary>
        [Parameter]
        public string Bar2Style { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Bar2</c> element.
        /// </summary>
        [Parameter]
        public string Bar2Class { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Dashed</c> element.
        /// </summary>
        [Parameter]
        public string DashedStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Dashed</c> element.
        /// </summary>
        [Parameter]
        public string DashedClass { set; get; }

        protected string ValueNow
        {
            get
            {
                decimal? value = null;
                if (Variant == LinearProgressVariant.Determinate || Variant == LinearProgressVariant.Buffer)
                {
                    value = Math.Round(Value);
                }
                return value.HasValue ? $"{value.Value.ToString(CultureInfo.InvariantCulture)}" : null;
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
                if (Variant == LinearProgressVariant.Determinate || Variant == LinearProgressVariant.Buffer)
                {
                    yield return Tuple.Create<string, object>("transform", $"translateX({(Value - 100).ToString(CultureInfo.InvariantCulture)}%)");
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
                if (Variant == LinearProgressVariant.Buffer)
                {
                    yield return Tuple.Create<string, object>("transform", $"translateX({(ValueBuffer - 100).ToString(CultureInfo.InvariantCulture)}%)");
                }
            }
        }

        protected virtual string _DashedStyle
        {
            get => CssUtil.ToStyle(DashedStyles, DashedStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> DashedStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
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

                if (Variant == LinearProgressVariant.Indeterminate || Variant == LinearProgressVariant.Query)
                    yield return $"Bar1-{nameof(LinearProgressVariant.Indeterminate)}";

                if (Variant == LinearProgressVariant.Determinate)
                    yield return $"Bar1-{nameof(LinearProgressVariant.Determinate)}";

                if (Variant == LinearProgressVariant.Buffer)
                    yield return $"Bar1-{nameof(LinearProgressVariant.Buffer)}";
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
                    if (Variant != LinearProgressVariant.Buffer)
                        yield return $"Bar-{nameof(Color)}-{Color}";

                    if (Variant == LinearProgressVariant.Buffer)
                        yield return $"{nameof(Color)}-{Color}";
                }

                if (Variant == LinearProgressVariant.Indeterminate || Variant == LinearProgressVariant.Query)
                    yield return $"Bar2-{nameof(LinearProgressVariant.Indeterminate)}";

                if (Variant == LinearProgressVariant.Buffer)
                    yield return $"Bar2-{nameof(LinearProgressVariant.Buffer)}";
            }
        }
    }
}
