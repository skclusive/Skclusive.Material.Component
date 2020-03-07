using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Skclusive.Material.Form;
using System.Linq;
using System;
using Skclusive.Core.Component;

namespace Skclusive.Material.Input
{
    public class OutlinedInputComponent : FormConfigContext
    {
        public OutlinedInputComponent() : base("OutlinedInput")
        {
        }

        public InputBase Input { set; get; }

        /// <summary>
        /// The width of the label.
        /// </summary>
        [Parameter]
        public double LabelWidth { set; get; }

        /// <summary>
        /// If <c>true</c>, the outline is notched to accommodate the label.
        /// </summary>
        [Parameter]
        public bool? Notched { set; get; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; }

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
        /// If <c>true</c>, the input will not have an underline.
        /// </summary>
        [Parameter]
        public bool DisableUnderline { set; get; }

        /// <summary>
        /// If <c>true</c>, the input will take up the full width of its container.
        /// </summary>
        [Parameter]
        public bool FullWidth { set; get; } = false;

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

        /// <summary>
        /// <c>style</c> applied on the <c>Notched</c> element.
        /// </summary>
        [Parameter]
        public string NotchedStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Notched</c> element.
        /// </summary>
        [Parameter]
        public string NotchedClass { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (!DisableUnderline)
                    yield return $"Underline";
            }
        }

         protected virtual string _NotchedStyle
        {
            get => CssUtil.ToStyle(NotchedStyles, NotchedStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> NotchedStyles
        {

            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _NotchedClass
        {
            get => CssUtil.ToClass($"{Selector}-NotchedOutline", NotchedClasses, NotchedClass);
        }

        protected virtual IEnumerable<string> NotchedClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        public void Focus()
        {
            Input.Focus();
        }
    }
}
