using Skclusive.Core.Component;

namespace Skclusive.Material.Table
{
    public class TableStyleProvider : StyleTypeProvider
    {
        public TableStyleProvider() : base
        (
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