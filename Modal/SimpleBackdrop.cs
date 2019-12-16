using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Modal
{
    public class SimpleBackdropComponent : MaterialContextComponent
    {
        public SimpleBackdropComponent() : base("SimpleBackdrop")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool Invisible { set; get; }

        [Parameter]
        public bool Open { set; get; }

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
