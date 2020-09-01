using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class HistoryBackHelper : IAsyncDisposable
    {
        public HistoryBackHelper(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public async ValueTask InitAsync(ElementReference reference, string name, int delay = 0)
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.HistoryBackHelper.construct", reference, name, delay);
        }

        public ValueTask DisposeAsync()
        {
            return JSRuntime.InvokeVoidAsync("Skclusive.Material.Script.HistoryBackHelper.dispose", Id);
        }
    }
}