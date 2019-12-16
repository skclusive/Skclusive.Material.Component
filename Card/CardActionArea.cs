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

        [Parameter]
        public string FocusVisibleClass { set; get; }

        [Parameter]
        public string HighlightStyle { set; get; }

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
