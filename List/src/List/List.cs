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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "ul";

        /// <summary>
        /// If <c>true</c>, compact vertical padding designed for keyboard and mouse input will be used for
        /// the list and list items.
        /// The prop is available to descendant components as the <c>dense</c> context.
        /// </summary>
        [Parameter]
        public bool Dense { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, vertical padding will be removed from the list.
        /// </summary>
        [Parameter]
        public bool DisablePadding { set; get; } = false;

        /// <summary>
        /// The content of the subheader, normally <c>ListSubheader</c>.
        /// </summary>
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
