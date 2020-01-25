﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Material.Selection
{
    public class CheckboxComponent : SelectionConfig
    {
        public CheckboxComponent() : base("Checkbox")
        {
        }

        private static RenderFragment DefaultIcon = (RenderTreeBuilder builder) =>
        {
            builder.OpenComponent<CheckBoxOutlineBlankIcon>(0);
            builder.CloseComponent();
        };

        private static RenderFragment DefaultCheckedIcon = (RenderTreeBuilder builder) =>
        {
            builder.OpenComponent<CheckBoxIcon>(0);
            builder.CloseComponent();
        };

        private static RenderFragment DefaultIndeterminateIcon = (RenderTreeBuilder builder) =>
        {
            builder.OpenComponent<IndeterminateCheckBoxIcon>(0);
            builder.CloseComponent();
        };

        [Parameter]
        public bool Indeterminate { set; get; }

        [Parameter]
        public RenderFragment IndeterminateIcon { set; get; }

        protected string _CheckedClass => $"~{Selector}-Checked";

        protected string _DisabledClass => $"~{Selector}-Disabled";

        protected RenderFragment _IndeterminateIcon => IndeterminateIcon ?? DefaultIndeterminateIcon;

        protected RenderFragment _Icon => Indeterminate ? _IndeterminateIcon : Icon ?? DefaultIcon;

        protected RenderFragment _CheckedIcon => Indeterminate ? _IndeterminateIcon : CheckedIcon ?? DefaultCheckedIcon;

        protected Skclusive.Core.Component.Color _Color => Color == default ? Skclusive.Core.Component.Color.Secondary : Color;

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            InputProps["data-indeterminate"] = Indeterminate.ToString();
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(Color)}-{_Color}";

                if (Indeterminate)
                    yield return $"{nameof(Indeterminate)}";
            }
        }
    }
}
