using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Divider
{
    public class DividerComponent : MaterialComponent
    {
        public DividerComponent() : base("Divider")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "hr";

        /// <summary>
        /// Absolutely position the element.
        /// </summary>
        [Parameter]
        public bool Absolute { set; get; }

        /// <summary>
        /// The <see cref="DividerVariant"> variant to use.
        /// </summary>
        [Parameter]
        public DividerVariant Variant { set; get; } = DividerVariant.FullWidth;

        /// <summary>
        /// If <c>true</c>, the divider will have a lighter color.
        /// </summary>
        [Parameter]
        public bool Light { set; get; } = false;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Orientation" /> orientation of the divider.
        /// </summary>
        [Parameter]
        public Orientation Orientation { set; get; }

        protected string _Role
        {
            get => Role ?? (Component != "hr" ? "separator" : string.Empty);
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Absolute)
                    yield return nameof(Absolute);

                if (Variant != DividerVariant.FullWidth)
                    yield return $"{Variant}";

                if (Orientation == Orientation.Vertical)
                    yield return $"{Orientation}";

                if (Light)
                    yield return nameof(Light);
            }
        }
    }
}
