
using System.Collections.Generic;

namespace Skclusive.Material.Theme
{
    public interface IStyleProducer
    {
        IDictionary<string, string> Variables(ThemeValue theme);
    }
}