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

        /// <summary>
        /// ChildContent of the current component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "label";

        /// <summary>
        /// If <c>true</c>, the transition animation is disabled.
        /// </summary>
        [Parameter]
        public bool DisableAnimation { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the label is shrunk.
        /// </summary>
        [Parameter]
        public bool? Shrink { set; get; }

        /// <summary>
        /// html for attribute for the label.
        /// </summary>
        [Parameter]
        public string For { set; get; }

        protected bool _Shrink => Shrink.HasValue ? Shrink.Value : ((_Filled.HasValue && _Filled.Value) || (_Focused.HasValue && _Focused.Value) || (_HasStartAdornment.HasValue && _HasStartAdornment.Value));

        protected string DataShrink => _Shrink.ToString().ToLower();

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

                if (_Shrink)
                    yield return nameof(Shrink);

                if(_Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Margin)}-{_Margin}";

                if (_Variant == ControlVariant.Filled || _Variant == ControlVariant.Outlined)
                    yield return $"{_Variant}";
            }
        }
    }
}
