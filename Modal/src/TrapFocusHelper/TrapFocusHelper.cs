using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Modal
{
    public class TrapFocusHelper : IAsyncDisposable
    {
        public TrapFocusHelper(IScriptService scriptService)
        {
            ScriptService = scriptService;
        }

        private object Id;

        private IScriptService ScriptService { get; }

        public async ValueTask InitAsync(ElementReference? reference, bool disableAutoFocus, bool disableRestoreFocus, bool disableEnforceFocus, bool isEnabled)
        {
            if (!reference.HasValue) return;

            Id = await ScriptService.InvokeAsync<object>("Skclusive.Material.Modal.TrapFocusHelper.construct", reference, disableAutoFocus, disableRestoreFocus, disableEnforceFocus, isEnabled);
        }

        public async ValueTask DisposeAsync()
        {
            if (Id != null)
            {
                await ScriptService.InvokeVoidAsync("Skclusive.Material.Modal.TrapFocusHelper.dispose", Id);
            }
        }
    }
}