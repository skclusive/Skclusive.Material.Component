using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class HistoryBackHelper
    {
        public HistoryBackHelper(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public async Task RegisterAsync(ElementReference reference, string name, int delay = 0)
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.registerHistoryBack", reference, name, delay);
        }

        public async Task UnRegisterAsync()
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.unRegisterHistoryBack", Id);
        }

        public void Dispose()
        {
            _ = UnRegisterAsync();
        }
    }
}