using System;
using System.Collections.Generic;
using System.Text;
using Skclusive.Core.Component;

namespace Skclusive.Material.Tooltip
{
    public interface IPopperContext : IComponentContext
    {
        bool Open { get; }
        Action<IReference, bool> OnEnter { get; }
        Action<IReference> OnExited { get; }
    }

    public class PopperContextBuilder : ComponentContextBuilder<PopperContextBuilder, IPopperContext>
    {
        public class PopperContext : ComponentContext, IPopperContext
        {
            public bool Open { get; internal set; }
            public Action<IReference, bool> OnEnter { get; internal set; }
            public Action<IReference> OnExited { get; internal set; }
        }

        protected PopperContext MContext => base.Context as PopperContext;

        public PopperContextBuilder() : base(new PopperContext())
        {
        }

        public PopperContextBuilder WithOpen(bool open)
        {
            MContext.Open = open;

            return this;
        }

        public PopperContextBuilder WithOnEnter(Action<IReference, bool> onEnter)
        {
            MContext.OnEnter = onEnter;

            return this;
        }

        public PopperContextBuilder WithOnExited(Action<IReference> onExited)
        {
            MContext.OnExited = onExited;

            return this;
        }

        public override PopperContextBuilder With(IPopperContext context)
        {
            base.With(context)
                .WithOpen(context.Open)
                .WithRefBack(context.RefBack)
                .WithOnEnter(context.OnEnter)
                .WithOnExited(context.OnExited);

            return this;
        }

        protected override PopperContextBuilder This()
        {
            return this;
        }
    }
}
