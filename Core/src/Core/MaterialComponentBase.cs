using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Core
{
    public class MaterialComponentBase : EventComponentBase
    {
        /// <summary>
        /// Reference attached to the root element of the component.
        /// </summary>
        [Parameter]
        public IReference RootRef { get; set; } = new Reference();

        public MaterialComponentBase(string selector = "") : base(selector)
        {
        }

        protected virtual string ToClass(string current)
        {
            return CssUtil.ToClass(Selector, new string [] { current });
        }
    }
}
