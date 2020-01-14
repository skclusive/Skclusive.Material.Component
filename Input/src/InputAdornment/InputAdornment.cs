using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using Skclusive.Material.Form;
using System.Collections.Generic;

namespace Skclusive.Material.Input
{
    public class InputAdornmentComponent : MaterialContextComponent
    {
        public InputAdornmentComponent() : base("InputAdornment")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public InputPosition Position { set; get; } = InputPosition.Start;

        [Parameter]
        public bool DisablePointerEvents { set; get; }

        [Parameter]
        public bool DisableTypography { set; get; }

        [Parameter]
        public string Adornment { set; get; }

        [Parameter]
        public ControlVariant? Variant { set; get; }

        [CascadingParameter]
        public IFormControlContext FormContext { set; get; }

        protected bool RenderTypography => !string.IsNullOrWhiteSpace(Adornment) && !DisableTypography;

        protected IFormControlContext NullContext => null;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Position)}-{Position}";

                if (Variant == ControlVariant.Filled)
                    yield return $"{nameof(Variant)}";

                if (DisablePointerEvents)
                    yield return $"{nameof(DisablePointerEvents)}";

                if (DisablePointerEvents)
                    yield return $"{nameof(DisablePointerEvents)}";

                if (FormContext?.Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Skclusive.Core.Component.Margin)}-{Skclusive.Core.Component.Margin.Dense}";

                if (FormContext != null && FormContext.HiddenLabel.HasValue && FormContext.HiddenLabel.Value)
                    yield return $"{nameof(FormContext.HiddenLabel)}";
            }
        }
    }

    public enum InputPosition
    {
        Start,

        End
    }
}
