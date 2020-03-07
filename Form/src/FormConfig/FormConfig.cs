using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Form
{
    public class FormConfig : MaterialComponentBase
    {
        public FormConfig(string selector) : base(selector)
        {
        }

        /// <summary>
        /// If <c>true</c>, the label will be hidden.
        /// This is used to increase density for a <c>FilledInput</c>.
        /// Be sure to add <c>aria-label</c> to the `input` element.
        /// </summary>
        [Parameter]
        public bool? HiddenLabel { set; get; }

        /// <summary>
        /// If <c>true</c>, the label should use filled classes key.
        /// </summary>
        [Parameter]
        public bool? Filled { get; set; }

        /// <summary>
        /// If <c>true</c>, the input of this label is focused (used by <c>FormGroup</c> components).
        /// </summary>
        [Parameter]
        public bool? Focused { get; set; }

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
        /// The <see cref="Skclusive.Core.Component.Margin" /> margin to use.
        /// If <c>dense</c> or <c>normal</c>, will adjust vertical spacing of this and contained components.
        /// </summary>
        [Parameter]
        public Margin? Margin { set; get; }

        /// <summary>
        /// The <see cref="ControlVariant" /> variant to use.
        /// </summary>
        [Parameter]
        public ControlVariant? Variant { set; get; }
    }
}
