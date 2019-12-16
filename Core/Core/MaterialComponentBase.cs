using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Core
{
    public class MaterialComponentBase : EventComponentBase
    {
        [Parameter]
        public IReference RootRef { get; set; } = new Reference();

        public MaterialComponentBase(string selector = "") : base(selector)
        {
        }
    }
}
