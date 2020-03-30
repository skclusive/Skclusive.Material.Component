using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using Skclusive.Core.Component;
using System.Collections.Generic;

namespace Skclusive.Material.Container
{
    public class ContainerComponent : MaterialComponent
    {
        public ContainerComponent() : base("Container")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// Set the max-width to match the min-width of the current breakpoint.
        /// This is useful if you'd prefer to design for a fixed set of sizes
        /// instead of trying to accommodate a fully fluid viewport.
        /// It's fluid by default.
        /// </summary>
        [Parameter]
        public bool Fixed { set; get; } = false;

        /// <summary>
        /// Determine the max-width of the container.
        /// The container width grows with the size of the screen.
        /// Set to <c>MaxWidth.False</c> to disable <c>MaxWidth</c>.
        /// </summary>
        [Parameter]
        public MaxWidth MaxWidth { set; get; } = MaxWidth.Large;

        /// <summary>
        /// If <c>true</c>, the left and right padding is removed.
        /// </summary>
        [Parameter]
        public bool DisableGutters { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Fixed)
                    yield return nameof(Fixed);

                if (DisableGutters)
                    yield return nameof(DisableGutters);

                if (MaxWidth != MaxWidth.False)
                    yield return $"{nameof(MaxWidth)}-{MaxWidth}";
            }
        }
    }
}
