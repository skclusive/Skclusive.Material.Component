using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Form
{
    public class FormConfig : MaterialComponent
    {
        public FormConfig(string selector) : base(selector)
        {
        }

        [Parameter]
        public bool? HiddenLabel { set; get; }

        [Parameter]
        public bool? Filled { get; set; }

        [Parameter]
        public bool? Focused { get; set; }

        [Parameter]
        public bool? Required { set; get; }

        [Parameter]
        public bool? Error { set; get; }

        [Parameter]
        public Margin? Margin { set; get; }

        [Parameter]
        public ControlVariant? Variant { set; get; }
    }

    public enum ControlVariant
    {
        Standard,

        Outlined,

        Filled
    }
}
