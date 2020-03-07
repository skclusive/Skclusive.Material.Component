using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Material.Tab
{
    public class TabComponent : MaterialComponentBase
    {
        public TabComponent() : base("Tab")
        {
        }

        [CascadingParameter]
        public ITabsContext TabsContext { set; get; }

        /// <summary>
        /// If <c>true</c>, the  keyboard focus ripple will be disabled.
        /// <c>DisableRipple</c> must also be true.
        /// </summary>
        [Parameter]
        public bool DisableFocusRipple { set; get; }

        /// <summary>
        /// If <c>true</c>, the ripple effect will be disabled.
        /// </summary>
        [Parameter]
        public bool DisableRipple { set; get; }

        /// <summary>
        /// Tab labels appear in a single row.
        /// They can use a second line if needed.
        /// </summary>
        [Parameter]
        public bool Wrapped { set; get; }

        /// <summary>
        /// You can provide your own value. Otherwise, we fallback to the child position index.
        /// </summary>
        [Parameter]
        public object Value { set; get; }

        /// <summary>
        /// The label text.
        /// </summary>
        [Parameter]
        public string Label { set; get; }

        /// <summary>
        /// The icon content.
        /// </summary>
        [Parameter]
        public RenderFragment IconContent { set; get; }

        /// <summary>
        /// The label content.
        /// </summary>
        [Parameter]
        public RenderFragment LabelContent { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Wrapper</c> element.
        /// </summary>
        [Parameter]
        public string WrapperStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Wrapper</c> element.
        /// </summary>
        [Parameter]
        public string WrapperClass { set; get; }

        /// <summary>
        /// aria-controls value.
        /// </summary>
        [Parameter]
        public string Control { set; get; }

        protected bool FullWidth => TabsContext.FullWidth;

        protected Color TextColor => TabsContext.TextColor;

        protected EventCallback<object> OnChange => TabsContext.OnChange;

        protected bool Selected => object.Equals(Value, TabsContext.Value);

        protected RenderFragment Indicator => Selected ? TabsContext.Indicator : null;

        protected string _Id => $"{Id}-{Value}";

        protected string _Control => $"{Control}-{Value}";

        protected override void OnInitialized()
        {
            Value = Value ?? TabsContext.CreateValue();
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{nameof(TextColor)}-{TextColor}";

                if (Selected)
                yield return $"{nameof(Selected)}";

                if (FullWidth)
                yield return $"{nameof(FullWidth)}";

                if (Wrapped)
                yield return $"{nameof(Wrapped)}";

                if ((LabelContent != null || !string.IsNullOrWhiteSpace(Label)) && IconContent != null)
                yield return $"LabelIcon";
            }
        }


        protected virtual string _WrapperStyle
        {
            get => CssUtil.ToStyle(WrapperStyles, WrapperStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> WrapperStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _WrapperClass
        {
            get => CssUtil.ToClass($"{Selector}-Wrapper", WrapperClasses, WrapperClass);
        }

        protected virtual IEnumerable<string> WrapperClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected override async Task HandleClickAsync(EventArgs args)
        {
            await OnChange.InvokeAsync(Value);

            await base.HandleClickAsync(args);
        }
    }
}
