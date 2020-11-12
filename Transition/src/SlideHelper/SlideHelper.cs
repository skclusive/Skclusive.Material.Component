using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Material.Transition
{
    public class SlideHelper
    {
        private IScriptService ScriptService { get; }

        public SlideHelper(IScriptService scriptService)
        {
            ScriptService = scriptService;
        }

        public async Task<string> GetSlideTranslateValueAsync(Placement placement, ElementReference? element)
        {
            if (element.HasValue)
            {
                return await ScriptService.InvokeAsync<string>("Skclusive.Material.Transition.getSlideTranslateValue", placement.ToString().ToLowerInvariant(), element);
            }

            return null;
        }

        public async Task SetSlideTranslateValueAsync(Placement placement, ElementReference? element)
        {
            if (element.HasValue)
            {
                await ScriptService.InvokeVoidAsync("Skclusive.Material.Transition.setSlideTranslateValue", placement.ToString().ToLowerInvariant(), element);
            }
        }
    }
}
