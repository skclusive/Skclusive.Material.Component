using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Icon
{
    public class SvgIconComponent : CssPureComponentBase
    {
        public SvgIconComponent() : base("SvgIcon")
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string NativeColor { set; get; }

        [Parameter]
        public string Title { set; get; }

        [Parameter]
        public string ViewBox { set; get; } = "0 0 24 24";

        [Parameter]
        public Color Color { set; get; } = Color.Inherit;

        protected bool Hidden => string.IsNullOrWhiteSpace(Title);
    }
}
