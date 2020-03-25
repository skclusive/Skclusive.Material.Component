using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Skclusive.Material.Core;
using Skclusive.Core.Component;

namespace Skclusive.Material.Button
{
    public class FabComponent : ButtonCommonComponent
    {
        public FabComponent() : base("Fab")
        {
        }

        protected ElementReference Button { set; get; }

        /// <summary>
        /// The <see cref="ButtonType" /> of the button.
        /// </summary>
        [Parameter]
        public ButtonType Type { set; get; } = ButtonType.Button;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Size" /> of the button.
        /// </summary>
        [Parameter]
        public Size Size { set; get; } = Size.Large;

        /// <summary>
        /// The <see cref="FabVariant" /> of the button.
        /// </summary>
        [Parameter]
        public FabVariant Variant { set; get; } = FabVariant.Round;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if(Variant == FabVariant.Extended)
                    yield return $"{Variant}";

                if (Color == Color.Primary || Color == Color.Secondary)
                    yield return $"{Color}";

                if (Size != Size.Large)
                    yield return $"{nameof(Size)}-{Size}";

                if (Color == Color.Inherit)
                    yield return $"{nameof(Color)}-{nameof(Color.Inherit)}";
            }
        }

        protected virtual string _FocusVisibleClass
        {
            get => CssUtil.ToClass(Selector, FocusVisibleClasses, FocusVisibleClass);
        }

        protected virtual IEnumerable<string> FocusVisibleClasses
        {
            get
            {
                yield return "FocusVisible";
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
