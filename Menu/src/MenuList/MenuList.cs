using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Script;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Menu
{
    public class MenuListComponent : MaterialComponent
    {
        public MenuListComponent() : base("MenuList")
        {
        }

        /// <summary>
        /// If <c>true</c>, the menulist is visible.
        /// </summary>
        [Parameter]
        public bool Open { set; get; } = true;

        /// <summary>
        /// The <see cref="MenuVariant"> variant to use.
        /// </summary>
        [Parameter]
        public MenuVariant Variant { set; get; } = MenuVariant.SelectedMenu;

        /// <summary>
        /// If <c>true</c>, will focus the `[role="menu"]` container and move into tab order.
        /// </summary>
        [Parameter]
        public bool AutoFocus { set; get; } = true;

        /// <summary>
        /// If <c>true</c>, will focus the first menuitem if <c>variant="menu"</c> or selected item
        /// if <c>variant="selectedMenu"</c>
        /// </summary>
        [Parameter]
        public bool AutoFocusItem { set; get; }

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
        /// Reference attached to the content element of the menulist.
        /// </summary>
        [Parameter]
        public IReference ContentAnchorRef { get; set; } = new Reference();

        [Inject]
        private DomHelpers DomHelpers { get; set; }

        [Inject]
        public MenuListHelper MenuListHelper { set; get; }

        private IMenuContext _lastMenuContext = null;

        protected IMenuContext MenuContext
        {
           get
           {
               _lastMenuContext = new MenuContextBuilder()
                .WithLast(_lastMenuContext)
                .WithContentAnchorRef(ContentAnchorRef)
                .WithVariant(Variant)
                .WithAutoFocusItem(AutoFocusItem)
                .Build();
                return _lastMenuContext;
           }
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (AutoFocus && Open)
            {
                var elementRef = RootRef.Current;

                await DomHelpers.FocusAsync(elementRef);
            }
        }

        protected override async Task OnAfterMountAsync()
        {
            await base.OnAfterMountAsync();

            await MenuListHelper.RegisterAsync(RootRef.Current, DisableListWrap);
        }

        protected override void Dispose()
        {
            base.Dispose();

            MenuListHelper.Dispose();
        }
    }
}
