using Skclusive.Core.Component;

namespace Skclusive.Material.Card
{
    public class CardStyleProvider : StyleTypeProvider
    {
        public CardStyleProvider() : base
        (
            typeof(CardStyle),
            typeof(CardContentStyle),
            typeof(CardHeaderStyle),
            typeof(CardMediaStyle),
            typeof(CardActionsStyle),
            typeof(CardActionAreaStyle)
        )
        {
        }
    }
}