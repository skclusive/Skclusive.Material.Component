using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Hidden
{
    public class HiddenComponent : MaterialComponent
    {
        public HiddenComponent() : base("Hidden")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool ExtraSmallDown { set; get; }

        [Parameter]
        public bool ExtraSmallUp { set; get; }

        [Parameter]
        public bool SmallUp { set; get; }

        [Parameter]
        public bool SmallDown { set; get; }

        [Parameter]
        public bool MediumDown { set; get; }

        [Parameter]
        public bool MediumUp { set; get; }
        
        [Parameter]
        public bool LargeDown { set; get; }

        [Parameter]
        public bool LargeUp { set; get; }

        [Parameter]
        public bool ExtraLargeDown { set; get; }

        [Parameter]
        public bool ExtraLargeUp { set; get; }

        [Parameter]
        public Breakpoint[] Only { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if(ExtraSmallUp)
                    yield return nameof(ExtraSmallUp);

                if (ExtraSmallDown)
                    yield return nameof(ExtraSmallDown);

                if (SmallUp)
                    yield return nameof(SmallUp);

                if (SmallDown)
                    yield return nameof(SmallDown);

                if (MediumUp)
                    yield return nameof(MediumUp);

                if (MediumDown)
                    yield return nameof(MediumDown);

                if (LargeUp)
                    yield return nameof(LargeUp);

                if (LargeDown)
                    yield return nameof(LargeDown);

                if (ExtraLargeUp)
                    yield return nameof(ExtraLargeUp);

                if (ExtraLargeDown)
                    yield return nameof(ExtraLargeDown);

                if (Only != null)
                {
                    foreach(var breakpoint in Only)
                    yield return $"{nameof(breakpoint)}Only";
                }
            }
        }
    }
}
