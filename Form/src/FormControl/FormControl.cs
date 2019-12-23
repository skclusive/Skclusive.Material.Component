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
        public string Component { set; get; } = "div";

        [Parameter]
        public bool FullWidth { set; get; } = false;

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            if (!Margin.HasValue)
            {
                Margin = Skclusive.Core.Component.Margin.None;
            }

            if (!Variant.HasValue)
            {
                Variant = ControlVariant.Standard;
            }

            if ((Disabled.HasValue && Disabled.Value) && (Focused.HasValue && Focused.Value))
            {
                Focused = false;
            }

            FormContext = new FormControlContextBuilder().WithDisabled(Disabled)
            .WithFilled(Filled)
            .WithFocused(Focused)
            .WithRequired(Required)
            .WithHiddenLabel(HiddenLabel)
            .WithMargin(Margin)
            .WithError(Error)
            .WithOnFocus(OnFocusStateChange)
            .WithOnBlur(OnBlurStateChange)
            .WithVariant(Variant).Build();
        }

        protected void OnFocusChanged()
        {
            FormContext = new FormControlContextBuilder().With(FormContext)
            .WithFocused(Focused).Build();

            StateHasChanged();
        }

        protected void OnFocusStateChange()
        {
            Focused = true;

            OnFocusChanged();
        }

        protected void OnBlurStateChange()
        {
            Focused = false;

            OnFocusChanged();
        }

        protected IFormControlContext FormContext { get; private set; }

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
