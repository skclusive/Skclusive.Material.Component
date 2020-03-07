using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skclusive.Material.Modal
{
    public class ModalComponent : MaterialComponentBase
    {
        public ModalComponent() : base("Modal")
        {
        }

        /// <summary>
        /// A backdrop component. This prop enables custom backdrop rendering.
        /// </summary>
        [Parameter]
        public RenderFragment<IModalContext> BackdropContent { set; get; }

        /// <summary>
        /// A single child content element.
        /// </summary>
        [Parameter]
        public RenderFragment<IModalContext> ChildContent { get; set; }

        /// <summary>
        /// Reference attached to the child element of the modal.
        /// </summary>
        [Parameter]
        public IReference ChildRef { get; set; } = new Reference();

        /// <summary>
        /// Disable the portal behavior.
        /// The children stay within it's parent DOM hierarchy.
        /// </summary>
        [Parameter]
        public bool DisablePortal { get; set; } = false;

        /// <summary>
        /// Reference attached to the portal target.
        /// </summary>
        [Parameter]
        public IReference PortalTargetRef { get; set; }

        /// <summary>
        /// Reference attached to the portal target body.
        /// </summary>
        [Parameter]
        public IReference PortalTargetBodyRef { get; set; }

        /// <summary>
        /// If <c>true</c>, the modal is open.
        /// </summary>
        [Parameter]
        public bool Open { set; get; }

        /// <summary>
        /// If <c>true</c>, positions the modal absolute to tha relative parent.
        /// </summary>
        [Parameter]
        public bool Absolute { set; get; }

        /// <summary>
        /// When set to true the Modal waits until a nested Transition is completed before closing.
        /// </summary>
        [Parameter]
        public bool CloseAfterTransition { set; get; }

        /// <summary>
        /// If <c>true</c>, the modal will not automatically shift focus to itself when it opens, and
        /// replace it to the last focused element when it closes.
        /// This also works correctly with any modal children that have the <c>DisableAutoFocus</c> prop.
        ///
        /// Generally this should never be set to <c>true</c> as it makes the modal less
        /// accessible to assistive technologies, like screen readers.
        /// </summary>
        [Parameter]
        public bool DisableAutoFocus { set; get; }

        /// <summary>
        /// If <c>true</c>, clicking the backdrop will not fire any callback.
        /// </summary>
        [Parameter]
        public bool DisableBackdropClick { set; get; }

        /// <summary>
        /// If <c>true</c>, the modal will not prevent focus from leaving the modal while open.
        ///
        /// Generally this should never be set to <c>true</c> as it makes the modal less
        /// accessible to assistive technologies, like screen readers.
        /// </summary>
        [Parameter]
        public bool DisableEnforceFocus { set; get; }

        /// <summary>
        /// If <c>true</c>, hitting escape will not fire any callback.
        /// </summary>
        [Parameter]
        public bool DisableEscapeKeyDown { set; get; }

        /// <summary>
        /// If <c>true</c>, the modal will not restore focus to previously focused element once
        /// modal is hidden.
        /// </summary>
        [Parameter]
        public bool DisableRestoreFocus { set; get; }

        /// <summary>
        /// Disable the scroll lock behavior.
        /// </summary>
        [Parameter]
        public bool DisableScrollLock { set; get; }

        /// <summary>
        /// If <c>true</c>, the backdrop is not rendered.
        /// </summary>
        [Parameter]
        public bool HideBackdrop { set; get; }

        /// <summary>
        /// Always keep the children in the DOM.
        /// This prop can be useful in SEO situation or
        /// when you want to maximize the responsiveness of the Modal.
        /// </summary>
        [Parameter]
        public bool KeepMounted { set; get; }

        /// <summary>
        /// If <c>true</c>, the backdrop is invisible.
        /// It can be used when rendering a popover or a custom select component.
        /// </summary>
        [Parameter]
        public bool BackdropInvisible { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Backdrop</c> element.
        /// </summary>
        [Parameter]
        public string BackdropClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Backdrop</c> element.
        /// </summary>
        [Parameter]
        public string BackdropStyle { set; get; }

        /// <summary>
        /// Callback fired when the backdrop is clicked.
        /// </summary>
        [Parameter]
        public Action OnBackdropClick { set; get; }

        /// <summary>
        /// Callback fired when the component requests to be closed.
        /// The <c>reason</c> parameter can optionally be used to control the response to <c>onClose</c>.
        /// </summary>
        [Parameter]
        public Action<ModalCloseReason> OnClose { set; get; }

        /// <summary>
        /// Callback fired when the escape key is pressed,
        /// <c>DisableEscapeKeyDown</c> is false and the modal is in focus.
        /// </summary>
        [Parameter]
        public Action OnEscapeKeyDown { set; get; }

        /// <summary>
        /// Callback fired once the children has been mounted into the `container`.
        /// It signals that the <c>Open="true"</c> prop took effect.
        /// </summary>
        [Parameter]
        public Action OnRendered { set; get; }

        /// <summary>
        /// If ChildContent has transition.
        /// </summary>
        [Parameter]
        public bool HasTransition { set; get; }

        protected bool Exited { set; get; } = true;

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("position", Absolute ? "absolute" : "fixed");

                yield return Tuple.Create<string, object>("z-index", "10000");

                yield return Tuple.Create<string, object>("right", "0");

                yield return Tuple.Create<string, object>("bottom", "0");

                yield return Tuple.Create<string, object>("top", "0");

                yield return Tuple.Create<string, object>("left", "0");

                if (!Open)
                yield return Tuple.Create<string, object>("visibility", "hidden");
            }
        }

        protected virtual string _BackdropStyle
        {
            get => CssUtil.ToStyle(BackdropStyles, BackdropStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> BackdropStyles
        {
            get
            {
                if (Absolute)
                    yield return Tuple.Create<string, object>("position", "absolute");
            }
        }

        protected virtual string _BackdropClass
        {
            get => CssUtil.ToClass($"{Selector}-Backdrop", BackdropClasses, BackdropClass);
        }

        protected virtual IEnumerable<string> BackdropClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        private ModalContextBuilder ModalContextBuilder => new ModalContextBuilder().WithRefBack(ChildRef)
                .WithOpen(Open)
                .WithBackdropInvisible(BackdropInvisible)
                .WithBackdropClass(_BackdropClass)
                .WithBackdropStyle(_BackdropStyle)
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
            OnBackdropClick?.Invoke();

            if (!DisableBackdropClick)
            {
                OnClose?.Invoke(ModalCloseReason.BackdropClick);
            }
        }

        protected void HandleEnter(IReference reference, bool appear)
        {
            Exited = false;

            // StateHasChanged();
        }

        protected void HandleExited(IReference reference)
        {
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
