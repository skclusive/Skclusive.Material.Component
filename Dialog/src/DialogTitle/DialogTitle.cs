using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.Dialog
{
    public class DialogTitleComponent : MaterialComponent
    {
        public DialogTitleComponent() : base("DialogTitle")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, the children won't be wrapped by a typography component.
        /// For instance, this can be useful to render an h4 instead of the default h2.
        /// </summary>
        [Parameter]
        public bool DisableTypography { set; get; }
    }
}
