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

        [Parameter]
        public string Component { set; get; } = "label";

        [Parameter]
        public string Label { set; get; }

        [Parameter]
        public Placement Placement { set; get; } = Placement.End;

        [Parameter]
        public string LabelClass { set; get; }

        [Parameter]
        public RenderFragment<IFormControlContext> ControlContent { set; get; }

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
