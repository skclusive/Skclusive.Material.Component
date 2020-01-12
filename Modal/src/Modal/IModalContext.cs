using System;
using Skclusive.Core.Component;

namespace Skclusive.Material.Modal
{
    public interface IModalContext : IComponentContext
    {
        bool Open { get; }

        bool BackdropInvisible { get; }

        Action<IReference, bool> OnEnter { get; }

        Action<IReference> OnExited { get; }

        Action OnBackdropClick { get; }
    }

    public class ModalContextBuilder : ComponentContextBuilder<ModalContextBuilder, IModalContext>
    {
        public class ModalContext : ComponentContext, IModalContext
        {
            public bool Open { get; internal set; }

            public bool BackdropInvisible { get; internal set; }

            public Action<IReference, bool> OnEnter { get; internal set; }

            public Action<IReference> OnExited { get; internal set; }

            public Action OnBackdropClick { get; internal set; }
        }

        protected ModalContext MContext => base.Context as ModalContext;

        public ModalContextBuilder() : base(new ModalContext())
        {
        }

        public ModalContextBuilder WithOpen(bool open)
        {
            MContext.Open = open;

            return this;
        }

        public ModalContextBuilder WithBackdropInvisible(bool backdropInvisible)
        {
            MContext.BackdropInvisible = backdropInvisible;

            return this;
        }

        public ModalContextBuilder WithOnEnter(Action<IReference, bool> onEnter)
        {
            MContext.OnEnter = onEnter;

            return this;
        }

        public ModalContextBuilder WithOnExited(Action<IReference> onExited)
        {
            MContext.OnExited = onExited;

            return this;
        }

        public ModalContextBuilder WithOnBackdropClick(Action onBackdropClick)
        {
            MContext.OnBackdropClick = onBackdropClick;

            return this;
        }

        public override ModalContextBuilder With(IModalContext context)
        {
            base.With(context)
            .WithOpen(context.Open)
            .WithBackdropInvisible(context.BackdropInvisible)
            .WithRefBack(context.RefBack)
            .WithOnEnter(context.OnEnter)
            .WithOnExited(context.OnExited)
            .WithOnBackdropClick(context.OnBackdropClick);

            return this;
        }

        protected override ModalContextBuilder This()
        {
            return this;
        }
    }
}