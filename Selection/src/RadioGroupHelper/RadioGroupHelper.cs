using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Selection
{
    public class RadioGroupHelper : IAsyncDisposable
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
    }
}