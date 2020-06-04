using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Core.Component;
using Skclusive.Transition.Component;

namespace Skclusive.Material.Tooltip
{
    public partial class Tooltip
    {
        [Parameter]
        public bool Arrow { get; set; } = false;

        [Parameter]
        public PopperPlacement Placement { get; set; } = PopperPlacement.Bottom;

        [Parameter]
        public PopperOptions PopperOptions { get; set; } = null;

        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public EventCallback<bool> OnOpenChanged { get; set; }

        [Parameter]
        public RenderFragment TitleComponent { get; set; } = null;

        [Parameter]
        public bool DisableTouchListener { get; set; } = true;

        [Parameter]
        public bool DisableHoverListener { get; set; } = false;

        [Parameter]
        public bool DisableFocusListener { get; set; } = true;

        [Parameter]
        public string Title { get; set; } = "";

        [Parameter]
        public string ContainerTag { get; set; } = null;

        [Parameter]
        public string ContainerClass { get; set; } = null;

        [Parameter]
        public string ContainerStyle { get; set; } = null;

        public ITransitionContext TransitionContext { get; set; }

        private IReference _popperAnchor = new Reference();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return "Tooltip";

                yield return $"Tooltip-Placement-{Placement.MapToString().Split('-')[0]}";

                if (Arrow)
                {
                    yield return "Tooltip-Arrow";
                }
            }
        }

        public Tooltip() : base("Tooltip")
        {
        }

        private string PopperClasses()
        {
            return $"Tooltip-Popper{(Arrow ? " Tooltip-Popper-Arrow" : "")}{(_Class != null ? $" {_Class}" : "")}";
        }

        private string ArrowClasses()
        {
            // TODO
            if (Placement == PopperPlacement.Bottom || Placement == PopperPlacement.BottomStart || Placement == PopperPlacement.BottomEnd)
            {
                return "Tooltip-Arrow Tooltip-Popper-Arrow-bottom";
            }

            return $"Tooltip-Arrow";
        }

        protected override Task OnAfterMountAsync()
        {
            return base.OnAfterMountAsync();
        }

        private async Task HandleOpenChanged(bool open)
        {
            Open = open;

            if (OnOpenChanged.HasDelegate)
            {
                await OnOpenChanged.InvokeAsync(Open);
            }

            StateHasChanged();
        }

        private async Task HandleTouchStartInternal(TouchEventArgs args)
        {
            if (DisableTouchListener)
            {
                return;
            }
        }

        private async Task HandleTouchEndInternal(TouchEventArgs args)
        {
            if (DisableTouchListener)
            {
                return;
            }
        }

        private async Task HandleMouseEnterInternal(EventArgs args)
        {
            if (DisableHoverListener)
            {
                return;
            }

            await HandleOpenChanged(true);
        }

        private async Task HandleMouseLeaveInternal(EventArgs args)
        {
            if (DisableHoverListener)
            {
                return;
            }

            await HandleOpenChanged(false);
        }

        private async Task HandleFocusInternal(FocusEventArgs args)
        {
            if (DisableFocusListener)
            {
                return;
            }
        }

        private async Task HandleBlurInternal(FocusEventArgs args)
        {
            if (DisableFocusListener)
            {
                return;
            }
        }
    }
}
