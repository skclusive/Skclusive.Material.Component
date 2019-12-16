using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Material.Core
{
    public class Portal : ComponentBase, IDisposable
    {
        [Inject]
        public DomHelpers DomHelpers { set; get; }

        [Parameter]
        public string Component { get; set; } = "div";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public IReference TargetRef { get; set; }

        protected IReference SourceRef { get; set; } = new Reference();

        public bool HasContent => ChildContent != null;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            if(HasContent)
            {
                builder.OpenElement(0, Component);
                builder.AddAttribute(1, "style", "display: none;");
                builder.AddContent(2, ChildContent);
                builder.AddElementReferenceCapture(3, (refx) => {
                    SourceRef.Current = refx;
                });
                builder.CloseElement();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (TargetRef != null)
            {
                await DomHelpers.MoveContentAsync(SourceRef.Current, TargetRef.Current);
            }
        }

        public void Dispose()
        {
            if (TargetRef != null)
            {
                _ = DomHelpers.ClearContentAsync(TargetRef.Current);
            }
        }
    }
}