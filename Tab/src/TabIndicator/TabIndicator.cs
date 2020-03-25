using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Tab
{
    public class TabIndicatorComponent : MaterialComponent
    {
        public TabIndicatorComponent() : base("TabIndicator")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "span";

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Orientation" /> of the component. the tabs orientation (layout flow direction).
        /// </summary>
        [Parameter]
        public Orientation Orientation { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Inherit;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Color)}-{Color}";

                if (Orientation == Orientation.Vertical)
                yield return $"{Orientation.Vertical}";
            }
        }
    }
}
