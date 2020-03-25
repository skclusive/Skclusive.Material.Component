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
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// Shadow depth, corresponds to `dp` in the spec.
        /// It accepts values between 0 and 24 inclusive.
        /// </summary>
        [Parameter]
        public int Elevation { set; get; } = 1;

        /// <summary>
        /// If <c>true</c>, rounded corners are disabled.
        /// </summary>
        [Parameter]
        public bool Square { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the card will use raised styling.
        /// </summary>
        [Parameter]
        public bool Raised { set; get; }

        protected int _Elevation => Raised ? 8 : Elevation;
    }
}
