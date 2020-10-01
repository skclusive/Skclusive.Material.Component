using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Script
{
    public class HistoryBackHelper : IAsyncDisposable
    {
        public HistoryBackHelper(IScriptService scriptService)
        {
            ScriptService = scriptService;
        }

        private object Id;

        private IScriptService ScriptService { get; }

        public async ValueTask InitAsync(ElementReference reference, string name, int delay = 0)
        {
            Id = await ScriptService.InvokeAsync<object>("Skclusive.Material.Script.HistoryBackHelper.construct", reference, name, delay);
        }

        public async ValueTask DisposeAsync()
        {
            if (Id != null)
            {
                await ScriptService.InvokeVoidAsync("Skclusive.Material.Script.HistoryBackHelper.dispose", Id);
            }
        }
    }
}