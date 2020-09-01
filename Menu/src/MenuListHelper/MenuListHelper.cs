using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Menu
{
    public class MenuListHelper : IAsyncDisposable
    {
        public MenuListHelper(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public async ValueTask InitAsync(ElementReference? list, bool disableListWrap)
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Menu.MenuListHelper.construct", list, disableListWrap);
        }

        public ValueTask DisposeAsync()
        {
            return JSRuntime.InvokeVoidAsync("Skclusive.Material.Menu.MenuListHelper.construct", Id);
        }
    }
}