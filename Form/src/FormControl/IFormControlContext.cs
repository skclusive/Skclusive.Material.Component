using System;
using Skclusive.Core.Component;

namespace Skclusive.Material.Form
{
    public interface IFormControlContext
    {
        bool? Disabled { get; }

        bool? Filled { get; }

        bool? Focused { get; }

        bool? Required { get; }

        bool? Error { get; }

        bool? HiddenLabel { get; }

        bool? HasStartAdornment { get; }

        Margin? Margin { get; }

        ControlVariant? Variant { get; }

        Action OnFocus { get; }

        Action OnBlur { get; }

        Action OnFill { get; }

        Action OnEmpty { get; }
    }

    public class FormControlContextBuilder
    {
        private class FormControlContext : IFormControlContext
        {
            public bool? Disabled { get; internal set; }

            public bool? Filled { get; internal set; }

            public bool? Focused { get; internal set; }

            public bool? Required { get; internal set; }

            public bool? Error { get; internal set; }

            public bool? HiddenLabel { get; internal set; }

            public bool? HasStartAdornment { get; internal set; }

            public Margin? Margin { get; internal set; }

            public ControlVariant? Variant { get; internal set; }

            public Action OnFocus { get; internal set; }

            public Action OnBlur { get; internal set; }

            public Action OnFill { get; internal set; }

            public Action OnEmpty { get; internal set; }
        }

        private readonly FormControlContext context = new FormControlContext();

        public IFormControlContext Build()
        {
            return context;
        }

        public FormControlContextBuilder WithDisabled(bool? disabled)
        {
            context.Disabled = disabled;

            return this;
        }

        public FormControlContextBuilder WithFilled(bool? filled)
        {
            context.Filled = filled;

            return this;
        }

        public FormControlContextBuilder WithHasStartAdornment(bool? hasStartAdornment)
        {
            context.HasStartAdornment = hasStartAdornment;

            return this;
        }

        public FormControlContextBuilder WithFocused(bool? focused)
        {
            context.Focused = focused;

            return this;
        }

        public FormControlContextBuilder WithRequired(bool? required)
        {
            context.Required = required;

            return this;
        }

        public FormControlContextBuilder WithError(bool? error)
        {
            context.Error = error;

            return this;
        }

        public FormControlContextBuilder WithHiddenLabel(bool? hiddenLabel)
        {
            context.HiddenLabel = hiddenLabel;

            return this;
        }

        public FormControlContextBuilder WithMargin(Margin? margin)
        {
            context.Margin = margin;

            return this;
        }

        public FormControlContextBuilder WithVariant(ControlVariant? variant)
        {
            context.Variant = variant;

            return this;
        }

        public FormControlContextBuilder WithOnFocus(Action onFocus)
        {
            context.OnFocus = onFocus;

            return this;
        }

        public FormControlContextBuilder WithOnBlur(Action onBlur)
        {
            context.OnBlur = onBlur;

            return this;
        }

        public FormControlContextBuilder WithOnFill(Action onFill)
        {
            context.OnFill = onFill;

            return this;
        }

        public FormControlContextBuilder WithOnEmpty(Action onEmpty)
        {
            context.OnEmpty = onEmpty;

            return this;
        }

        public FormControlContextBuilder With(IFormControlContext context)
        {
            WithDisabled(context.Disabled)
            .WithFilled(context.Filled)
            .WithFocused(context.Focused)
            .WithRequired(context.Required)
            .WithHiddenLabel(context.HiddenLabel)
            .WithMargin(context.Margin)
            .WithError(context.Error)
            .WithVariant(context.Variant)
            .WithOnFocus(context.OnFocus)
            .WithOnBlur(context.OnBlur)
            .WithOnFill(context.OnFill)
            .WithOnEmpty(context.OnEmpty);

            return this;
        }
    }
}