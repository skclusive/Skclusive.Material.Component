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

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool Gutters { set; get; } = true;

        [Parameter]
        public ToolbarVariant Variant { set; get; } = ToolbarVariant.Regular;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{Variant}";

                if (Gutters)
                    yield return nameof(Gutters);
            }
        }
    }

    public enum ToolbarVariant
    {
        Regular,

        Dense
    }
}
