using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class EventDelegator : IAsyncDisposable
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
        public ValueTask OnEventAsync(string json)
        {
            OnEvent?.Invoke(EVENT_ARGS, json);

            return default;
        }

        public async ValueTask InitAsync(ElementReference reference, string name, int delay)
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.registerEvent", reference, name, DotNetObjectReference.Create(this), delay);
        }

        public ValueTask DisposeAsync()
        {
            OnEvent = null;

            return JSRuntime.InvokeVoidAsync("Skclusive.Material.Script.unRegisterEvent", Id);
        }
    }
}