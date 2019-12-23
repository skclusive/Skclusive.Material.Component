using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Skclusive.Material.Form
{
    public class FormConfigContext : FormConfig
    {
        public FormConfigContext(string selector) : base(selector)
        {
        }

        [CascadingParameter]
        public IFormControlContext FormContext { set; get; }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            if (!HiddenLabel.HasValue)
            {
                HiddenLabel = FormContext?.HiddenLabel ?? false;
            }

            if (!Filled.HasValue)
            {
                Filled = FormContext?.Filled ?? false;
            }

            if (!Focused.HasValue)
            {
                Focused = FormContext?.Focused ?? false;
            }

            if (!Required.HasValue)
            {
                Required = FormContext?.Required ?? false;
            }

            if (!Error.HasValue)
            {
                Error = FormContext?.Error ?? false;
            }

            if (!Margin.HasValue)
            {
                Margin = FormContext?.Margin ?? Skclusive.Core.Component.Margin.None;
            }

            if (!Variant.HasValue)
            {
                Variant = FormContext?.Variant ?? ControlVariant.Standard;
            }
        }

        protected override void HandleFocus(FocusEventArgs args)
        {
            base.HandleFocus(args);

            FormContext?.OnFocus();
        }

        protected override void HandleBlur(FocusEventArgs args)
        {
            base.HandleBlur(args);

            FormContext?.OnBlur();
        }
    }
}
