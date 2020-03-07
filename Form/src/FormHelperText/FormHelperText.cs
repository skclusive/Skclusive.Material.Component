using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Skclusive.Material.Form
{
    public class FormHelperTextComponent : FormConfigContext
    {
        public FormHelperTextComponent(): base("FormHelperText")
        {
        }

        /// <summary>
        /// ChildContent of the current component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "p";

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (_Variant == ControlVariant.Filled || _Variant == ControlVariant.Outlined)
                    yield return $"Contained";

                if (_Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Margin)}-{Margin}";

                if (_Error.HasValue && _Error.Value)
                    yield return $"{nameof(Error)}";

                if (_Filled.HasValue && _Filled.Value)
                    yield return $"{nameof(Filled)}";

                if (_Focused.HasValue && _Focused.Value)
                    yield return $"{nameof(Focused)}";

                if (_Required.HasValue && _Required.Value)
                    yield return $"{nameof(Required)}";
            }
        }
    }
}
