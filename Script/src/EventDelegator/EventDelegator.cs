using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class EventDelegator
    {
        public EventDelegator(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public event EventHandler<string> OnEvent;

        private readonly static EventArgs EVENT_ARGS = new EventArgs();

        [JSInvokable]
        public Task OnEventAsync(string json)
        {
            OnEvent?.Invoke(EVENT_ARGS, json);

            return Task.CompletedTask;
        }

        public async Task RegisterAsync(ElementReference reference, string name, int delay)
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.registerEvent", reference, name, DotNetObjectReference.Create(this), delay);
        }

        public async Task UnRegisterAsync()
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.unRegisterEvent", Id);
        }

        public void Dispose()
        {
            _ = UnRegisterAsync();
        }
    }
}