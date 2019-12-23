using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class TrapFocusHelper
    {
        public TrapFocusHelper(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public async Task InitAsync(ElementReference? reference, bool disableAutoFocus, bool disableRestoreFocus, bool disableEnforceFocus, bool isEnabled)
        {
            if (!reference.HasValue) return;

            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.initTrapFocus", reference, disableAutoFocus, disableRestoreFocus, disableEnforceFocus, isEnabled);
        }

        public async Task DisposeAsync()
        {
            if (Id == null) return;

            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.disposeTrapFocus", Id);

            Id = null;
        }

        public void Dispose()
        {
            _ = DisposeAsync();
        }
    }
}