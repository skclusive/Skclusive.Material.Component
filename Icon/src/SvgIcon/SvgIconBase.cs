using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Icon
{
    public class SvgIconBase : CssPureComponentBase
    {
        public SvgIconBase() : base("SvgIcon")
        {
        }

        [Parameter]
        public string HtmlColor { set; get; }

        [Parameter]
        public string Title { set; get; }

        [Parameter]
        public string ViewBox { set; get; } = "0 0 24 24";

        [Parameter]
        public Color Color { set; get; } = Color.Inherit;

        [Parameter]
        public FontSize FontSize { set; get; } = FontSize.Default;
    }
}
