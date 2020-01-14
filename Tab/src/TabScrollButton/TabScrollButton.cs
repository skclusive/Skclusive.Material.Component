using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Material.Tab
{
    public class TabScrollButtonComponent : MaterialComponent
    {
        public TabScrollButtonComponent() : base("TabScrollButton")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public Orientation Orientation { set; get; }

        [Parameter]
        public Side Side { set; get; }

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
