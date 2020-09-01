using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Modal
{
    public class TrapFocusHelper : IAsyncDisposable
    {
        public TrapFocusHelper(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public async ValueTask InitAsync(ElementReference? reference, bool disableAutoFocus, bool disableRestoreFocus, bool disableEnforceFocus, bool isEnabled)
        {
            if (!reference.HasValue) return;

            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Modal.TrapFocusHelper.construct", reference, disableAutoFocus, disableRestoreFocus, disableEnforceFocus, isEnabled);
        }

        public ValueTask DisposeAsync()
        {
            return JSRuntime.InvokeVoidAsync("Skclusive.Material.Modal.TrapFocusHelper.dispose", Id);
        }
    }
}