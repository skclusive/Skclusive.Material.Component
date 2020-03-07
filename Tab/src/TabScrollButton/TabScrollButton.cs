using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Tab
{
    public class TabScrollButtonComponent : MaterialComponent
    {
        public TabScrollButtonComponent() : base("TabScrollButton")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Orientation" /> of the component. The tabs orientation (layout flow direction).
        /// </summary>
        [Parameter]
        public Orientation Orientation { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Side" /> which direction/side should the button indicate?
        /// </summary>
        [Parameter]
        public Side Side { set; get; }

        /// <summary>
        /// Should the button be present or just consume space.
        /// </summary>
        [Parameter]
        public bool Visible { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Orientation == Orientation.Vertical)
                yield return $"{Orientation.Vertical}";
            }
        }
    }
}
