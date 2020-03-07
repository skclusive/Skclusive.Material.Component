using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.Card
{
    public class CardActionsComponent : MaterialComponent
    {
        public CardActionsComponent() : base("CardActions")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, the actions do not have additional margin.
        /// </summary>
        [Parameter]
        public bool DisableSpacing { set; get; } = false;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (!DisableSpacing)
                    yield return "Spacing";
            }
        }
    }
}
