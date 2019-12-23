using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.Card
{
    public class CardContentComponent : MaterialComponent
    {
        public CardContentComponent() : base("CardContent")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";
    }
}
