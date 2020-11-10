using Microsoft.AspNetCore.Components;

namespace Skclusive.Material.Core
{
    public class MaterialLayoutComponent : MaterialComponentBase
    {
        /// <summary>
        /// Body of the current component.
        /// </summary>
        [Parameter]
        public RenderFragment Body { get; set; }

        public MaterialLayoutComponent(string selector = ""): base(selector)
        {
        }

        public bool HasBody => Body != null;
    }
}