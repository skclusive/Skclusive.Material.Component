using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Divider
{
    public class DividerComponent : MaterialComponent
    {
        public DividerComponent() : base("Divider")
        {
        }

        [Parameter]
        public string Component { set; get; } = "hr";

        [Parameter]
        public bool Absolute { set; get; }

        [Parameter]
        public DividerVariant Variant { set; get; } = DividerVariant.FullWidth;

        [Parameter]
        public bool Light { set; get; } = false;

        [Parameter]
        public Orientation Orientation { set; get; }

        protected string _Role
        {
            get => Role ?? (Component != "hr" ? "separator" : string.Empty);
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Absolute)
                    yield return nameof(Absolute);

                if (Variant != DividerVariant.FullWidth)
                    yield return $"{Variant}";

                if (Orientation == Orientation.Vertical)
                    yield return $"{Orientation}";

                if (Light)
                    yield return nameof(Light);
            }
        }
    }

    public enum DividerVariant
    {
        FullWidth,

        Inset,

        Middle
    }
}
