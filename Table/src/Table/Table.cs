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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "table";

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Padding" /> that allows TableCells to inherit padding of the Table.
        /// </summary>
        [Parameter]
        public Padding Padding { get; set; } = Padding.Default;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Size" /> that allows TableCells to inherit size of the Table.
        /// </summary>
        [Parameter]
        public Size Size { get; set; } = Size.Medium;

        /// <summary>
        /// Set the header sticky.
        /// <remarks>
        /// ⚠️ It doesn't work with IE 11.
        /// </remarks>
        /// </summary>
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
