using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using System.Collections.Generic;

namespace Skclusive.Material.Form
{
    public class FormLabelComponent : FormConfigContext
    {
        public FormLabelComponent() : base("FormLabel")
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Component { set; get; } = "label";

        [Parameter]
        public string For { set; get; }

        [Parameter]
        public string RequiredClass { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (_Error.HasValue && _Error.Value)
                    yield return $"{nameof(Error)}";

                if (_Filled.HasValue && _Filled.Value)
                    yield return $"{nameof(Filled)}";

                if (_Focused.HasValue && _Focused.Value)
                    yield return $"{nameof(Focused)}";

                if (_Required.HasValue && _Required.Value)
                    yield return $"{nameof(Required)}";
            }
        }

        protected virtual string _RequiredClass
        {
            get => CssUtil.ToClass(Selector, RequiredClasses, RequiredClass);
        }

        protected virtual IEnumerable<string> RequiredClasses
        {
            get
            {
                yield return "Asterisk";

                if (Error.HasValue && Error.Value)
                    yield return nameof(Error);
            }
        }
    }
}
