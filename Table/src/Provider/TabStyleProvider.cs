using Skclusive.Core.Component;

namespace Skclusive.Material.Table
{
    public class TableStyleProvider : StyleTypeProvider
    {
        public TableStyleProvider() : base
        (
            priority: 190,
            typeof(TableStyle),
            typeof(TableBodyStyle),
            typeof(TableCellStyle),
            typeof(TableFootStyle),
            typeof(TableHeadStyle),
            typeof(TableRowStyle),
            typeof(TableSortLabelStyle)
        )
        {
        }
    }
}