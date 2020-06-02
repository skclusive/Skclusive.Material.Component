using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
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
        public bool KeepMounted { get; set; } = false;

        [Parameter]
        public IReference Container { get; set; }

        [Parameter]
        public PopperPlacement Placement { get; set; }

        [Parameter]
        public bool Transition { get; set; }

        [Parameter]
        public PopperOptions PopperOptions { get; set; } = new PopperOptions();

        public PopperInstance PopperInstance { get; private set; }
        private bool _exited = true;

        public Popper() : base("Popper")
        {
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            if (PopperInstance != null)
            {
                var newAnchorRef = parameters.GetValueOrDefault<IReference>(nameof(AnchorRef));
                if (newAnchorRef?.Current?.Id != AnchorRef?.Current?.Id)
                {
                    await DestroyPopper(PopperInstance.Id);
                    PopperInstance = null;
                }
            }

            await base.SetParametersAsync(parameters);
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
                InitializeOptions();
                PopperInstance = await CreatePopper(AnchorRef?.Current ?? RootRef.Current.Value, RootRef.Current.Value, PopperOptions);
            }

            if (PopperInstance != null)
            {
                await UpdatePopper(PopperInstance.Id);
            }
        }

        private void InitializeOptions()
        {
            if (PopperOptions == null)
            {
                PopperOptions = new PopperOptions();
            }

            PopperOptions.Placement = Placement.MapToString();
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

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                yield return Tuple.Create<string, object>("position", "fixed");
                yield return Tuple.Create<string, object>("top", "0");
                yield return Tuple.Create<string, object>("left", "0");
                if (!Open && KeepMounted && !Transition)
                {
                    yield return Tuple.Create<string, object>("display", "none");
                }
            }
        }

        protected override void Dispose()
        {
            if (PopperInstance != null)
            {
                DestroyPopper(PopperInstance.Id);
            }

            base.Dispose();
        }

        public void HandleTransitionExited()
        {
            _exited = true;
            Open = false;
            StateHasChanged();
        }

        public void HandleTransitionEntered()
        {
            _exited = false;
            StateHasChanged();
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
