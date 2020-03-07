using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Icon
{
    public class SvgIconBase : CssPureComponentBase
    {
        public SvgIconBase() : base("SvgIcon")
        {
        }

        /// <summary>
        /// Applies a color attribute to the SVG element.
        /// </summary>
        [Parameter]
        public string HtmlColor { set; get; }

        /// <summary>
        /// Provides a human-readable title for the element that contains it.
        /// https://www.w3.org/TR/SVG-access/#Equivalent
        /// </summary>
        [Parameter]
        public string Title { set; get; }

        /// <summary>
        /// Allows you to redefine what the coordinates without units mean inside an SVG element.
        /// For example, if the SVG element is 500 (width) by 200 (height),
        /// and you pass viewBox="0 0 50 20",
        /// this means that the coordinates inside the SVG will go from the top left corner (0,0)
        /// to bottom right (50,20) and each unit will be worth 10px.
        /// </summary>
        [Parameter]
        public string ViewBox { set; get; } = "0 0 24 24";

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// You can use the <c>HtmlColor</c> prop to apply a color attribute to the SVG element.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Inherit;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.FontSize" /> of the component which is applied to the icon. Defaults to 24px, but can be configure to inherit font size.
        /// </summary>
        [Parameter]
        public FontSize FontSize { set; get; } = FontSize.Default;
    }
}
