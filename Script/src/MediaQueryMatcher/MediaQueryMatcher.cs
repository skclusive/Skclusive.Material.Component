using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class MediaQueryMatcher : IAsyncDisposable
    {
        public MediaQueryMatcher(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public event EventHandler<bool> OnChange;

        private readonly static EventArgs EVENT_ARGS = new EventArgs();

        [JSInvokable]
        public ValueTask OnChangeAsync(bool match)
        {
            OnChange?.Invoke(EVENT_ARGS, match);

            return default;
        }

        public async ValueTask InitAsync(string media)
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.registerMediaQuery", media, DotNetObjectReference.Create(this));
        }

        public ValueTask DisposeAsync()
        {
            OnChange = null;

            return JSRuntime.InvokeVoidAsync("Skclusive.Material.Script.unRegisterMediaQuery", Id);
        }
    }
}