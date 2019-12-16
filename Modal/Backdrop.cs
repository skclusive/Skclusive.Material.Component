using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;

namespace Skclusive.Material.Modal
{
    public class BackdropComponent : MaterialComponent
    {
        public BackdropComponent() : base("Backdrop")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool Invisible { set; get; }

        [Parameter]
        public bool Open { set; get; }

        [Parameter]
        public int TransitionDuration { set; get; }

        [Parameter]
        public int? AppearTransitionDuration { set; get; }

        [Parameter]
        public int? EnterTransitionDuration { set; get; }

        [Parameter]
        public int? ExitTransitionDuration { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Invisible)
                    yield return nameof(Invisible);
            }
        }
    }
}
