using Microsoft.AspNetCore.Components;

namespace Skclusive.Material.Core
{
    public class MaterialComponent : MaterialComponentBase
    {
        /// <summary>
        /// ChildContent of the current component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public MaterialComponent(string selector = ""): base(selector)
        {
        }

        public bool HasContent => ChildContent != null;
    }
}
