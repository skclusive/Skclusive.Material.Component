using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Selection
{
    public class RadioGroupHelper : IAsyncDisposable
    #if NETSTANDARD2_0
        , IDisposable
    #endif
    {
        public RadioGroupHelper(IScriptService scriptService)
        {
            ScriptService = scriptService;
        }

        private IScriptService ScriptService { get; }

        public async ValueTask FocusAsync(ElementReference? nodeRef)
        {
            if (nodeRef.HasValue)
            {
                await ScriptService.InvokeVoidAsync("Skclusive.Material.Selection.focusRadioGroup", nodeRef);
            }
        }

        public ValueTask DisposeAsync()
        {
            return default;
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