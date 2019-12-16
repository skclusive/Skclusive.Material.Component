using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Dialog
{
    public class DialogTitleComponent : MaterialComponent
    {
        public DialogTitleComponent() : base("DialogTitle")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool DisableTypography { set; get; }
    }
}
