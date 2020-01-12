using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Form;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Text
{
    public class TextFieldComponent : MaterialComponentBase
    {
        [Inject]
        private DomHelpers DomHelpers { get; set; }

        protected Input.Input Input { set; get; }

        [Parameter]
        public string Type { set; get; }

        [Parameter]
        public bool FullWidth { set; get; }

        [Parameter]
        public bool Focused { set; get; }

        [Parameter]
        public bool? Required { set; get; }

        [Parameter]
        public bool? Error { set; get; }

        [Parameter]
        public bool? HiddenLabel { set; get; }

        [Parameter]
        public Margin? Margin { set; get; }

        [Parameter]
        public ControlVariant? Variant { set; get; }

        [Parameter]
        public bool? Dense { set; get; }

        public bool Shrink
        {
            get => Focused || Value?.Length > 0 || StartAdornment != null;
        }

        [Parameter]
        public bool ReadOnly { set; get; }

        [Parameter]
        public bool AutoComplete { set; get; }

        [Parameter]
        public bool AutoFocus { set; get; }

        [Parameter]
        public bool Multiline { set; get; }

        [Parameter]
        public string DefaultValue { set; get; }

        [Parameter]
        public string Helper { set; get; }

        [Parameter]
        public string Label { set; get; }

        [Parameter]
        public string PlaceHolder { set; get; }

        [Parameter]
        public string Value { set; get; }

        public string Name { set; get; }

        public string HelperId { get => string.IsNullOrWhiteSpace(Id) ? string.Empty : $"{Id}-Helper"; }

        [Parameter]
        public RenderFragment StartAdornment { set; get; }

        [Parameter]
        public RenderFragment EndAdornment { set; get; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { set; get; }

        protected override async Task OnAfterMountAsync()
        {
            if (AutoFocus)
            {
                // Input.Focus();

                var elementRef = Input?.Input?.Input?.RootRef.Current;

                await DomHelpers.FocusAsync(elementRef);
            }
        }

        protected override void HandleFocus(FocusEventArgs args)
        {
            Focused = true;

            StateHasChanged();

            base.HandleFocus(args);
        }

        protected override void HandleBlur(FocusEventArgs args)
        {
            Focused = false;

            StateHasChanged();

            base.HandleBlur(args);
        }

        protected virtual void HandleChange(ChangeEventArgs args)
        {
            Value = args.Value?.ToString();

            StateHasChanged();

            OnChange.InvokeAsync(args);
        }
    }
}
