using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Skclusive.Material.Form;
using Skclusive.Core.Component;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Input
{
    public class InputBaseComponent : FormConfigContext
    {
        public InputBaseComponent() : base("InputBase")
        {
        }

        public Skclusive.Core.Component.Component Input { set; get; }

        [Inject]
        public DomHelpers DomHelpers { set; get; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, the outline is notched to accommodate the label.
        /// </summary>
        [Parameter]
        public bool? Notched { set; get; }

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
        /// The default <c>input</c> element value. Use when the component is not controlled.
        /// </summary>
        [Parameter]
        public string DefaultValue { set; get; }

        /// <summary>
        /// If <c>true</c>, the input will take up the full width of its container.
        /// </summary>
        [Parameter]
        public bool FullWidth { set; get; }

        /// <summary>
        /// html component tag to be used as input.
        /// </summary>
        [Parameter]
        public string InputComponent { set; get; }

        /// <summary>
        /// If <c>true</c>, a textarea element will be rendered.
        /// </summary>
        [Parameter]
        public bool Multiline { set; get; } = false;

        /// <summary>
        /// Name attribute of the <c>input</c> element.
        /// </summary>
        [Parameter]
        public string Name { set; get; }

        /// <summary>
        /// The short hint displayed in the input before the user enters a value.
        /// </summary>
        [Parameter]
        public string PlaceHolder { set; get; }

        /// <summary>
        /// It prevents the user from changing the value of the field
        /// (not from interacting with the field).
        /// </summary>
        [Parameter]
        public bool ReadOnly { set; get; }

        /// <summary>
        /// renders suffix component
        /// </summary>
        [Parameter]
        public RenderFragment<bool> RenderSuffix { set; get; }

        /// <summary>
        /// Number of rows to display when multiline option is set to true.
        /// </summary>
        [Parameter]
        public int Rows { set; get; }

        /// <summary>
        /// Maximum number of rows to display when multiline option is set to true.
        /// </summary>
        [Parameter]
        public int RowsMax { set; get; }

        /// <summary>
        /// Should be <c>true</c> when the component hosts a select.
        /// </summary>
        [Parameter]
        public bool Select { set; get; } = false;

        /// <summary>
        /// whether has start `InputAdornment` for this component.
        /// </summary>
        [Parameter]
        public bool HasStartAdornment { set; get; }

        /// <summary>
        /// whether has end `InputAdornment` for this component.
        /// </summary>
        [Parameter]
        public bool HasEndAdornment { set; get; }

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
        /// Type of the <c>input</c> element. It should be [a valid HTML5 input type](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#Form_%3Cinput%3E_types).
        /// </summary>
        [Parameter]
        public string Type { set; get; } = "text";

        /// <summary>
        /// The value of the <c>input</c> element, required for a controlled component.
        /// </summary>
        [Parameter]
        public string Value { set; get; }

        /// <summary>
        /// Callback fired when the value is changed.
        /// </summary>
        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Input</c> element.
        /// </summary>
        [Parameter]
        public string InputClass { set; get; }

        protected string _Input => InputComponent ?? (Multiline ? "textarea" : "input");

        protected bool IsControlled => Value != null;

        protected string ValueState { set; get; }

        protected string _Value => IsControlled ? Value : ValueState;

        protected bool _Notched => Notched ?? (HasStartAdornment || _Filled.HasValue && _Filled.Value  ||  _Focused.HasValue && _Focused.Value);

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (FormContext != null)
                    yield return "FormControl";

                if (_Error.HasValue && _Error.Value)
                    yield return $"{nameof(Error)}";

                if (_Filled.HasValue && _Filled.Value)
                    yield return $"{nameof(Filled)}";

                if (_Focused.HasValue && _Focused.Value)
                    yield return $"{nameof(Focused)}";

                if (_Required.HasValue && _Required.Value)
                    yield return $"{nameof(Required)}";

                if (FullWidth)
                    yield return $"{nameof(FullWidth)}";

                if (_Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Skclusive.Core.Component.Margin)}-{Skclusive.Core.Component.Margin.Dense}";

                if (Multiline)
                    yield return $"{nameof(Multiline)}";

                if (HasStartAdornment)
                    yield return $"{nameof(StartAdornment)}";

                if (HasEndAdornment)
                    yield return $"{nameof(EndAdornment)}";
            }
        }

        protected string _InputClass
        {
            get
            {
                return CssUtil.ToClass($"{Selector}-Input", string.IsNullOrWhiteSpace(Overridable) ? "" : $"{Overridable}-Input", InputClasses, InputClass);
            }
        }

        protected virtual IEnumerable<string> InputClasses
        {
            get
            {
                yield return string.Empty;

                if (Disabled.HasValue && Disabled.Value)
                    yield return $"{nameof(Disabled)}";

                if (Select)
                    yield return $"{nameof(Select)}";

                if (_HiddenLabel.HasValue && _HiddenLabel.Value)
                    yield return $"{nameof(HiddenLabel)}";

                if (_Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Skclusive.Core.Component.Margin)}-{Skclusive.Core.Component.Margin.Dense}";

                if (Multiline)
                    yield return $"{nameof(Multiline)}";

                if (HasStartAdornment)
                    yield return $"{nameof(StartAdornment)}";

                if (HasEndAdornment)
                    yield return $"{nameof(EndAdornment)}";
            }
        }

        protected override void OnInitialized()
        {
            ValueState = DefaultValue;
        }

        protected void DirtyCheck(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                FormContext?.OnEmpty();
            } else
            {
                FormContext?.OnFill();
            }
        }

        protected async Task HandleChangeAsync(ChangeEventArgs args)
        {
            if (!IsControlled)
            {
                ValueState = args.Value?.ToString();

                DirtyCheck(ValueState);

                await InvokeAsync(StateHasChanged);
            }

            await OnChange.InvokeAsync(args);
        }

        protected async Task HandleInputAsync(ChangeEventArgs args)
        {
            await OnChange.InvokeAsync(args);

            await Task.CompletedTask;
        }

        private string LastValue { set; get; }

        protected override void OnParametersSet()
        {
            if (IsControlled && !object.Equals(LastValue, Value))
            {
                DirtyCheck(Value);
            }
            LastValue = Value;
        }

        public void Focus()
        {
            Input.Focus();
        }

        protected override async Task OnAfterMountAsync()
        {
            var value = await DomHelpers.GetInputValueAsync(Input.RootRef.Current);

            value = string.IsNullOrEmpty(value) ? null : value;

            if (IsControlled)
            {
                if (!object.Equals(Value, value))
                {
                    await OnChange.InvokeAsync(new ChangeEventArgs
                    {
                        Value = value
                    });
                }
            }
            else
            {
                ValueState = value;
            }

            DirtyCheck(value);

            await InvokeAsync(StateHasChanged);
        }
    }
}
