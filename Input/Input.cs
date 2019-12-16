using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Skclusive.Material.Form;

namespace Skclusive.Material.Input
{
    public class InputComponent : FormConfigContext
    {
        public InputComponent() : base("Input")
        {
        }

        public InputBase Input { set; get; }

        [Parameter]
        public string Component { set; get; } = "input";

        [Parameter]
        public bool AutoComplete { set; get; }

        [Parameter]
        public bool AutoFocus { set; get; }

        [Parameter]
        public string DefaultValue { set; get; }

        [Parameter]
        public bool DisableUnderline { set; get; }

        [Parameter]
        public RenderFragment EndAdornment { set; get; }

        [Parameter]
        public bool FullWidth { set; get; } = false;

        [Parameter]
        public bool Multiline { set; get; } = false;

        [Parameter]
        public string Name { set; get; }

        [Parameter]
        public string PlaceHolder { set; get; }

        [Parameter]
        public bool ReadOnly { set; get; }

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

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (FormContext != null)
                    yield return "FormControl";

                if (!DisableUnderline)
                    yield return $"Underline";
            }
        }

        public void Focus()
        {
            Input.Focus();
        }
    }
}
