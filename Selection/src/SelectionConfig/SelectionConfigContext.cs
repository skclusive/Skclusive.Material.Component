using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Material.Form;

namespace Skclusive.Material.Selection
{
    public class SelectionConfigContext : SelectionConfig
    {
        public SelectionConfigContext(string selector) : base(selector)
        {
        }

        [CascadingParameter]
        public IFormControlContext SwitchContext { set; get; }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            if (!HiddenLabel.HasValue)
            {
                HiddenLabel = SwitchContext?.HiddenLabel ?? false;
            }

            if (!Filled.HasValue)
            {
                Filled = SwitchContext?.Filled ?? false;
            }

            if (!Focused.HasValue)
            {
                Focused = SwitchContext?.Focused ?? false;
            }

            if (!Required.HasValue)
            {
                Required = SwitchContext?.Required ?? false;
            }

            if (!Error.HasValue)
            {
                Error = SwitchContext?.Error ?? false;
            }

            if (!Margin.HasValue)
            {
                Margin = SwitchContext?.Margin ?? Skclusive.Core.Component.Margin.None;
            }

            if (!Variant.HasValue)
            {
                Variant = SwitchContext?.Variant ?? ControlVariant.Standard;
            }
        }

        protected override void HandleFocus(FocusEventArgs args)
        {
            base.HandleFocus(args);

            SwitchContext?.OnFocus();
        }

        protected override void HandleBlur(FocusEventArgs args)
        {
            base.HandleBlur(args);

            SwitchContext?.OnBlur();
        }
    }
}
