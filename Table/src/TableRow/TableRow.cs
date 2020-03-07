using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Table
{
    public class TableRowComponent : MaterialComponent
    {
        public TableRowComponent() : base("TableRow")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "tr";

        /// <summary>
        /// If <c>true</c>, the table row will have the selected shading.
        /// </summary>
        [Parameter]
        public bool Selected { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the table row will shade on hover.
        /// </summary>
        [Parameter]
        public bool Hover { set; get; } = false;

        [CascadingParameter]
        public ITableContentContext ContentContext { set; get; }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (ContentContext?.Portion != null)
                    yield return $"{ContentContext?.Portion}";

                if (Hover)
                    yield return nameof(Hover);

                if (Selected)
                    yield return nameof(Selected);
            }
        }
    }
}
