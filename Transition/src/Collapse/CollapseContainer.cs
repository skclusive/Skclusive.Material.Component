using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Transition.Component;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Skclusive.Material.Transition
{
    public class CollapseContainerComponent : MaterialComponent
    {
        public CollapseContainerComponent() : base("CollapseContainer")
        {
        }

        [Parameter]
        public TransitionState State  { set; get; }

        [Parameter]
        public IReference WrapperRef { get; set; } = new Reference();

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool In { set; get; }

        [Parameter]
        public int CollapsedHeight { set; get; }

        [Parameter]
        public string WrapperClass { set; get; }

        [Parameter]
        public string WrapperStyle { set; get; }

        [Parameter]
        public string WrapperInnerClass { set; get; }

        [Parameter]
        public string WrapperInnerStyle { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (State == TransitionState.Entered)
                    yield return $"{nameof(TransitionState.Entered)}";

                if (State == TransitionState.Exited && !In && CollapsedHeight == 0)
                    yield return "Hidden";
            }
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("min-height", $"{CollapsedHeight.ToString(CultureInfo.InvariantCulture)}px");
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

        protected virtual string _WrapperInnerStyle
        {
            get => CssUtil.ToStyle(WrapperInnerStyles, WrapperInnerStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> WrapperInnerStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _WrapperInnerClass
        {
            get => CssUtil.ToClass($"{Selector}-WrapperInner", WrapperInnerClasses, WrapperInnerClass);
        }

        protected virtual IEnumerable<string> WrapperInnerClasses
        {
            get
            {
                yield return string.Empty;
            }
        }
    }
}
