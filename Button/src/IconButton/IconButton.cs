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
        /// The <see cref="IconButtonSize" /> of the button.
        /// </summary>
        [Parameter]
        public IconButtonSize Size { set; get; } = IconButtonSize.Medium;

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

                if (Size != IconButtonSize.Medium)
                    yield return $"{nameof(Size)}-{Size}";

                if (Edge != IconButtonEdge.None)
                    yield return $"{nameof(Edge)}-{Edge}";
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
}
