using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Toolbar
{
    public class ToolbarComponent : MaterialComponent
    {
        public ToolbarComponent() : base("Toolbar")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, disables gutter padding.
        /// </summary>
        [Parameter]
        public bool DisableGutters { set; get; }

        /// <summary>
        /// The <see cref="ToolbarVariant"> variant to use.
        /// </summary>
        [Parameter]
        public ToolbarVariant Variant { set; get; } = ToolbarVariant.Regular;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{Variant}";

                if (!DisableGutters)
                    yield return "Gutters";
            }
        }
    }
}
