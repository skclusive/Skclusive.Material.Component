using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Skclusive.Core.Component;

namespace Skclusive.Material.Script
{
    public class DetectThemeHelper : IAsyncDisposable
    {
        public DetectThemeHelper(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public event EventHandler<Theme> OnChange;

        private static IDictionary<string, Theme> THEME_MAPPING = new Dictionary<string, Theme>
        {
            { "Dark", Theme.Dark },
            { "Light", Theme.Light },
            { "None", Theme.None }
        };

        private readonly static EventArgs EVENT_ARGS = new EventArgs();

        [JSInvokable]
        public ValueTask OnChangeAsync(string theme)
        {
            OnChange?.Invoke(EVENT_ARGS, THEME_MAPPING[theme]);

            return default;
        }

        public async ValueTask InitAsync()
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.registerDetectTheme", DotNetObjectReference.Create(this));
        }

        public ValueTask DisposeAsync()
        {
            OnChange = null;

            return JSRuntime.InvokeVoidAsync("Skclusive.Material.Script.unRegisterDetectTheme", Id);
        }
    }
}