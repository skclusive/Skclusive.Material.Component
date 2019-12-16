using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Core
{
    public class MaterialContextComponent : MaterialComponentBase
    {
        [Parameter]
        public RenderFragment<IComponentContext> ChildContent { get; set; }

        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        public MaterialContextComponent(string selector = ""): base(selector)
        {
        }

        public bool HasContent => ChildContent != null;

        protected IComponentContext Context => new ComponentContextBuilder()
           .WithClass(Class)
           .WithStyle(Style)
           .WithRefBack(ChildRef)
           .WithDisabled(Disabled)
           .Build();
    }
}
