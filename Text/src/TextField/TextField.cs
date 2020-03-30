using System;
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

        protected Input.FilledInput FilledInput { set; get; }

        protected Input.OutlinedInput OutlinedInput { set; get; }

        protected Input.StandardInput Input { set; get; }

        protected IReference LabelRef { get; set; } = new Reference();

        /// <summary>
        /// Type of the <c>input</c> element. It should be [a valid HTML5 input type](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#Form_%3Cinput%3E_types).
        /// </summary>
        [Parameter]
        public string Type { set; get; }

        /// <summary>
        /// If <c>true</c>, the input will take up the full width of its container.
        /// </summary>
        [Parameter]
        public bool FullWidth { set; get; }

        /// <summary>
        /// If <c>true</c>, the input of this label is focused (used by <c>FormGroup</c> components).
        /// </summary>
        [Parameter]
        public bool Focused { set; get; }

        /// <summary>
        /// If <c>true</c>, the label will indicate that the input is required.
        /// </summary>
        [Parameter]
        public bool? Required { set; get; }

        /// <summary>
        /// If <c>true</c>, the label should be displayed in an error state.
        /// </summary>
        [Parameter]
        public bool? Error { set; get; }

        /// <summary>
        /// If <c>true</c>, the label will be hidden.
        /// This is used to increase density for a <c>FilledInput</c>.
        /// Be sure to add <c>aria-label</c> to the `input` element.
        /// </summary>
        [Parameter]
        public bool? HiddenLabel { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Margin" /> margin to use.
        /// If <c>dense</c> or <c>normal</c>, will adjust vertical spacing of this and contained components.
        /// </summary>
        [Parameter]
        public Margin? Margin { set; get; }

        /// <summary>
        /// The <see cref="TextFieldVariant" /> variant to use.
        /// </summary>
        [Parameter]
        public TextFieldVariant? Variant { set; get; }

        /// <summary>
        /// If <c>true</c>, compact vertical padding designed for keyboard and mouse input will be used for
        /// the list and list items.
        /// The prop is available to descendant components as the <c>dense</c> context.
        /// </summary>
        [Parameter]
        public bool? Dense { set; get; }

        /// <summary>
        /// If <c>true</c>, the label is shrunk.
        /// </summary>
        [Parameter]
        public bool Shrink { set; get; }

        /// <summary>
        /// It prevents the user from changing the value of the field
        /// (not from interacting with the field).
        /// </summary>
        [Parameter]
        public bool ReadOnly { set; get; }

        /// <summary>
        /// This prop helps users to fill forms faster, especially on mobile devices.
        /// The name can be confusing, as it's more like an autofill.
        /// You can learn more about it [following the specification](https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofill).
        /// </summary>
        [Parameter]
        public string AutoComplete { set; get; }

        /// <summary>
        /// If <c>true</c>, the <c>input</c> element will be focused during the first mount.
        /// </summary>
        [Parameter]
        public bool AutoFocus { set; get; }

        /// <summary>
        /// If <c>true</c>, a textarea element will be rendered.
        /// </summary>
        [Parameter]
        public bool Multiline { set; get; }

        /// <summary>
        /// The default <c>input</c> element value. Use when the component is not controlled.
        /// </summary>
        [Parameter]
        public string DefaultValue { set; get; }

        /// <summary>
        /// The helper text content.
        /// </summary>
        [Parameter]
        public string Helper { set; get; }

        /// <summary>
        /// The label content.
        /// </summary>
        [Parameter]
        public string Label { set; get; }

        /// <summary>
        /// The short hint displayed in the input before the user enters a value.
        /// </summary>
        [Parameter]
        public string PlaceHolder { set; get; }

        /// <summary>
        /// The value of the <c>input</c> element, required for a controlled component.
        /// </summary>
        [Parameter]
        public string Value { set; get; }

        /// <summary>
        /// Name attribute of the <c>input</c> element.
        /// </summary>
        [Parameter]
        public string Name { set; get; }

        /// <summary>
        /// Start `InputAdornment` for this component.
        /// </summary>
        [Parameter]
        public RenderFragment StartAdornment { set; get; }

        /// <summary>
        /// End `InputAdornment` for this component.
        /// </summary>
        [Parameter]
        public RenderFragment EndAdornment { set; get; }

        /// <summary>
        /// Callback fired when the value is changed.
        /// </summary>
        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { set; get; }

        protected ControlVariant? _Variant => Variant != null ? (ControlVariant)Enum.Parse(typeof(ControlVariant), Variant.ToString()) : default(ControlVariant?);

        protected bool HasStartAdornment => StartAdornment != null;

        protected bool HasEndAdornment => EndAdornment != null;

        public string HelperId { get => string.IsNullOrWhiteSpace(Id) ? string.Empty : $"{Id}-Helper"; }

        protected double LabelWidth { set; get; }

        public bool _Shrink
        {
            get => Shrink || Focused || Value?.Length > 0 || StartAdornment != null || (Value == null && DefaultValue?.Length > 0);
        }

        protected override async Task OnAfterMountAsync()
        {
            if (Variant == TextFieldVariant.Outlined)
            {
                var offset = await DomHelpers.GetElementOffsetAsync(LabelRef.Current);

                LabelWidth = offset.Width;

                StateHasChanged();
            }

            if (AutoFocus)
            {
                // Input.Focus();

                var elementRef = Variant == TextFieldVariant.Filled ? FilledInput?.Input?.Input?.RootRef.Current : 
                (Variant == TextFieldVariant.Outlined ? OutlinedInput?.Input?.Input?.RootRef.Current
                : Input?.Input?.Input?.RootRef.Current);

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
