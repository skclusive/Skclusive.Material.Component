using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.Card
{
    public class CardComponent : MaterialComponent
    {
        public CardComponent() : base("Card")
        {
        }

        [Parameter]
        public bool Raised { set; get; }

        protected int Elevation
        {
            get => Raised ? 8 : 1;
        }
    }
}
