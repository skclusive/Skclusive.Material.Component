using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Hidden
{
    public class Hidden : MaterialComponentBase
    {
        public Hidden() : base("Hidden")
        {
        }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public bool ExtraSmallDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public bool ExtraSmallUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public bool SmallUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public bool SmallDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public bool MediumDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public bool MediumUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public bool LargeDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public bool LargeUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public bool ExtraLargeDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public bool ExtraLargeUp { set; get; }

        /// <summary>
        /// Hide the given breakpoint(s).
        /// </summary>
        [Parameter]
        public Breakpoint[] Only { set; get; }

        /// <summary>
        /// ChildContent of the current component which gets component <see cref="IComponentContext" />.
        /// </summary>
        [Parameter]
        public RenderFragment<IComponentContext> ChildContent { set; get; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(0, ChildContent(Context));
        }

        protected IComponentContext Context => new ComponentContextBuilder()
           .WithClass(_Class)
           .WithStyle(_Style)
           .WithRefBack(RootRef)
           .WithDisabled(Disabled)
           .Build();

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if(ExtraSmallUp)
                    yield return nameof(ExtraSmallUp);

                if (ExtraSmallDown)
                    yield return nameof(ExtraSmallDown);

                if (SmallUp)
                    yield return nameof(SmallUp);

                if (SmallDown)
                    yield return nameof(SmallDown);

                if (MediumUp)
                    yield return nameof(MediumUp);

                if (MediumDown)
                    yield return nameof(MediumDown);

                if (LargeUp)
                    yield return nameof(LargeUp);

                if (LargeDown)
                    yield return nameof(LargeDown);

                if (ExtraLargeUp)
                    yield return nameof(ExtraLargeUp);

                if (ExtraLargeDown)
                    yield return nameof(ExtraLargeDown);

                if (Only != null)
                {
                    foreach(var breakpoint in Only)
                        yield return $"{breakpoint}Only";
                }
            }
        }
    }
}
