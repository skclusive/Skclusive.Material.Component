using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.List
{
    public class ListItemSecondaryActionComponent : MaterialComponent
    {
        public ListItemSecondaryActionComponent() : base("ListItemSecondaryAction")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";
    }
}
