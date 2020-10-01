using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Menu
{
    public class MenuListHelper : IAsyncDisposable
    {
        public MenuListHelper(IScriptService scriptService)
        {
            ScriptService = scriptService;
        }

        private object Id;

        private IScriptService ScriptService { get; }

        public async ValueTask InitAsync(ElementReference? list, bool disableListWrap)
        {
            Id = await ScriptService.InvokeAsync<object>("Skclusive.Material.Menu.MenuListHelper.construct", list, disableListWrap);
        }

        public async ValueTask DisposeAsync()
        {
            if (Id != null)
            {
                await ScriptService.InvokeVoidAsync("Skclusive.Material.Menu.MenuListHelper.construct", Id);
            }
        }
    }
}