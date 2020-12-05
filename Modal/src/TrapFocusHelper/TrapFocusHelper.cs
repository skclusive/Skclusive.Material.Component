using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Modal
{
    public class TrapFocusHelper : IAsyncDisposable
    #if NETSTANDARD2_0
        , IDisposable
    #endif
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

#if NETSTANDARD2_0

        void IDisposable.Dispose()
        {
            if (this is IAsyncDisposable disposable)
            {
                _ = disposable.DisposeAsync();
            }
        }

#endif
    }
}