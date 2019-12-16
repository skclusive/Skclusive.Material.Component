using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Skclusive.Material.Form;
using Skclusive.Material.Core;
using Skclusive.Core.Component;

namespace Skclusive.Material.Input
{
    public class InputBaseComponent : FormConfigContext
    {
        public InputBaseComponent() : base("InputBase")
        {
        }

        public Skclusive.Core.Component.Component Input { set; get; }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool AutoComplete { set; get; }

        [Parameter]
        public bool AutoFocus { set; get; }

        [Parameter]
        public string DefaultValue { set; get; }

        [Parameter]
        public RenderFragment EndAdornment { set; get; }

        [Parameter]
        public bool FullWidth { set; get; }

        [Parameter]
        public string InputComponent { set; get; } = "input";

        [Parameter]
        public bool Multiline { set; get; } = false;

        [Parameter]
        public string Name { set; get; }

        [Parameter]
        public string PlaceHolder { set; get; }

        [Parameter]
        public bool ReadOnly { set; get; }

        [Parameter]
        public RenderFragment RenderSuffix { set; get; }

        [Parameter]
        public int Rows { set; get; }

        [Parameter]
        public int RowsMax { set; get; }

        [Parameter]
        public bool Select { set; get; } = false;

        [Parameter]
        public RenderFragment StartAdornment { set; get; }

        [Parameter]
        public string Type { set; get; } = "text";

        [Parameter]
        public string Value { set; get; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { set; get; }

        [Parameter]
        public string InputClass { set; get; }

        protected bool IsControlled => Value != null;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (FormContext != null)
                    yield return "FormControl";

                if (Error.HasValue && Error.Value)
                    yield return $"{nameof(Error)}";

                if (Filled.HasValue && Filled.Value)
                    yield return $"{nameof(Filled)}";

                if (Focused.HasValue && Focused.Value)
                    yield return $"{nameof(Focused)}";

                if (Required.HasValue && Required.Value)
                    yield return $"{nameof(Required)}";

                if (FullWidth)
                    yield return $"{nameof(FullWidth)}";

                if (Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Skclusive.Core.Component.Margin)}-{Skclusive.Core.Component.Margin.Dense}";

                if (Multiline)
                    yield return $"{nameof(Multiline)}";

                if (StartAdornment != default)
                    yield return $"{nameof(StartAdornment)}";

                if (EndAdornment != default)
                    yield return $"{nameof(EndAdornment)}";
            }
        }

        protected string _InputClass
        {
            get
            {
                return CssUtil.ToClass($"{Selector}-Input", InputClasses, InputClass);
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

                if (HiddenLabel.HasValue && HiddenLabel.Value)
                    yield return $"{nameof(HiddenLabel)}";

                if (Margin == Skclusive.Core.Component.Margin.Dense)
                    yield return $"{nameof(Skclusive.Core.Component.Margin)}-{Skclusive.Core.Component.Margin.Dense}";

                if (Multiline)
                    yield return $"{nameof(Multiline)}";

                if (StartAdornment != default)
                    yield return $"{nameof(StartAdornment)}";

                if (EndAdornment != default)
                    yield return $"{nameof(EndAdornment)}";
            }
        }

        protected void HandleChange(ChangeEventArgs args)
        {
            OnChange.InvokeAsync(args);
        }

        protected async Task HandleChangeAsync(ChangeEventArgs args)
        {
            HandleChange(args);

            await Task.CompletedTask;
        }

        protected async Task HandleInputAsync(ChangeEventArgs args)
        {
            await OnChange.InvokeAsync(args);

            await Task.CompletedTask;
        }

        public void Focus()
        {
            Input.Focus();
        }

        protected override void OnAfterMount()
        {
            base.OnAfterMount();

            // Input.EventPolyfill();
        }
    }
}
