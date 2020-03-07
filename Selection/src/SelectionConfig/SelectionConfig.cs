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

        /// <summary>
        /// Reference attached to the child element of the component.
        /// </summary>
        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        /// <summary>
        /// The icon to display when the component is unchecked.
        /// </summary>
        [Parameter]
        public RenderFragment Icon { set; get; }

        /// <summary>
        /// The icon to display when the component is checked.
        /// </summary>
        [Parameter]
        public RenderFragment CheckedIcon { set; get; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "span";

        /// <summary>
        /// If <c>true</c>, the component is checked.
        /// </summary>
        [Parameter]
        public bool? Checked { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; }

        /// <summary>
        /// If <c>true</c>, the ripple effect will be disabled.
        /// </summary>
        [Parameter]
        public bool DisableRipple { set; get; }

        /// <summary>
        /// If <c>true</c>, the <c>input</c> element will be focused during the first mount.
        /// </summary>
        [Parameter]
        public bool AutoFocus { set; get; }

        /// <summary>
        /// when input is checked default.
        /// </summary>
        [Parameter]
        public bool? DefaultChecked { set; get; }

        /// <summary>
        /// Name attribute of the <c>input</c> element.
        /// </summary>
        [Parameter]
        public string Name { set; get; }

        /// <summary>
        /// It prevents the user from changing the value of the field
        /// (not from interacting with the field).
        /// </summary>
        [Parameter]
        public bool ReadOnly { set; get; }

        /// <summary>
        /// The input component prop <c>type</c>.
        /// </summary>
        [Parameter]
        public string Type { set; get; } = "text";

        /// <summary>
        /// The value of the component.
        /// </summary>
        [Parameter]
        public string Value { set; get; }

        /// <summary>
        /// Callback fired when the state is changed.
        /// </summary>
        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Input</c> element.
        /// </summary>
        [Parameter]
        public string InputStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Input</c> element.
        /// </summary>
        [Parameter]
        public string InputClass { set; get; }

        /// <summary>
        /// <c>class</c> applied when the element is checked.
        /// </summary>
        [Parameter]
        public string CheckedClass { set; get; }

        /// <summary>
        /// <c>class</c> applied when the element is disabled.
        /// </summary>
        [Parameter]
        public string DisabledClass { set; get; }

        /// <summary>
        /// <c>attributes</c> passed to the Input component.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> InputProps { get; set; } = new Dictionary<string, object>();
    }
}
