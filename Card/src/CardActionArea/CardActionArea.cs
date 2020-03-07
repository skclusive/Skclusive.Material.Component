using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Card
{
    public class CardActionAreaComponent : MaterialComponent
    {
        public CardActionAreaComponent() : base("CardActionArea")
        {
        }

        /// <summary>
        /// <c>class</c> applied when the area is focused.
        /// </summary>
        [Parameter]
        public string FocusVisibleClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the highlight element.
        /// </summary>
        [Parameter]
        public string HighlightStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the highlight element.
        /// </summary>
        [Parameter]
        public string HighlightClass { set; get; }

        protected virtual string _HighlightStyle
        {
            get => CssUtil.ToStyle(HighlightStyles, HighlightStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> HighlightStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _HighlightClass
        {
            get => CssUtil.ToClass(Selector, HighlightClasses, HighlightClass);
        }

        protected virtual IEnumerable<string> HighlightClasses
        {
            get
            {
                yield return "Highlight";
            }
        }

    }
}
