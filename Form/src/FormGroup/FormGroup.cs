using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;

namespace Skclusive.Material.Form
{
    public class FormGroupComponent : MaterialComponent
    {
        public FormGroupComponent() : base("FormGroup")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// Display group of elements in a compact row.
        /// </summary>
        [Parameter]
        public bool Row { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Row)
                    yield return nameof(Row);
            }
        }
    }
}
