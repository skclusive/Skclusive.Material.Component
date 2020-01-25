using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Skclusive.Material.Script
{
    public class RadioGroupHelper
    {
        public RadioGroupHelper(IJSRuntime jsruntime)
        {
            JSRuntime = jsruntime;
        }

        private IJSRuntime JSRuntime { get; }

        public async Task FocusAsync(ElementReference? nodeRef)
        {
            if (nodeRef.HasValue)
            {
                await JSRuntime.InvokeVoidAsync("Skclusive.Material.Script.focusRadioGroup", nodeRef);
            }
        }
    }
}