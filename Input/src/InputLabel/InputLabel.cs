using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Skclusive.Material.Form;

namespace Skclusive.Material.Input
{
    public class InputLabelComponent : FormConfigContext
    {
        public InputLabelComponent() : base("InputLabel")
        {
        }

        [Parameter]
        public string Component { set; get; } = "label";

        [Parameter]
        public bool DisableAnimation { set; get; } = false;

        [Parameter]
        public bool Shrink { set; get; }

        [Parameter]
        public string For { set; get; }

        protected string DataShrink => Shrink.ToString().ToLower();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (FormContext != null)
                    yield return "FormControl";

                if (!DisableAnimation)
                    yield return "Animated";

                if (Shrink)
                    yield return nameof(Shrink);

                if(Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Margin)}-{Margin}";

                if (Variant == ControlVariant.Filled || Variant == ControlVariant.Outlined)
                    yield return $"{Variant}";
            }
        }
    }
}
