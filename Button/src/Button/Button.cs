using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Skclusive.Core.Component;

namespace Skclusive.Material.Button
{
    public class ButtonComponent : ButtonCommonComponent
    {
        public ButtonComponent() : base("Button")
        {
        }

        protected ElementReference Button { set; get; }

        [Parameter]
        public ButtonType Type { set; get; } = ButtonType.Button;

        [Parameter]
        public ButtonVariant Variant { set; get; } = ButtonVariant.Text;

        [Parameter]
        public Size Size { set; get; } = Size.Medium;

        [Parameter]
        public bool FullWidth { set; get; }

        [Parameter]
        public RenderFragment StartIcon { set; get; }

        [Parameter]
        public RenderFragment EndIcon { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return Variant.ToString();

                if (Color != Color.Default && Color != Color.Inherit)
                    yield return $"{Variant}-{Color}";

                if (Size != Size.Medium)
                    yield return $"{nameof(Size)}-{Size}";

                if (Size != Size.Medium)
                    yield return $"{Variant}-{nameof(Size)}-{Size}";

                if (Color == Color.Inherit)
                    yield return $"{nameof(Color)}-{nameof(Color.Inherit)}";

                if (FullWidth)
                    yield return nameof(FullWidth);
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

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            Console.WriteLine("Button.SetParametersAsync");

            await base.SetParametersAsync(parameters);

            Console.WriteLine("StartIcon is null  : " + (StartIcon is null));

            Console.WriteLine("EndIcon is null  : " + (EndIcon is null));
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

    public enum ButtonVariant
    {
        Text,

        Outlined,

        Contained
    }
}
