using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using System.Collections.Generic;

namespace Skclusive.Material.Form
{
    public class FormControlLabelComponent : FormConfigContext
    {
        public FormControlLabelComponent() : base("FormControlLabel")
        {
        }

        /// <summary>
        /// ChildContent of the current component which gets component <see cref="IFormControlContext" />.
        /// </summary>
        [Parameter]
        public RenderFragment<IFormControlContext> ChildContent { set; get; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "label";

        /// <summary>
        /// The text to be used in an enclosing label element.
        /// </summary>
        [Parameter]
        public string Label { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Placement" /> that places the label.
        /// </summary>
        [Parameter]
        public Placement Placement { set; get; } = Placement.End;

        /// <summary>
        /// <c>class</c> applied on the <c>Label</c> element.
        /// </summary>
        [Parameter]
        public string LabelClass { set; get; }

        protected IFormControlContext ControlContext => new FormControlContextBuilder()
            .WithDisabled(_Disabled)
            .WithFilled(_Filled)
            .WithFocused(_Focused)
            .WithRequired(_Required)
            .WithHiddenLabel(_HiddenLabel)
            .WithMargin(_Margin)
            .WithError(_Error)
            .WithVariant(_Variant).Build();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Placement != Placement.End)
                    yield return $"{nameof(Placement)}-{Placement}";

                if (Required.HasValue && Required.Value)
                    yield return nameof(Required);
            }
        }

        protected virtual string _LabelClass
        {
            get => CssUtil.ToClass(Selector, LabelClasses, LabelClass);
        }

        protected virtual IEnumerable<string> LabelClasses
        {
            get
            {
                yield return nameof(Label);

                if (Disabled.HasValue && Disabled.Value)
                    yield return nameof(Disabled);
            }
        }
    }
}
