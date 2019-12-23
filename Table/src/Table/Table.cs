using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Table
{
    public class TableComponent : MaterialComponent
    {
        public TableComponent() : base("Table")
        {
        }

        [Parameter]
        public string Component { set; get; } = "table";

        [Parameter]
        public Padding Padding { get; set; } = Padding.Default;

        [Parameter]
        public Size Size { get; set; } = Size.Medium;

        [Parameter]
        public bool StickyHeader { get; set; } = false;

        protected ITableContext TableContext => new TableContextBuilder()
            .WithPadding(Padding)
            .WithSize(Size)
            .WithStickyHeader(StickyHeader)
            .Build();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (StickyHeader)
                    yield return $"{nameof(StickyHeader)}";
            }
        }
    }
}
