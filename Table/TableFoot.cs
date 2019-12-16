using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Table
{
    public class TableFootComponent : MaterialComponent
    {
        public TableFootComponent() : base("TableFoot")
        {
        }

        [Parameter]
        public string Component { set; get; } = "tfoot";

        protected ITableContentContext TableContentContext => new TableContentContextBuilder()
            .WithPortion(Portion.Foot)
            .Build();
    }
}
