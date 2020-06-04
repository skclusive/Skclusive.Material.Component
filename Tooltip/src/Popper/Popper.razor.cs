using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NLog;
using Skclusive.Core.Component;
using Skclusive.Transition.Component;

namespace Skclusive.Material.Tooltip
{
    public partial class Popper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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

        [CascadingParameter]
        public ITransitionContext TransitionContext { get; set; }

        public PopperInstance PopperInstance { get; private set; }

        public Popper() : base("Popper")
        {
        }

        private bool TransitionExited()
        {
            if (TransitionContext == null)
            {
                return false;
            }

            return TransitionContext.State == TransitionState.Exited;
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

        protected override void OnParametersSet()
        {
            if (TransitionContext != null)
            {
                TransitionContext.RefBack.Current = RootRef.Current;
            }
        }

        protected override async Task OnAfterRenderAsync()
        {
            Logger.Info($"Popper:Render {TransitionContext?.State}");

            if (!KeepMounted && !Open && PopperInstance != null && TransitionExited())
            {
                await HandleClose();
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

        private async Task HandleClose()
        {
            Logger.Info($"Popper:handleClose {TransitionExited()}");
            await DestroyPopper(PopperInstance.Id);
            PopperInstance = null;
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
