using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class MenuListHelper
    {
        public MenuListHelper(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private object Id;

        private IJSRuntime JSRuntime { get; }

        public async Task RegisterAsync(ElementReference? list, bool disableListWrap)
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.registerMenuList", list, disableListWrap);
        }

        public async Task UnRegisterAsync()
        {
            Id = await JSRuntime.InvokeAsync<object>("Skclusive.Material.Script.unRegisterMenuList", Id);
        }

        public void Dispose()
        {
            _ = UnRegisterAsync();
        }
    }
}