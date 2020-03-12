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

        protected bool Rounded => !Square;

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
