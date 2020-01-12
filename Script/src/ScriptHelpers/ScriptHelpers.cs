using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class ScriptHelpers
    {
        private IJSRuntime JSRuntime { get; }

        public ScriptHelpers(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        public async Task GoBackAsync()
        {
            await JSRuntime.InvokeVoidAsync("Skclusive.Material.Script.goBack", -1);
        }
    }
}
