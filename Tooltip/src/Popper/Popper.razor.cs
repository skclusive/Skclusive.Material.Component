using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Skclusive.Core.Component;

namespace Skclusive.Material.Tooltip
{
    public partial class Popper
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public IReference AnchorRef { get; set; } = new Reference();

        [Parameter]
        public bool DisablePortal { get; set; } = false;

        [Parameter]
        public bool Open { get; set; } = false;

        [Parameter]
        public bool KeepMounted { get; set; } = true;

        [Parameter]
        public IReference Container { get; set; }

        [Parameter]
        public PopperOptions PopperOptions { get; set; } = new PopperOptions();

        protected PopperInstance PopperInstance;

        public Popper() : base("Popper")
        {
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (!KeepMounted && !Open && PopperInstance != null)
            {
                await DestroyPopper(PopperInstance.Id);
                PopperInstance = null;
            }

            if (Open && PopperInstance == null)
            {
                PopperInstance = await CreatePopper(AnchorRef?.Current ?? RootRef.Current.Value, RootRef.Current.Value, PopperOptions);
            }

            if (PopperInstance != null)
            {
                await UpdatePopper(PopperInstance.Id);
            }
        }

        private async Task<PopperInstance> CreatePopper(ElementReference reference, ElementReference popper, PopperOptions options)
        {
            var obj = await JsRuntime.InvokeAsync<PopperInstance>("Skclusive.Material.Tooltip.createBlazorPopper", reference, popper, options);
            return obj;
        }

        private ValueTask UpdatePopper(int id)
        {
            return JsRuntime.InvokeVoidAsync("Skclusive.Material.Tooltip.updatePopper", id);
        }

        private ValueTask DestroyPopper(int id)
        {
            return JsRuntime.InvokeVoidAsync("Skclusive.Material.Tooltip.destroyPopper", id);
        }

        private string GetPopperStyle()
        {
            return $"position: fixed; top: 0; left: 0;{(!Open && KeepMounted ? "display: none" : "")}";
        }

        protected override void Dispose()
        {
            if (PopperInstance != null)
            {
                DestroyPopper(PopperInstance.Id);
            }

            base.Dispose();
        }

        // TODO in .NET 5
        // https://github.com/dotnet/aspnetcore/issues/9960
        //public ValueTask DisposeAsync()
        //{
        //    if (PopperInstance != null)
        //    {
        //        return DestroyPopper(PopperInstance.Id);
        //    }

        //    return default;
        //}
    }
}
