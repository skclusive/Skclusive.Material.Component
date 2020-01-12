using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Skclusive.Core.Component;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Script
{
    public class PopoverHelper
    {
        public PopoverHelper(IJSRuntime jsruntime, DomHelpers domHelpers)
        {
            JSRuntime = jsruntime;

            DomHelpers = domHelpers;
        }

        private IJSRuntime JSRuntime { get; }

        private DomHelpers DomHelpers { get; }

        public async Task<double> GetContentAnchorOffsetAsync(ElementReference? contentAnchor, ElementReference? element)
        {
            return await JSRuntime.InvokeAsync<double>("Skclusive.Material.Script.getContentAnchorOffset", contentAnchor, element);
        }

        public async Task<Boundry> GetAnchorBoundryAsync(ElementReference? anchorRef, ElementReference? paperRef)
        {
            return await JSRuntime.InvokeAsync<Boundry>("Skclusive.Material.Script.getAnchorBoundry", anchorRef, paperRef);
        }

        public async Task<Boundry> GetOffsetAsync(ElementReference? element)
        {
            var offset = await DomHelpers.GetElementOffsetAsync(element);

            return new Boundry
            {
                Width = offset.Width,

                Height = offset.Height
            };
        }

        public Task<Offset> GetWindowOffsetAsync(ElementReference? element)
        {
            return DomHelpers.GetWindowOffsetAsync(element);
        }

        public Task SetPositioningStylesAsync(ElementReference? element, IDictionary<string, object> styles, bool trigger = true)
        {
            return DomHelpers.SetStyleAsync(element, styles, trigger);
        }
    }
}