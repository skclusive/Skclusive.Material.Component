using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Script;

namespace Skclusive.Material.Modal
{
    public class TrapFocusComponent : MaterialContextComponent
    {
        [Inject]
        public TrapFocusHelper TrapFocusHelper { set; get; }

        public TrapFocusComponent() : base("TrapFocus")
        {
        }

        [Parameter]
        public bool Open { set; get; }

        [Parameter]
        public bool IsEnabled { set; get; }

        [Parameter]
        public bool DisableAutoFocus { set; get; }

        [Parameter]
        public bool DisableEnforceFocus { set; get; }

        [Parameter]
        public bool DisableRestoreFocus { set; get; }

        protected IReference SentinelStart { set; get; } = new Reference();

        protected IReference SentinelEnd { set; get; } = new Reference();

        protected override async Task OnAfterRenderAsync()
        {
            await base.OnAfterRenderAsync();

            await TrapFocusHelper.DisposeAsync();

            if (Open)
            {
                await TrapFocusHelper.InitAsync(ChildRef.Current, DisableAutoFocus, DisableRestoreFocus, DisableEnforceFocus, IsEnabled);
            }
        }
    }
}
