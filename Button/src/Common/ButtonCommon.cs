using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using Skclusive.Core.Component;

namespace Skclusive.Material.Button
{
    public abstract class ButtonCommonComponent : MaterialComponentBase
    {
        protected ButtonCommonComponent(string selector) : base(selector)
        {
        }

        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        [Parameter]
        public RenderFragment<IComponentContext> ChildContent { get; set; }

        [Parameter]
        public string Component { set; get; }

        [Parameter]
        public bool DisableRipple { set; get; }

        [Parameter]
        public bool DisableTouchRipple { set; get; }

        [Parameter]
        public bool DisableFocusRipple { set; get; }

        [Parameter]
        public string FocusVisibleClass { set; get; }

        [Parameter]
        public string LabelClass { set; get; }

        [Parameter]
        public bool Mini { set; get; }

        [Parameter]
        public string Href { set; get; }

        [Parameter]
        public Color Color { set; get; } = Color.Default;
    }
}
