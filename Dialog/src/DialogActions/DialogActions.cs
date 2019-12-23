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

        [Parameter]
        public string Component { set; get; } = "div";

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
