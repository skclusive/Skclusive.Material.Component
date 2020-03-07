using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Script;

namespace Skclusive.Material.Modal
{
    public class TrapFocusComponent : MaterialContextComponent
    {
        [Inject]
        public TrapFocusHelper TrapFocusHelper { set; get; }

        public TrapFocusComponent() : base("TrapFocus")
        {
        }

        /// <summary>
        /// If <c>true</c>, the modal is open.
        /// </summary>
        [Parameter]
        public bool Open { set; get; }

        /// <summary>
        /// Do we still want to enforce the focus?
        /// This prop helps nesting TrapFocus elements.
        /// </summary>
        [Parameter]
        public bool IsEnabled { set; get; }

        /// <summary>
        /// If <c>true</c>, the modal will not automatically shift focus to itself when it opens, and
        /// replace it to the last focused element when it closes.
        /// This also works correctly with any modal children that have the <c>DisableAutoFocus</c> prop.
        /// <remarks>
        /// Generally this should never be set to `true` as it makes the modal less
        /// accessible to assistive technologies, like screen readers.
        /// </remarks>
        /// </summary>
        [Parameter]
        public bool DisableAutoFocus { set; get; }

        /// <summary>
        /// If <c>true</c>, the modal will not prevent focus from leaving the modal while open.
        /// <remarks>
        /// Generally this should never be set to `true` as it makes the modal less
        /// accessible to assistive technologies, like screen readers.
        /// </remarks>
        /// </summary>
        [Parameter]
        public bool DisableEnforceFocus { set; get; }

        /// <summary>
        /// If <c>true</c>, the modal will not restore focus to previously focused element once modal is hidden.
        /// </summary>
        [Parameter]
        public bool DisableRestoreFocus { set; get; }

        protected IReference SentinelStart { set; get; } = new Reference();

        protected IReference SentinelEnd { set; get; } = new Reference();

        protected override async Task OnAfterRenderAsync()
        {
            await base.OnAfterRenderAsync();

            await TrapFocusHelper.DisposeAsync();

            if (Open)
            {
                await TrapFocusHelper.InitAsync(ChildRef.Current, DisableAutoFocus, DisableRestoreFocus, DisableEnforceFocus, IsEnabled);
            }
        }
    }
}
