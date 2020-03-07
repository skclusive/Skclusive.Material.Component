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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "li";

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Default;

        /// <summary>
        /// If <c>true</c>, the List Subheader will not have gutters.
        /// </summary>
        [Parameter]
        public bool DisableGutters { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the List Subheader will not stick to the top during scroll.
        /// </summary>
        [Parameter]
        public bool DisableSticky { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the List Subheader will be indented.
        /// </summary>
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
