using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using Skclusive.Material.Script;

namespace Skclusive.Material.Selection
{
    public class RadioGroupComponent : MaterialComponent
    {
        public RadioGroupComponent() : base("RadioGroup")
        {
        }

        [Inject]
        public RadioGroupHelper RadioGroupHelper { set; get; }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool Row { set; get; }

        [Parameter]
        public string Name { set; get; }

        [Parameter]
        public string DefaultValue { set; get; }

        [Parameter]
        public string Value { set; get; }

        protected string ValueState { set; get; }

        protected bool IsControlled => Value != null;

        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { set; get; }

        protected async Task HandleChangeAsync(ChangeEventArgs args)
        {
            if (!IsControlled)
            {
                ValueState = args.Value?.ToString();

                await InvokeAsync(StateHasChanged);
            }
            await OnChange.InvokeAsync(args);
        }

        protected IRadioGroupContext RadioGroupContext => new RadioGroupContextBuilder()
        .WithName(Name)
        .WithValue(IsControlled ? Value : ValueState)
        .WithOnChange(EventCallback.Factory.Create<ChangeEventArgs>(this, HandleChangeAsync))
        .Build();

        public async Task FocusAsync()
        {
            await RadioGroupHelper.FocusAsync(RootRef.Current);
        }
    }
}
