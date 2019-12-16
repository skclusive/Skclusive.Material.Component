using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Table
{
    public class TableHeadComponent : MaterialComponent
    {
        public TableHeadComponent() : base("TableHead")
        {
        }

        [Parameter]
        public string Component { set; get; } = "thead";

        protected ITableContentContext TableContentContext => new TableContentContextBuilder()
            .WithPortion(Portion.Head)
            .Build();
    }
}
