using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;

namespace Skclusive.Material.Dialog
{
    public class DialogComponent : MaterialComponent
    {
        public DialogComponent() : base("Dialog")
        {
        }

        /// <summary>
        /// Reference attached to the container element of the component.
        /// </summary>
        [Parameter]
        public IReference ContainerRef { set; get; } = new Reference();

        /// <summary>
        /// dialog transition duration.
        /// </summary>
        [Parameter]
        public int? TransitionDuration { set; get; }

        /// <summary>
        /// dialog appear timeout.
        /// </summary>
        [Parameter]
        public int? AppearTimeout { set; get; }

        /// <summary>
        /// dialog enter timeout.
        /// </summary>
        [Parameter]
        public int? EnterTimeout { set; get; }

        /// <summary>
        /// dialog exit timeout.
        /// </summary>
        [Parameter]
        public int? ExitTimeout { set; get; }

        /// <summary>
        /// If <c>true</c>, the Dialog is open.
        /// </summary>
        [Parameter]
        public bool Open { set; get; }

        /// <summary>
        /// If <c>true</c>, the backdrop is invisible.
        /// It can be used when rendering a popover or a custom select component.
        /// </summary>
        [Parameter]
        public bool BackdropInvisible { set; get; }

        /// <summary>
        /// If <c>true</c>, clicking the backdrop will not fire the <c>OnClose</c> callback.
        /// </summary>
        [Parameter]
        public bool DisableBackdropClick { set; get; }

        /// <summary>
        /// If <c>true</c>, hitting escape will not fire the <c>OnClose</c> callback.
        /// </summary>
        [Parameter]
        public bool DisableEscapeKeyDown { set; get; }

        /// <summary>
        /// If <c>true</c>, the dialog will be full-screen.
        /// </summary>
        [Parameter]
        public bool FullScreen { set; get; }

        /// <summary>
        /// If <c>true</c>, the dialog stretches to <c>maxWidth</c>.
        /// <remarks>
        /// Notice that the dialog width grow is limited by the default margin.
        /// </remarks>
        /// </summary>
        [Parameter]
        public bool FullWidth { set; get; }

        /// <summary>
        /// Determine the max-width of the dialog.
        /// The dialog width grows with the size of the screen.
        /// Set to <c>MaxWidth.False</c> to disable <c>MaxWidth</c>.
        /// </summary>
        [Parameter]
        public MaxWidth MaxWidth { set; get; } = MaxWidth.Small;

        /// <summary>
        /// Callback fired when the backdrop is clicked.
        /// </summary>
        [Parameter]
        public Action OnBackdropClick { set; get; }

        /// <summary>
        /// Callback fired when the escape key is pressed,
        /// <c>disableKeyboard</c> is false and the modal is in focus.
        /// </summary>
        [Parameter]
        public Action OnEscapeKeyDown { set; get; }

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
        /// If <c>true</c>, positions the dialog absolute to tha relative parent.
        /// </summary>
        [Parameter]
        public bool Absolute { set; get; }

        /// <summary>
        /// Determine the container for scrolling the dialog.
        /// </summary>
        [Parameter]
        public DialogScroll Scroll { set; get; } = DialogScroll.Paper;

        /// <summary>
        /// Transition <c>OnEnter</c> callback.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEnter { set; get; }

        /// <summary>
        /// Transition <c>OnEntering</c> callback.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEntering { set; get; }

        /// <summary>
        /// Transition <c>OnEntered</c> callback.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEntered { set; get; }

        /// <summary>
        /// Transition <c>OnExit</c> callback.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExit { set; get; }

        /// <summary>
        /// Transition <c>OnExiting</c> callback.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExiting { set; get; }

        /// <summary>
        /// Transition <c>OnExited</c> callback.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExited { set; get; }

        /// <summary>
        /// Callback fired when the dialog is getting closed.
        /// </summary>
        [Parameter]
        public Action OnClose { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Container</c> element.
        /// </summary>
        [Parameter]
        public string ContainerClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Container</c> element.
        /// </summary>
        [Parameter]
        public string ContainerStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Paper</c> element.
        /// </summary>
        [Parameter]
        public string PaperClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Paper</c> element.
        /// </summary>
        [Parameter]
        public string PaperStyle { set; get; }

        /// <summary>
        /// The elevation of the dialog.
        /// </summary>
        [Parameter]
        public int Elevation { set; get; } = 24;

        /// <summary>
        /// If <c>true</c>, rounded corners are disabled.
        /// </summary>
        [Parameter]
        public bool Square { set; get; } = true;

        public Action<IReference, bool> CreateOnEnter(Action<IReference, bool> onEnter)
        {
            return (IReference reference, bool appearing) => {
                onEnter?.Invoke(reference, appearing);
                OnEnter?.Invoke(reference, appearing);
            };
        }

        public Action<IReference> CreateOnExited(Action<IReference> onExited)
        {
            return (IReference reference) => {
                onExited?.Invoke(reference);
                OnExited?.Invoke(reference);
            };
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;
            }
        }

        protected virtual string _ContainerStyle
        {
            get => CssUtil.ToStyle(ContainerStyles, ContainerStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ContainerStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ContainerClass
        {
            get => CssUtil.ToClass($"{Selector}", ContainerClasses, ContainerClass);
        }

        protected virtual IEnumerable<string> ContainerClasses
        {
            get
            {
                yield return "Container";

                yield return $"{nameof(Scroll)}-{Scroll}";
            }
        }

        protected virtual string _PaperStyle
        {
            get => CssUtil.ToStyle(PaperStyles, PaperStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> PaperStyles
        {
            get
            {
                if (Absolute)
                    yield return Tuple.Create<string, object>("position", "relative");
            }
        }

        protected virtual string _PaperClass
        {
            get => CssUtil.ToClass($"{Selector}-Paper", PaperClasses, PaperClass);
        }

        protected virtual IEnumerable<string> PaperClasses
        {
            get
            {
                yield return string.Empty;

                yield return $"{nameof(Scroll)}-{Scroll}";

                yield return $"Width-{MaxWidth}";

                if (FullScreen)
                yield return $"{nameof(FullScreen)}";

                if (FullWidth)
                yield return $"{nameof(FullWidth)}";
            }
        }

        protected virtual string _BackdropStyle
        {
            get => CssUtil.ToStyle(BackdropStyles, BackdropStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> BackdropStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
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

        protected void HandleClose(ModalCloseReason reason)
        {
            OnClose?.Invoke();
        }

        protected void HandleEscapeKeyDown()
        {
            OnEscapeKeyDown?.Invoke();
        }

        protected void HandleEntering(IReference refback, bool appearing)
        {
            OnEntering?.Invoke(refback, appearing);
        }

        protected void HandleEntered(IReference refback, bool appeared)
        {
            OnEntered?.Invoke(refback, appeared);
        }

        protected void HandleExit(IReference refback)
        {
            OnExit?.Invoke(refback);
        }

        protected void HandleExiting(IReference refback)
        {
            OnExiting?.Invoke(refback);
        }
    }
}
