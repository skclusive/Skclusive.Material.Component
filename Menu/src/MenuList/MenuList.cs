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

        [Parameter]
        public bool Open { set; get; } = true;

        [Parameter]
        public MenuVariant Variant { set; get; } = MenuVariant.SelectedMenu;

        [Parameter]
        public bool AutoFocus { set; get; } = true;

        [Parameter]
        public bool AutoFocusItem { set; get; }

        [Parameter]
        public bool DisableListWrap { set; get; } = false;

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
