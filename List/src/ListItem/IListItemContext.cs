using System;
using System.Threading.Tasks;
using Skclusive.Core.Component;

namespace Skclusive.Material.List
{
    public interface IListItemContext : IComponentContext
    {
        bool Button { get; }

        string FocusVisibleClass { get; }

        Func<EventArgs, Task> OnClick { get; }
    }

    public class ListItemContextBuilder : ComponentContextBuilder<ListItemContextBuilder, IListItemContext>
    {
        protected class ListItemContext : ComponentContext, IListItemContext
        {
            public bool Button { get; internal set; }

            public string FocusVisibleClass { get; internal set; }

            public Func<EventArgs, Task> OnClick { get; internal set; }
        }

        public ListItemContextBuilder() : base(new ListItemContext())
        {
        }

        protected override ListItemContextBuilder This() => this;

        protected ListItemContext ListContext => Context as ListItemContext;

        public ListItemContextBuilder WithButton(bool button)
        {
            ListContext.Button = button;

            return this;
        }

        public ListItemContextBuilder WithFocusVisibleClass(string focusVisibleClass)
        {
            ListContext.FocusVisibleClass = focusVisibleClass;

            return this;
        }

        public ListItemContextBuilder WithOnClick(Func<EventArgs, Task> onClick)
        {
            ListContext.OnClick = onClick;

            return this;
        }

        public override ListItemContextBuilder With(IListItemContext context)
        {
            base.With(context);

            WithButton(context.Button);
            WithOnClick(context.OnClick);
            WithFocusVisibleClass(context.FocusVisibleClass);

            return this;
        }
    }
}