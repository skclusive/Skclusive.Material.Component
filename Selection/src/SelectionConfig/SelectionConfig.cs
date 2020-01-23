using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Form;

namespace Skclusive.Material.Selection
{
    public abstract class SelectionConfig : FormConfig
    {
        public SelectionConfig(string selector) : base(selector)
        {
        }

        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        [Parameter]
        public RenderFragment Icon { set; get; }

        [Parameter]
        public RenderFragment CheckedIcon { set; get; }

        [Parameter]
        public string Component { set; get; } = "span";

        [Parameter]
        public bool? Checked { set; get; }

        [Parameter]
        public Color Color { set; get; }

        [Parameter]
        public bool DisableRipple { set; get; }

        [Parameter]
        public bool AutoFocus { set; get; }

        [Parameter]
        public bool? DefaultChecked { set; get; }

        [Parameter]
        public string Name { set; get; }

        [Parameter]
        public bool ReadOnly { set; get; }

        [Parameter]
        public string Type { set; get; } = "text";

        [Parameter]
        public string Value { set; get; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { set; get; }

        [Parameter]
        public string InputStyle { set; get; }

        [Parameter]
        public string InputClass { set; get; }

        [Parameter]
        public string CheckedClass { set; get; }

        [Parameter]
        public string DisabledClass { set; get; }

        [Parameter]
        public Dictionary<string, object> InputProps { get; set; } = new Dictionary<string, object>();
    }
}
