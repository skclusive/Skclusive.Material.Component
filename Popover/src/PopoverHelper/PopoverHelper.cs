using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Skclusive.Core.Component;
using Skclusive.Script.DomHelpers;
using System;

namespace Skclusive.Material.Popover
{
    public class PopoverHelper : IAsyncDisposable
    {
        public PopoverHelper(IJSRuntime jsruntime, DomHelpers domHelpers)
        {
            JSRuntime = jsruntime;

            DomHelpers = domHelpers;
        }

        private IJSRuntime JSRuntime { get; }

        private DomHelpers DomHelpers { get; }

        public ValueTask<double> GetContentAnchorOffsetAsync(ElementReference? contentAnchor, ElementReference? element)
        {
            return JSRuntime.InvokeAsync<double>("Skclusive.Material.Popover.getContentAnchorOffset", contentAnchor, element);
        }

        public ValueTask<Boundry> GetAnchorBoundryAsync(ElementReference? anchorRef, ElementReference? paperRef)
        {
            return JSRuntime.InvokeAsync<Boundry>("Skclusive.Material.Popover.getAnchorBoundry", anchorRef, paperRef);
        }

        public async ValueTask<Boundry> GetOffsetAsync(ElementReference? element)
        {
            var offset = await DomHelpers.GetElementOffsetAsync(element);

            return new Boundry
            {
                Width = offset.Width,

                Height = offset.Height
            };
        }

        public ValueTask<Offset> GetWindowOffsetAsync(ElementReference? element)
        {
            return DomHelpers.GetWindowOffsetAsync(element);
        }

        public ValueTask SetPositioningStylesAsync(ElementReference? element, IDictionary<string, object> styles, bool trigger = true)
        {
            return DomHelpers.SetStyleAsync(element, styles, trigger);
        }


        public ValueTask DisposeAsync()
        {
            return default;
        }
    }
}