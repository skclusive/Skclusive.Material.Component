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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// Display group of elements in a compact row.
        /// </summary>
        [Parameter]
        public bool Row { set; get; }

        /// <summary>
        /// The name used to reference the value of the control.
        /// </summary>
        [Parameter]
        public string Name { set; get; }

        /// <summary>
        /// The default <c>input</c> element value. Use when the component is not controlled.
        /// </summary>
        [Parameter]
        public string DefaultValue { set; get; }

        /// <summary>
        /// Value of the selected radio button. The DOM API casts this to a string.
        /// </summary>
        [Parameter]
        public string Value { set; get; }

        protected string ValueState { set; get; }

        protected bool IsControlled => Value != null;

        protected override void OnParametersSet()
        {
            if (ValueState is null && !(DefaultValue is null))
            {
                ValueState = DefaultValue;
            }
        }

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
