using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.List
{
    public class ListItemSecondaryActionComponent : MaterialComponent
    {
        public ListItemSecondaryActionComponent() : base("ListItemSecondaryAction")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";
    }
}
