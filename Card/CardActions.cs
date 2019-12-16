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

        [Parameter]
        public string Component { set; get; } = "div";

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
