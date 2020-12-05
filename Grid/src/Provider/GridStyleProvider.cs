using Skclusive.Core.Component;

namespace Skclusive.Material.Grid
{
    public class GridStyleProvider : StyleTypeProvider
    {
        public GridStyleProvider() : base(priority: 30, typeof(GridStyle))
        {
        }
    }
}