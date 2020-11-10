
namespace Skclusive.Material.Theme
{
    public interface IThemeProducer
    {
        string BuildCommon(ThemeValue theme);

        string BuildScheme(ThemeValue theme);

        string BuildMediaScheme(ThemeValue theme);
    }
}