using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using System.Collections.Generic;

namespace Skclusive.Material.Form
{
    public class FormLabelComponent : FormConfig
    {
        public FormLabelComponent() : base("FormLabel")
        {
        }

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

                if (Error.HasValue && Error.Value)
                    yield return $"{nameof(Error)}";

                if (Filled.HasValue && Filled.Value)
                    yield return $"{nameof(Filled)}";

                if (Focused.HasValue && Focused.Value)
                    yield return $"{nameof(Focused)}";

                if (Required.HasValue && Required.Value)
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
