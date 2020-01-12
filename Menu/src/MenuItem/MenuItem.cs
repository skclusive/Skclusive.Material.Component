using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Material.Core;

namespace Skclusive.Material.Menu
{
    public class MenuItemComponent : MaterialComponent
    {
        public MenuItemComponent() : base("MenuItem")
        {
        }

        [CascadingParameter]
        public IMenuContext MenuContext { set; get; }

        [Parameter]
        public string Component { set; get; }

        [Parameter]
        public bool DisableGutters { set; get; }

        [Parameter]
        public bool Selected { set; get; }

        [Parameter]
        public bool Enter { set; get; } = true;

        protected IReference ContentRef => Selected ? new DelegateReference(RootRef, MenuContext.ContentAnchorRef) : RootRef;

        protected int Index { set; get; }

        protected bool _AutoFocus => Index == MenuContext.ActiveIndex && MenuContext.AutoFocusItem;

        protected int? _TabIndex
        {
            get
            {
                var index = Index == MenuContext.ActiveIndex && MenuContext.Variant == MenuVariant.SelectedMenu && !TabIndex.HasValue ? 0 : TabIndex;

                return Disabled.HasValue && Disabled.Value ? null : (index.HasValue ? index : -1);
            }
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Selected)
                    yield return nameof(Selected);

                if (!DisableGutters)
                    yield return "Gutters";
            }
        }

        protected override void OnInitialized()
        {
            Index = MenuContext.CreateIndex();

            if (!Disabled.HasValue || !Disabled.Value)
            {
                if (MenuContext.Variant == MenuVariant.SelectedMenu && Selected)
                {
                    MenuContext.MarkActiveIndex(Index);
                }
                else if (MenuContext.ActiveIndex == -1)
                {
                    MenuContext.MarkActiveIndex(Index);
                }
            }
        }

        protected override async Task HandleKeyDownAsync(KeyboardEventArgs args)
        {
            await base.HandleKeyDownAsync(args);

            if (Enter && args.Key == "Enter")
            {
                await OnClick.InvokeAsync(args);
            }
        }
    }
}
