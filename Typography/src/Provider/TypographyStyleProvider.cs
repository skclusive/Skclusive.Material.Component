using Skclusive.Core.Component;

namespace Skclusive.Material.Typography
{
    public class TypographyStyleProvider : StyleTypeProvider
    {
        public TypographyStyleProvider() : base(priority: 110, typeof(TypographyStyle))
        {
        }
    }
}