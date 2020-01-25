using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Skclusive.Core.Component;

namespace Skclusive.Material.Selection
{
    public class SwitchBaseComponent : SelectionConfig
    {
        public SwitchBaseComponent() : base("SwitchBase")
        {
        }

        protected ElementReference Input { set; get; }

        protected bool? CheckedState { set; get; }

        protected bool IsControlled => Checked.HasValue;

        protected bool? IsChecked => IsControlled ? Checked : CheckedState;

        protected bool HasLabelFor => Type == "checkbox" || Type == "radio";

        protected string InputId => HasLabelFor ? Id : null;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            CheckedState = DefaultChecked;
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (IsChecked.HasValue && IsChecked.Value)
                {
                    yield return $"{nameof(Checked)}";

                    if (!string.IsNullOrWhiteSpace(CheckedClass))
                        yield return CheckedClass;
                }

                if (Disabled.HasValue && Disabled.Value && !string.IsNullOrWhiteSpace(DisabledClass))
                    yield return DisabledClass;
            }
        }

        protected virtual string _InputStyle
        {
            get => CssUtil.ToStyle(InputStyles, InputStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> InputStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected string _InputClass
        {
            get
            {
                return CssUtil.ToClass($"{Selector}-Input", InputClasses, InputClass);
            }
        }

        protected virtual IEnumerable<string> InputClasses
        {
            get
            {
                yield return string.Empty;

                if (Disabled.HasValue && Disabled.Value)
                    yield return $"{nameof(Disabled)}";
            }
        }


        protected void HandleChange(ChangeEventArgs args)
        {
            OnChange.InvokeAsync(args);

            if (!IsControlled)
            {
                CheckedState = !(CheckedState.HasValue && CheckedState.Value);

                StateHasChanged();
            }
        }

        protected async Task HandleChangeAsync(ChangeEventArgs args)
        {
            HandleChange(args);

            await Task.CompletedTask;
        }
    }
}
