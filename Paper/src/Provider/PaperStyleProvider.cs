using Skclusive.Core.Component;

namespace Skclusive.Material.Paper
{
    public class PaperStyleProvider : StyleTypeProvider
    {
        public PaperStyleProvider() : base(priority: 70, typeof(PaperStyle))
        {
        }
    }
}