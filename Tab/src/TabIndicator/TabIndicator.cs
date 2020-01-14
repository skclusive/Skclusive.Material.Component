using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Material.Tab
{
    public class TabIndicatorComponent : MaterialComponent
    {
        public TabIndicatorComponent() : base("TabIndicator")
        {
        }

        [Parameter]
        public string Component { set; get; } = "span";

        [Parameter]
        public Orientation Orientation { set; get; }

        [Parameter]
        public Color Color { set; get; }

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
