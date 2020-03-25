using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Menu
{
    public class MenuComponent : MaterialComponent
    {
        public MenuComponent() : base("Menu")
        {
        }

        /// <summary>
        /// Disable the portal behavior.
        /// The children stay within it's parent DOM hierarchy.
        /// </summary>
        [Parameter]
        public bool DisablePortal { get; set; } = false;

        /// <summary>
        /// If <c>true</c>, the menu is visible.
        /// </summary>
        [Parameter]
        public bool Open { set; get; }

        /// <summary>
        /// If `true` (Default) will focus the `[role="menu"]` if no focusable child is found. Disabled
        /// children are not focusable. If you set this prop to `false` focus will be placed
        /// on the parent modal container. This has severe accessibility implications
        /// and should only be considered if you manage focus otherwise.
        /// </summary>
        [Parameter]
        public bool AutoFocus { set; get; } = true;

        /// <summary>
        /// The elevation of the Menu.
        /// </summary>
        [Parameter]
        public int Elevation { set; get; } = 8;

        /// <summary>
        /// If <c>true</c>, the menu items will not wrap focus.
        /// </summary>
        [Parameter]
        public bool DisableListWrap { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, compact vertical padding designed for keyboard and mouse input will be used for
        /// the list and list items.
        /// The prop is available to descendant components as the <c>dense</c> context.
        /// </summary>
        [Parameter]
        public bool Dense { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, vertical padding will be removed from the list.
        /// </summary>
        [Parameter]
        public bool DisablePadding { set; get; } = false;

        /// <summary>
        /// When opening the menu will not focus the active item but the <c>[role="menu"]</c>
        /// unless <c>AutoFocus</c> is also set to `false`. Not using the default means not
        /// following WAI-ARIA authoring practices. Please be considerate about possible
        /// accessibility implications.
        /// </summary>
        [Parameter]
        public bool DisableAutoFocusItem { set; get; } = false;

        /// <summary>
        /// Callback fired when the component requests to be closed.
        /// </summary>
        [Parameter]
        public Action<MenuCloseReason> OnClose { set; get; }

        /// <summary>
        /// menu transition duration.
        /// </summary>
        [Parameter]
        public int? TransitionDuration { set; get; }

        /// <summary>
        /// menu appear timeout.
        /// </summary>
        [Parameter]
        public int? AppearTimeout { set; get; }

        /// <summary>
        /// menu enter timeout.
        /// </summary>
        [Parameter]
        public int? EnterTimeout { set; get; }

        /// <summary>
        /// menu exit timeout.
        /// </summary>
        [Parameter]
        public int? ExitTimeout { set; get; }

        /// <summary>
        /// By default the child component is mounted immediately along with
        /// the parent <c>Transition</c> component. If you want to "lazy mount" the component on the
        /// first <c>In="true"</c> you can set <c>MountOnEnter</c>. After the first enter transition the component will stay
        /// mounted, even on "exited", unless you also specify <c>UnmountOnExit</c>.
        /// </summary>
        [Parameter]
        public bool MountOnEnter { set; get; } = true;

        /// <summary>
        /// By default the child component stays mounted after it reaches the <c>'exited'</c> state.
        /// Set <c>UnmountOnExit</c> if you'd prefer to unmount the component after it finishes exiting.
        /// </summary>
        [Parameter]
        public bool UnmountOnExit { set; get; } = true;

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
        /// This is the horizontal point on the anchor where the popover's
        /// <c>AnchorRef</c> will attach to. This is not used when the
        /// anchorReference is 'anchorPosition'.
        /// </summary>
        [Parameter]
        public HorizontalOrigin AnchorHorizontalOrigin { set; get; } = HorizontalOrigin.Left;

        /// <summary>
        /// This is the vertical point on the anchor where the popover's
        /// <c>AnchorRef</c> will attach to. This is not used when the
        /// anchorReference is 'anchorPosition'.
        /// </summary>
        [Parameter]
        public VerticalOrigin AnchorVerticalOrigin { set; get; } = VerticalOrigin.Top;

        /// <summary>
        /// This is the point on the popover which will attach to the anchor's horizontal origin.
        /// </summary>
        [Parameter]
        public HorizontalOrigin TransformHorizontalOrigin { set; get; } = HorizontalOrigin.Left;

        /// <summary>
        /// This is the point on the popover which will attach to the anchor's vertical origin.
        /// </summary>
        [Parameter]
        public VerticalOrigin TransformVerticalOrigin { set; get; } = VerticalOrigin.Top;

        /// <summary>
        /// Callback fired before the Menu enters.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEnter { set; get; }

        /// <summary>
        /// Callback fired when the Menu is entering.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEntering { set; get; }

        /// <summary>
        /// Callback fired when the Menu has entered.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEntered { set; get; }

        /// <summary>
        /// Callback fired before the Menu exits.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExit { set; get; }

        /// <summary>
        /// Callback fired when the Menu is exiting.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExiting { set; get; }

        /// <summary>
        /// Callback fired when the Menu has exited.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExited { set; get; }

        [Parameter]
        public MenuVariant Variant { set; get; } = MenuVariant.SelectedMenu;

        [Parameter]
        public IReference AnchorRef { get; set; } = new Reference("AnchorRef");

        [Parameter]
        public IReference ListRef { get; set; } = new Reference("ListRef");

        [Parameter]
        public string ListClass { set; get; }

        [Parameter]
        public string ListStyle { set; get; }

        protected IReference ContentAnchorRef { get; set; } = new Reference("ContentAnchorRef");

        protected bool AutoFocusItem => AutoFocus && !DisableAutoFocusItem && Open;

        protected bool ListAutoFocus => AutoFocus && DisableAutoFocusItem;

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
            }
        }

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
