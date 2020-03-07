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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, the backdrop is invisible.
        /// It can be used when rendering a popover or a custom select component.
        /// </summary>
        [Parameter]
        public bool Invisible { set; get; }

        /// <summary>
        /// If <c>true</c>, the backdrop is open.
        /// </summary>
        [Parameter]
        public bool Open { set; get; }

        /// <summary>
        /// The duration for the transition, in milliseconds.
        /// </summary>
        [Parameter]
        public int TransitionDuration { set; get; }

        /// <summary>
        /// The appear duration for the transition, in milliseconds.
        /// </summary>
        [Parameter]
        public int? AppearTransitionDuration { set; get; }

        /// <summary>
        /// The enter duration for the transition, in milliseconds.
        /// </summary>
        [Parameter]
        public int? EnterTransitionDuration { set; get; }

        /// <summary>
        /// The exit duration for the transition, in milliseconds.
        /// </summary>
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
