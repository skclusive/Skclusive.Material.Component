using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using System.Collections.Generic;

namespace Skclusive.Material.Button
{
    public class IconButtonComponent : ButtonCommonComponent
    {
        public IconButtonComponent() : base("IconButton")
        {
        }

        protected ElementReference Button { set; get; }

        /// <summary>
        /// The <see cref="IconSize" /> of the button.
        /// </summary>
        [Parameter]
        public IconSize Size { set; get; } = IconSize.Medium;

        /// <summary>
        /// The <see cref="IconButtonEdge" /> of the button.
        /// </summary>
        [Parameter]
        public IconButtonEdge Edge { set; get; } = IconButtonEdge.None;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Color != Color.Default)
                    yield return $"{nameof(Color)}-{Color}";

                if (Size != IconSize.Medium)
                    yield return $"{nameof(Size)}-{Size}";

                if (Edge != IconButtonEdge.None)
                    yield return $"{nameof(Edge)}-{Edge}";
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
                yield return "Label";
            }
        }

        protected override void OnAfterMount()
        {
            base.OnAfterMount();
        }

        protected override void OnAfterUpdate()
        {
            base.OnAfterUpdate();
        }

        protected override void OnAfterUnmount()
        {
            base.OnAfterUnmount();
        }
    }

    public enum IconSize
    {
        Small,

        Medium
    }

    public enum IconButtonEdge
    {
        Start,

        End,

        None
    }
}
