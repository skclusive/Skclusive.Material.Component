using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Dialog
{
    public class DialogActionsComponent : MaterialComponent
    {
        public DialogActionsComponent() : base("DialogActions")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, the actions do not have additional margin.
        /// </summary>
        [Parameter]
        public bool DisableSpacing { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (!DisableSpacing)
                    yield return "Spacing";
            }
        }
    }
}
