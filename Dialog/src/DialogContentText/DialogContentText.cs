using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Dialog
{
    public class DialogContentTextComponent : MaterialComponent
    {
        public DialogContentTextComponent() : base("DialogContentText")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "p";
    }
}
