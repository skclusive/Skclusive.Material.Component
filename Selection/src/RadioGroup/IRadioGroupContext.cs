using Microsoft.AspNetCore.Components;

namespace Skclusive.Material.Selection
{
    public interface IRadioGroupContext
    {
        string Name { get; }

        string Value { get; }

        EventCallback<ChangeEventArgs> OnChange { get; }
    }

    public class RadioGroupContextBuilder
    {
        private class RadioGroupContext : IRadioGroupContext
        {
            public string Name { get; internal set; }

            public string Value { get; internal set; }

            public EventCallback<ChangeEventArgs> OnChange { get; internal set; }
        }

        private readonly RadioGroupContext context = new RadioGroupContext();

        public IRadioGroupContext Build()
        {
            return context;
        }

        public RadioGroupContextBuilder WithName(string name)
        {
            context.Name = name;

            return this;
        }

        public RadioGroupContextBuilder WithValue(string value)
        {
            context.Value = value;

            return this;
        }

        public RadioGroupContextBuilder WithOnChange(EventCallback<ChangeEventArgs> onChange)
        {
            context.OnChange = onChange;

            return this;
        }

        public RadioGroupContextBuilder With(IRadioGroupContext context)
        {
            WithName(context.Name);
            WithValue(context.Value);
            WithOnChange(context.OnChange);

            return this;
        }
    }
}