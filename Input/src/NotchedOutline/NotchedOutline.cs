using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Skclusive.Material.Form;
using System.Linq;
using Skclusive.Core.Component;
using System;
using System.Globalization;

namespace Skclusive.Material.Input
{
    public class NotchedOutlineComponent : FormConfigContext
    {
        public NotchedOutlineComponent() : base("NotchedOutline")
        {
        }

        /// <summary>
        /// If <c>true</c>, the outline is notched to accommodate the label.
        /// </summary>
        [Parameter]
        public bool Notched  { set; get; }

        /// <summary>
        /// The width of the label.
        /// </summary>
        [Parameter]
        public double LabelWidth { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Legend</c> element.
        /// </summary>
        [Parameter]
        public string LegendStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Legend</c> element.
        /// </summary>
        [Parameter]
        public string LegendClass { set; get; }

        protected double _LabelWidth => LabelWidth > 0 ? LabelWidth * 0.75 + 8 : 0;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;
            }
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("padding-left", $"{(8 + (Notched ? 0 : _LabelWidth / 2)).ToString(CultureInfo.InvariantCulture)}px");
            }
        }

        protected virtual string _LegendStyle
        {
            get => CssUtil.ToStyle(LegendStyles, LegendStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> LegendStyles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                var finalWidth = Notched ? _LabelWidth : 0.01;
                yield return Tuple.Create<string, object>("width", $"{finalWidth.ToString(CultureInfo.InvariantCulture)}px");
            }
        }

        protected virtual string _LegendClass
        {
            get => CssUtil.ToClass($"{Selector}-Legend", LegendClasses, LegendClass);
        }

        protected virtual IEnumerable<string> LegendClasses
        {
            get
            {
                yield return string.Empty;
            }
        }
    }
}
