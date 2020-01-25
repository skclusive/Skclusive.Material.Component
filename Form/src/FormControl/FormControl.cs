using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skclusive.Material.Form
{
    public class FormControlComponent : FormConfig
    {
        public FormControlComponent() : base("FormControl")
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool FullWidth { set; get; } = false;

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            if ((Disabled.HasValue && Disabled.Value) && (Focused.HasValue && Focused.Value))
            {
                Focused = false;
            }
        }

        protected void OnFocusStateChange()
        {
            Focused = true;

            StateHasChanged();
        }

        protected void OnBlurStateChange()
        {
            Focused = false;

            StateHasChanged();
        }

        protected IFormControlContext FormContext => new FormControlContextBuilder()
            .WithDisabled(Disabled)
            .WithFilled(Filled)
            .WithFocused(Focused)
            .WithRequired(Required)
            .WithHiddenLabel(HiddenLabel)
            .WithMargin(Margin ?? Skclusive.Core.Component.Margin.None)
            .WithError(Error)
            .WithOnFocus(OnFocusStateChange)
            .WithOnBlur(OnBlurStateChange)
            .WithVariant(Variant ?? ControlVariant.Standard).Build();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if(Margin != Skclusive.Core.Component.Margin.None)
                    yield return $"{nameof(Margin)}-{Margin}";

                if (FullWidth)
                    yield return $"{nameof(FullWidth)}";
            }
        }
    }
}
