using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.List
{
    public class ListComponent : MaterialComponent
    {
        public ListComponent() : base("List")
        {
        }

        [Parameter]
        public string Component { set; get; } = "ul";

        [Parameter]
        public bool Dense { set; get; } = false;

        [Parameter]
        public bool DisablePadding { set; get; } = false;

        [Parameter]
        public RenderFragment SubheaderContent { set; get; }

        protected IListContext ListContext => new ListContextBuilder().WithDense(Dense).Build();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Dense)
                    yield return $"{nameof(Dense)}";

                if (!DisablePadding)
                    yield return "Padding";

                if (SubheaderContent != null)
                    yield return "Subheader";

            }
        }
    }
}
