using Skclusive.Core.Component;

namespace Skclusive.Material.Baseline
{
    public class BaselineStyleProvider : StyleTypeProvider
    {
        public BaselineStyleProvider() : base(priority: 10, typeof(BaselineStyle))
        {
        }
    }
}