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

        /// <summary>
        /// ChildContent of the current component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, the component will take up the full width of its container.
        /// </summary>
        [Parameter]
        public bool FullWidth { set; get; } = false;

        /// <summary>
        /// If start <c>InputAdornment</c> is passed for the component.
        /// </summary>
        [Parameter]
        public bool? HasStartAdornment { set; get; }

        protected Skclusive.Core.Component.Margin _Margin => Margin ?? Skclusive.Core.Component.Margin.None;

        protected ControlVariant _Variant => Variant ?? ControlVariant.Standard;

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

        protected void OnFillStateChange()
        {
            Filled = true;

            StateHasChanged();
        }

        protected void OnEmptyStateChange()
        {
            Filled = false;

            StateHasChanged();
        }

        protected IFormControlContext FormContext => new FormControlContextBuilder()
            .WithDisabled(Disabled)
            .WithFilled(Filled)
            .WithFocused(Focused)
            .WithRequired(Required)
            .WithHiddenLabel(HiddenLabel)
            .WithMargin(_Margin)
            .WithError(Error)
            .WithOnFocus(OnFocusStateChange)
            .WithOnBlur(OnBlurStateChange)
            .WithOnFill(OnFillStateChange)
            .WithOnEmpty(OnEmptyStateChange)
            .WithHasStartAdornment(HasStartAdornment)
            .WithVariant(_Variant).Build();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if(_Margin != Skclusive.Core.Component.Margin.None)
                    yield return $"{nameof(Margin)}-{_Margin}";

                if (FullWidth)
                    yield return $"{nameof(FullWidth)}";
            }
        }
    }
}
