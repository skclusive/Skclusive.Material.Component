using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;

namespace Skclusive.Material.Form
{
    public class FormConfigContext : FormConfig
    {
        public FormConfigContext(string selector) : base(selector)
        {
        }

        [CascadingParameter]
        public IFormControlContext FormContext { set; get; }

        protected bool? _HiddenLabel => HiddenLabel ?? FormContext?.HiddenLabel;

        protected bool? _Filled  => Filled ?? FormContext?.Filled;

        protected bool? _HasStartAdornment => FormContext?.HasStartAdornment;

        protected bool? _Focused => Focused ?? FormContext?.Focused;

        protected bool? _Required => Required ?? FormContext?.Required;

        protected bool? _Error => Error ?? FormContext?.Error;

        protected Margin? _Margin => Margin ?? FormContext?.Margin;

        protected ControlVariant? _Variant => Variant ?? FormContext?.Variant;

        protected bool? _Disabled => Disabled ?? FormContext?.Disabled;

        protected override IEnumerable<string> Classes
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Selector))
                {
                    yield return "Root";

                    if (_Disabled.HasValue && _Disabled.Value)
                        yield return nameof(Disabled);
                }
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
