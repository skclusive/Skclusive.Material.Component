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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// The <see cref="InputPosition" /> that position this adornment should appear relative to the <c>Input</c>.
        /// </summary>
        [Parameter]
        public InputPosition Position { set; get; } = InputPosition.Start;

        /// <summary>
        /// Disable pointer events on the root.
        /// <remarks>
        /// This allows for the content of the adornment to focus the input on click.
        /// </remarks>
        /// </summary>
        [Parameter]
        public bool DisablePointerEvents { set; get; }

        /// <summary>
        /// If children is a string then disable wrapping in a Typography component.
        /// </summary>
        [Parameter]
        public bool DisableTypography { set; get; }

        /// <summary>
        /// The content of the component.
        /// </summary>
        [Parameter]
        public string Adornment { set; get; }

        /// <summary>
        /// The <see cref="ControlVariant" /> the variant to use.
        /// </summary>
        [Parameter]
        public ControlVariant? Variant { set; get; }

        [CascadingParameter]
        public IFormControlContext FormContext { set; get; }

        protected bool RenderTypography => !string.IsNullOrWhiteSpace(Adornment) && !DisableTypography;

        protected IFormControlContext NullContext => null;

        protected ControlVariant? _Variant => Variant ?? FormContext?.Variant;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Position)}-{Position}";

                if (_Variant == ControlVariant.Filled)
                    yield return $"{_Variant}";

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
