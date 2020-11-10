using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Table
{
    public partial class TableHead : MaterialComponent
    {
        public TableHead() : base("TableHead")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "thead";

        protected ITableContentContext TableContentContext => new TableContentContextBuilder()
            .WithPortion(Portion.Head)
            .Build();
    }
}
