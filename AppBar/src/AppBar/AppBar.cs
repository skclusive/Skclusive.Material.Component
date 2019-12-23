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

        [Parameter]
        public string Component { set; get; } = "header";

        [Parameter]
        public int Elevation { set; get; } = 4;

        [Parameter]
        public bool Square { set; get; } = true;

        [Parameter]
        public Color Color { set; get; } = Color.Primary;

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
