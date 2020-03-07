using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Core
{
    public class MaterialContextComponent : MaterialComponentBase
    {
        /// <summary>
        /// ChildContent of the current component which gets component <see cref="IComponentContext" />.
        /// </summary>
        [Parameter]
        public RenderFragment<IComponentContext> ChildContent { get; set; }

        /// <summary>
        /// Reference attached to the child element of the component.
        /// </summary>
        [Parameter]
        public IReference ChildRef { get; set; } = new Reference("ChildContextRef");

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
