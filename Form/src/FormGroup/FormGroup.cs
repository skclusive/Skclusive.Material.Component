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

        [Parameter]
        public string Component { set; get; } = "div";

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
