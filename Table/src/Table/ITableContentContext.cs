using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Table
{
    public interface ITableContentContext
    {
        Portion Portion { get; }
    }

    public class TableContentContextBuilder
    {
        private class TableContentContext : ITableContentContext
        {
            public Portion Portion { get; internal set; }
        }

        private readonly TableContentContext context = new TableContentContext();

        public ITableContentContext Build()
        {
            return context;
        }

        public TableContentContextBuilder WithPortion(Portion portion)
        {
            context.Portion = portion;

            return this;
        }

        public TableContentContextBuilder With(ITableContentContext context)
        {
            WithPortion(context.Portion);

            return this;
        }
    }
}