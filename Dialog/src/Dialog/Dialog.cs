using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;

namespace Skclusive.Material.Dialog
{
    public enum DialogScroll
    {
        Paper,

        Body
    }

    public enum DialogWidth
    {
        ExtraSmall,

        Small,

        Medium,

        Large,

        ExtraLarge,

        False
    }

    public class DialogComponent : MaterialComponent
    {
        public DialogComponent() : base("Dialog")
        {
        }

        [Parameter]
        public IReference ContainerRef { set; get; } = new Reference();

        [Parameter]
        public int? TransitionDuration { set; get; }

        [Parameter]
        public int? AppearTimeout { set; get; }

        [Parameter]
        public int? EnterTimeout { set; get; }

        [Parameter]
        public int? ExitTimeout { set; get; }

        [Parameter]
        public bool Open { set; get; }

        [Parameter]
        public bool BackdropInvisible { set; get; }

        [Parameter]
        public bool DisableBackdropClick { set; get; }

        [Parameter]
        public bool DisableEscapeKeyDown { set; get; }

        [Parameter]
        public bool FullScreen { set; get; }

        [Parameter]
        public bool FullWidth { set; get; }

        [Parameter]
        public DialogWidth MaxWidth { set; get; }

        [Parameter]
        public Action OnBackdropClick { set; get; }

        [Parameter]
        public Action OnEscapeKeyDown { set; get; }

        [Parameter]
        public DialogScroll Scroll { set; get; } = DialogScroll.Paper;

        [Parameter]
        public Action<IReference, bool> OnEnter { set; get; }

        [Parameter]
        public Action<IReference, bool> OnEntering { set; get; }

        [Parameter]
        public Action<IReference, bool> OnEntered { set; get; }

        [Parameter]
        public Action<IReference> OnExit { set; get; }

        [Parameter]
        public Action<IReference> OnExiting { set; get; }

        [Parameter]
        public Action<IReference> OnExited { set; get; }

        [Parameter]
        public Action OnClose { set; get; }

        [Parameter]
        public string ContainerClass { set; get; }

        [Parameter]
        public string ContainerStyle { set; get; }

        [Parameter]
        public string PaperClass { set; get; }

        [Parameter]
        public string PaperStyle { set; get; }

        [Parameter]
        public int Elevation { set; get; } = 24;

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
            get => Enumerable.Empty<Tuple<string, object>>();
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
