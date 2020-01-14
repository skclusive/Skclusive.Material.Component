using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class MediaQueryMatcher
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
        public Task OnChangeAsync(bool match)
        {
            OnChange?.Invoke(EVENT_ARGS, match);

            return Task.CompletedTask;
        }

        public async Task RegisterAsync(string media)
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.registerMediaQuery", media, DotNetObjectReference.Create(this));
        }

        public async Task UnRegisterAsync()
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.unRegisterMediaQuery", Id);
        }

        public void Dispose()
        {
            _ = UnRegisterAsync();
        }
    }
}