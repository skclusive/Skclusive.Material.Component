using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skclusive.Material.Modal
{
    public enum ModalCloseReason
    {
        BackdropClick,

        Escape
    }

    public class ModalComponent : MaterialComponentBase
    {
        public ModalComponent() : base("Modal")
        {
        }

        [Parameter]
        public RenderFragment<IModalContext> BackdropContent { set; get; }

        [Parameter]
        public RenderFragment<IModalContext> ChildContent { get; set; }

        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        [Parameter]
        public ElementReference ContainerRef { set; get; }

        [Parameter]
        public bool Open { set; get; }

        [Parameter]
        public bool CloseAfterTransition { set; get; }

        [Parameter]
        public bool DisableAutoFocus { set; get; }

        [Parameter]
        public bool DisableBackdropClick { set; get; }

        [Parameter]
        public bool DisableEnforceFocus { set; get; }

        [Parameter]
        public bool DisableEscapeKeyDown { set; get; }

        [Parameter]
        public bool DisablePortal { set; get; }

        [Parameter]
        public bool DisableRestoreFocus { set; get; }

        [Parameter]
        public bool DisableScrollLock { set; get; }

        [Parameter]
        public bool HideBackdrop { set; get; }

        [Parameter]
        public bool KeepMounted { set; get; }

        [Parameter]
        public Action OnBackdropClick { set; get; }

        [Parameter]
        public Action<ModalCloseReason> OnClose { set; get; }

        [Parameter]
        public Action OnEscapeKeyDown { set; get; }

        [Parameter]
        public Action OnRendered { set; get; }

        [Parameter]
        public bool HasTransition { set; get; }

        protected bool Exited { set; get; } = true;

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("position", "fixed");

                yield return Tuple.Create<string, object>("z-index", "10000");

                yield return Tuple.Create<string, object>("right", "0");

                yield return Tuple.Create<string, object>("bottom", "0");

                yield return Tuple.Create<string, object>("top", "0");

                yield return Tuple.Create<string, object>("left", "0");

                if (!Open)
                yield return Tuple.Create<string, object>("visibility", "hidden");
            }
        }

        private ModalContextBuilder ModalContextBuilder => new ModalContextBuilder().WithRefBack(ChildRef)
                .WithOpen(Open)
                .WithOnEnter(HandleEnter)
                .WithOnExited(HandleExited)
                .WithOnBackdropClick(HandleBackdropClick);

        protected IModalContext ModalContext => ModalContextBuilder.Build();

        protected IModalContext GetModalContext(IComponentContext context)
        {
            return ModalContextBuilder.WithRefBack(new DelegateReference(ChildRef, context.RefBack))
                .Build();
        }

        protected bool IsTopModal => true;

        protected void HandleBackdropClick()
        {
            System.Console.WriteLine("OnBackdropClicked");

            OnBackdropClick?.Invoke();

            if (!DisableBackdropClick)
            {
                OnClose?.Invoke(ModalCloseReason.BackdropClick);
            }
        }

        protected void HandleEnter(IReference reference, bool appear)
        {
            System.Console.WriteLine("HandleEnter");

            Exited = false;

            // StateHasChanged();
        }

        protected void HandleExited(IReference reference)
        {
            System.Console.WriteLine("HandleExited");

            Exited = true;

            // StateHasChanged();

            if (CloseAfterTransition)
            {
                HandleClose();
            }
        }

        protected void HandleMounted()
        {
            // mount to manager
        }

        protected void HandleOpen()
        {
            // add to manager
        }

        protected void HandleClose()
        {
            // remove from manager
        }

        protected override void Dispose()
        {
            base.Dispose();

            HandleClose();
        }

        protected override async Task OnAfterRenderAsync()
        {
            await base.OnAfterRenderAsync();

            if (Open)
            {
                HandleOpen();
            }
            else if (!HasTransition || !CloseAfterTransition)
            {
                HandleClose();
            }
        }

        protected override void HandleKeyDown(KeyboardEventArgs keyboardEvent)
        {
            if (keyboardEvent.Key == "Escape" && IsTopModal)
            {
                OnEscapeKeyDown?.Invoke();

                if (!DisableEscapeKeyDown)
                {
                    OnClose?.Invoke(ModalCloseReason.Escape);
                }
            }
        }
    }
}
