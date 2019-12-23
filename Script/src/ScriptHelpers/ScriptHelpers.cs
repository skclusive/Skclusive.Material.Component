using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Skclusive.Core.Component;

namespace Skclusive.Material.Script
{
    public class ScriptHelpers
    {
        private IJSRuntime JSRuntime { get; }

        public ScriptHelpers(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        public async Task<string> GetTranslateValueAsync(Placement placement, ElementReference? element)
        {
            if (element.HasValue)
            {
                return await JSRuntime.InvokeAsync<string>("Skclusive.Material.Script.getTranslateValue", placement.ToString().ToLower(), element);
            }

            return null;
        }

        public async Task SetTranslateValueAsync(Placement placement, ElementReference? element)
        {
            if (element.HasValue)
            {
                await JSRuntime.InvokeVoidAsync("Skclusive.Material.Script.setTranslateValue", placement.ToString().ToLower(), element);
            }
        }

        public async Task GoBackAsync()
        {
            await JSRuntime.InvokeVoidAsync("Skclusive.Material.Script.goBack", -1);
        }
    }
}
