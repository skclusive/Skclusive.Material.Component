using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Menu
{
    public enum MenuCloseReason
    {
        BackdropClick,

        Escape,

        TabKeyDown
    }

    public class MenuComponent : MaterialComponent
    {
        public MenuComponent() : base("Menu")
        {
        }

        [Parameter]
        public bool Open { set; get; }

        [Parameter]
        public bool AutoFocus { set; get; } = true;

        [Parameter]
        public bool DisableListWrap { set; get; } = false;

        [Parameter]
        public bool DisableAutoFocusItem { set; get; } = false;

        [Parameter]
        public Action<MenuCloseReason> OnClose { set; get; }

        [Parameter]
        public int? TransitionDuration { set; get; }

        [Parameter]
        public int? AppearTimeout { set; get; }

        [Parameter]
        public int? EnterTimeout { set; get; }

        [Parameter]
        public int? ExitTimeout { set; get; }

        [Parameter]
        public bool MountOnEnter { set; get; } = true;

        [Parameter]
        public bool UnmountOnExit { set; get; } = true;


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
        public MenuVariant Variant { set; get; } = MenuVariant.SelectedMenu;

        [Parameter]
        public IReference AnchorRef { get; set; } = new Reference();

        [Parameter]
        public IReference ListRef { get; set; } = new Reference();

        [Parameter]
        public string ListClass { set; get; }

        [Parameter]
        public string ListStyle { set; get; }

        protected IReference ContentAnchorRef { get; set; } = new Reference();

        protected bool AutoFocusItem => AutoFocus && !DisableAutoFocusItem && Open;

        protected bool ListAutoFocus => AutoFocus && DisableAutoFocusItem;

        protected virtual string _ListStyle
        {
            get => CssUtil.ToStyle(ListStyles, ListStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ListStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ListClass
        {
            get => CssUtil.ToClass($"{Selector}-List", ListClasses, ListClass);
        }

        protected virtual IEnumerable<string> ListClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected void HandleEnter(IReference refback, bool appearing)
        {
            OnEnter?.Invoke(refback, appearing);
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

        protected void HandleExited(IReference refback)
        {
            OnExited?.Invoke(refback);
        }

        protected override void HandleKeyDown(KeyboardEventArgs keyboardEvent)
        {
            if (keyboardEvent.Key == "Tab")
            {
                OnClose?.Invoke(MenuCloseReason.TabKeyDown);
            }
        }

        protected void HandleClose()
        {
            OnClose?.Invoke(MenuCloseReason.Escape);
        }
    }
}
