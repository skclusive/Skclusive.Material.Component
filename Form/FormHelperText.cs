using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Skclusive.Material.Form
{
    public class FormHelperTextComponent : FormConfigContext
    {
        public FormHelperTextComponent(): base("FormHelperText")
        {
        }

        [Parameter]
        public string Component { set; get; } = "p";

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Variant == ControlVariant.Filled || Variant == ControlVariant.Outlined)
                    yield return $"Contained";

                if (Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Margin)}-{Margin}";

                if (Error.HasValue && Error.Value)
                    yield return $"{nameof(Error)}";

                if (Filled.HasValue && Filled.Value)
                    yield return $"{nameof(Filled)}";

                if (Focused.HasValue && Focused.Value)
                    yield return $"{nameof(Focused)}";

                if (Required.HasValue && Required.Value)
                    yield return $"{nameof(Required)}";
            }
        }
    }
}
