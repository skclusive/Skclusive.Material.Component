using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Dialog
{
    public class DialogContentComponent : MaterialComponent
    {
        public DialogContentComponent() : base("DialogContent")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// Display the top and bottom dividers.
        /// </summary>
        [Parameter]
        public bool Dividers { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Dividers)
                    yield return $"{nameof(Dividers)}";
            }
        }
    }
}
