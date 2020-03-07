using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.Card
{
    public class CardComponent : MaterialComponent
    {
        public CardComponent() : base("Card")
        {
        }

        /// <summary>
        /// If <c>true</c>, the card will use raised styling.
        /// </summary>
        [Parameter]
        public bool Raised { set; get; }

        protected int Elevation => Raised ? 8 : 1;
    }
}
