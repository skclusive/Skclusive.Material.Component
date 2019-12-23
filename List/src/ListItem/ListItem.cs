using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Skclusive.Material.List
{
    public class ListItemComponent : MaterialComponentBase
    {
        public ListItemComponent() : base("ListItem")
        {
        }

        [Parameter]
        public RenderFragment<IListItemContext> ChildContent { get; set; }

        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        [Parameter]
        public bool NoWrap { set; get; }

        [Parameter]
        public string Component { set; get; }

        [Parameter]
        public AlignItems AlignItems { set; get; } = AlignItems.Center;

        [Parameter]
        public bool AutoFocus { set; get; }

        [Parameter]
        public bool Button { set; get; } = false;

        [Parameter]
        public bool? Dense { set; get; }

        [Parameter]
        public bool DisableGutters { set; get; }

        [Parameter]
        public bool Divider { set; get; } = false;

        [Parameter]
        public string FocusVisibleClass { set; get; }

        [Parameter]
        public RenderFragment SecondaryAction { set; get; }

        [Parameter]
        public bool Selected { set; get; } = false;

        [Parameter]
        public string ContainerComponent { set; get; } = "li";

        [Parameter]
        public string ContainerStyle { set; get; }

        [Parameter]
        public string ContainerClass { set; get; }

        [CascadingParameter]
        public IListContext Context { set; get; }

        protected IListItemContext GetItemContext(IComponentContext context) => new ListItemContextBuilder()
            .With(context)
            .WithClass(_Class)
            .WithStyle(_Style)
            .WithRefBack(ChildRef)
            .WithButton(Button)
            .WithOnClick(HandleClick)
            .WithFocusVisibleClass(_FocusVisibleClass)
            .Build();

        protected string _Component
        {
            get
            {
                var component = Component ?? "li";
                if (string.IsNullOrWhiteSpace(component) && Button)
                {
                    component = "div";
                }
                if (component == "li" && (HasSecondaryAction && ContainerComponent == "li"))
                {
                    component = "div";
                }
                return component;
            }
        }

        protected bool IsDense => Dense ?? Context?.Dense ?? false;

        protected bool HasSecondaryAction => SecondaryAction != null;

        public IListContext ChildContext => new ListContextBuilder()
            .WithDense(IsDense)
            .WithAlignItems(AlignItems)
            .Build();

        //public override async Task SetParametersAsync(ParameterView parameters)
        //{
        //    await base.SetParametersAsync(parameters);
        //}

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (IsDense)
                    yield return "Dense";

                if (!DisableGutters)
                    yield return "Gutters";

                if (Divider)
                    yield return $"{nameof(Divider)}";

                if (Button)
                    yield return $"{nameof(Button)}";

                if (AlignItems == AlignItems.FlexStart)
                    yield return $"{nameof(AlignItems)}-{AlignItems}";

                if (HasSecondaryAction)
                    yield return $"{nameof(SecondaryAction)}";

                if (Selected)
                    yield return $"{nameof(Selected)}";
            }
        }

        protected virtual string _FocusVisibleClass
        {
            get => CssUtil.ToClass($"{Selector}-FocusVisible", FocusVisibleClasses, FocusVisibleClass);
        }

        protected virtual IEnumerable<string> FocusVisibleClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected virtual string _ContainerStyle
        {
            get => CssUtil.ToStyle(ContainerStyles, ContainerStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ContainerStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ContainerClass
        {
            get => CssUtil.ToClass($"{Selector}-Container", ContainerClasses, ContainerClass);
        }

        protected virtual IEnumerable<string> ContainerClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

    }
}
