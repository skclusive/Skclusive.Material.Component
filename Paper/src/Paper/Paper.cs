using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Paper
{
    public class PaperComponent : MaterialComponent
    {
        public PaperComponent() : base("Paper")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public int Elevation { set; get; } = 1;

        [Parameter]
        public bool Square { set; get; } = false;

        protected bool Rounded { get => !Square; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Elevation)}{Elevation}";

                if (Rounded)
                    yield return nameof(Rounded);
            }
        }
    }
}
