using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Icon
{
    public class SvgIconComponent : SvgIconBase
    {

        /// <summary>
        /// Node passed into the SVG element.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected bool Hidden => string.IsNullOrWhiteSpace(Title);

        protected string _Role => Role ?? (!Hidden ? "img" : "presentation");

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Color != Color.Inherit)
                yield return $"{nameof(Color)}-{Color}";

                if (FontSize != FontSize.Default)
                yield return $"{nameof(FontSize)}-{FontSize}";
            }
        }
    }
}
