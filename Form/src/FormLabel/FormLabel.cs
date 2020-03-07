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

        /// <summary>
        /// ChildContent of the current component.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "label";

        /// <summary>
        /// html for attribute for the label.
        /// </summary>
        [Parameter]
        public string For { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Required</c> element.
        /// </summary>
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
