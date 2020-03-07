using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.AppBar
{
    public class AppBarComponent : MaterialComponent
    {
        public AppBarComponent() : base("AppBar")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "header";

        /// <summary>
        /// The elevation of the AppBar.
        /// </summary>
        [Parameter]
        public int Elevation { set; get; } = 4;

        /// <summary>
        /// If <c>true</c>, rounded corners are disabled.
        /// </summary>
        [Parameter]
        public bool Square { set; get; } = true;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Primary;

        /// <summary>
        /// The <see cref="AppBarPosition" /> of the component.
        /// The behavior of the different options is described
        /// [in the MDN web docs](https://developer.mozilla.org/en-US/docs/Learn/CSS/CSS_layout/Positioning).
        /// Note: `sticky` is not universally supported and will fall back to `static` when unavailable.
        /// </summary>
        [Parameter]
        public AppBarPosition Position { set; get; } = AppBarPosition.Fixed;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Position)}-{Position}";

                if (Color != Color.Inherit)
                    yield return $"{nameof(Color)}-{Color}";
            }
        }
    }

    public enum AppBarPosition
    {
        Fixed,

        Absolute,

        Relative,

        Sticky,

        Static
    }
}
