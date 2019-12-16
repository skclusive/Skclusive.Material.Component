using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Material.Selection
{
    public class RadioComponent : SelectionConfig
    {
        public RadioComponent() : base("Radio")
        {
        }

        private static RenderFragment DefaultIcon = (RenderTreeBuilder builder) =>
        {
            builder.OpenComponent<RadioButtonUncheckedIcon>(0);
            builder.CloseComponent();
        };

        private static RenderFragment DefaultCheckedIcon = (RenderTreeBuilder builder) =>
        {
            builder.OpenComponent<RadioButtonCheckedIcon>(0);
            builder.CloseComponent();
        };

        protected string _CheckedClass => $"~{Selector}-Checked";

        protected string _DisabledClass => $"~{Selector}-Disabled";

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            Icon = Icon ?? DefaultIcon;

            CheckedIcon = CheckedIcon ?? DefaultCheckedIcon;

            if (Color == default)
            {
                Color = Skclusive.Core.Component.Color.Secondary;
            }
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Color)}-{Color}";
            }
        }
    }
}
