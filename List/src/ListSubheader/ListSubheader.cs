using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.List
{
    public class ListSubheaderComponent : MaterialComponent
    {
        public ListSubheaderComponent() : base("ListSubheader")
        {
        }

        [Parameter]
        public string Component { set; get; } = "li";

        [Parameter]
        public Color Color { set; get; } = Color.Default;

        [Parameter]
        public bool DisableGutters { set; get; } = false;

        [Parameter]
        public bool DisableSticky { set; get; } = false;

        [Parameter]
        public bool Inset { set; get; } = false;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Color != Color.Default)
                    yield return $"{nameof(Color)}-{Color}";    

                if (!DisableSticky)
                    yield return "Sticky";

                if (!DisableGutters)
                    yield return "Gutters";

                if (Inset)
                    yield return nameof(Inset);
            }
        }
    }
}
