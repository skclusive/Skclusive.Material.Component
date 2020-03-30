using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Core
{
    public class Portal : MaterialContextComponent, IDisposable
    {
        [Inject]
        public DomHelpers DomHelpers { set; get; }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { get; set; } = "div";

        /// <summary>
        /// Reference attached to the target.
        /// </summary>
        [Parameter]
        public IReference TargetRef { get; set; }

        /// <summary>
        /// Reference attached to the target body.
        /// </summary>
        [Parameter]
        public IReference TargetBodyRef { get; set; }

        /// <summary>
        /// Disable the portal behavior.
        /// The children stay within it's parent DOM hierarchy.
        /// </summary>
        [Parameter]
        public bool DisablePortal { get; set; } = false;

        protected IReference SourceRef { get; set; } = new Reference();

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            if (!DisablePortal)
            {
                builder.OpenElement(0, Component);
                builder.AddAttribute(1, "style", "display: none;");
                builder.AddContent(2, ChildContent.Invoke(Context));
                builder.AddElementReferenceCapture(3, (refx) =>
                {
                    SourceRef.Current = refx;
                });
                builder.CloseElement();
            }
            else
            {
                builder.AddContent(4, ChildContent.Invoke(Context));
            }
        }

        protected override async Task OnAfterRenderAsync()
        {
            await base.OnAfterRenderAsync();

            if (!DisablePortal)
            {
                // await Task.Delay(2000);

                await DomHelpers.MoveContentAsync(SourceRef.Current, TargetRef?.Current, TargetBodyRef?.Current);
            }
        }

        protected override void Dispose()
        {
            base.Dispose();

            if (!DisablePortal)
            {
                if (ChildRef.Current != null)
                {
                    _ = DomHelpers.RemoveNodeAsync(ChildRef.Current);
                }
            }
        }
    }
}