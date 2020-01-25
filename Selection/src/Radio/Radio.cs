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

        [CascadingParameter]
        public IRadioGroupContext RadioGroupContext { set; get; }

        protected string _Name => string.IsNullOrWhiteSpace(Name) ? RadioGroupContext?.Name : Name;

        protected bool? _Checked => Checked.HasValue ? Checked : (object.Equals(RadioGroupContext?.Value, Value));

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

        protected RenderFragment _Icon => Icon ?? DefaultIcon;

        protected RenderFragment _CheckedIcon => CheckedIcon ?? DefaultCheckedIcon;

        protected Skclusive.Core.Component.Color _Color => Color == default ? Skclusive.Core.Component.Color.Secondary : Color;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Color)}-{_Color}";
            }
        }

        protected async Task HandleChangeAsync(ChangeEventArgs args)
        {
            await OnChange.InvokeAsync(args);

            await RadioGroupContext?.OnChange.InvokeAsync(args);
        }
    }
}
