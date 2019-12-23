using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Button
{
    public class RippleComponent : MaterialComponentBase
    {
        public RippleComponent() : base("Ripple")
        {
        }

        [Parameter]
        public bool In { set; get; }

        [Parameter]
        public bool Pulsate { set; get; }

        [Parameter]
        public double RippleX { set; get; }

        [Parameter]
        public double RippleY { set; get; }

        [Parameter]
        public double RippleSize { set; get; }

        [Parameter]
        public int Timeout { set; get; }

        [Parameter]
        public Action<IReference> OnExited { set; get; }

        [Parameter]
        public string ChildClass { set; get; }

        [Parameter]
        public string ChildStyle { set; get; }

        protected bool Leaving { set; get; }

        protected double Width => RippleSize;

        protected double Height => RippleSize;

        protected double Top => -(RippleSize / 2) + RippleY;

        protected double Left => -(RippleSize / 2) + RippleX;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return "Visible";

                if (Pulsate)
                    yield return nameof(Pulsate);
            }
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>(nameof(Width), $"{Width}px");

                yield return Tuple.Create<string, object>(nameof(Height), $"{Height}px");

                yield return Tuple.Create<string, object>(nameof(Top), $"{Top}px");

                yield return Tuple.Create<string, object>(nameof(Left), $"{Left}px");
            }
        }

        protected virtual string _ChildStyle
        {
            get => CssUtil.ToStyle(ChildStyles, ChildStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ChildStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ChildClass
        {
            get => CssUtil.ToClass(Selector, ChildClasses, ChildClass);
        }

        protected virtual IEnumerable<string> ChildClasses
        {
            get
            {
                yield return "Child";

                if (Leaving)
                    yield return "Child-Leaving";

                if (Pulsate)
                    yield return "Child-Pulsate";
            }
        }

        protected override void OnParametersSet()
        {
            // Console.WriteLine("Ripple.OnParametersSet");

            if (!In)
            {
                Leaving = true;

                if (OnExited != null)
                {
                    RunTimeout(() => OnExited(Reference.Empty), Timeout);
                }
            }
        }
    }
}
