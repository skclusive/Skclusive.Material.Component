using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using System.Collections.Generic;

namespace Skclusive.Material.Core
{
    public class ResponsiveComponent : MaterialComponentBase
    {
        public ResponsiveComponent() : base("Responsive")
        {
        }

        protected string Prefix => $"{Selector}-{Name}";

        /// <summary>
        /// unique name to be used in class names.
        /// </summary>
        [Parameter]
        public string Name { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public string ExtraSmallDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string ExtraSmallUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string ExtraSmallOnly { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string SmallUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public string SmallDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public string SmallOnly { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public string MediumDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string MediumUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string MediumOnly { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public string LargeDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string LargeUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string LargeOnly { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and down will be hidden.
        /// </summary>
        [Parameter]
        public string ExtraLargeDown { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string ExtraLargeUp { set; get; }

        /// <summary>
        /// If <c>true</c>, screens this size and up will be hidden.
        /// </summary>
        [Parameter]
        public string ExtraLargeOnly { set; get; }

        /// <summary>
        /// ChildContent of the current component which gets component <see cref="IComponentContext" />.
        /// </summary>
        [Parameter]
        public RenderFragment<IComponentContext> ChildContent { set; get; }

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

                if (!string.IsNullOrWhiteSpace(ExtraSmallUp))
                    yield return nameof(ExtraSmallUp);

                if (!string.IsNullOrWhiteSpace(ExtraSmallDown))
                    yield return nameof(ExtraSmallDown);

                if (!string.IsNullOrWhiteSpace(ExtraSmallOnly))
                    yield return nameof(ExtraSmallOnly);

                if (!string.IsNullOrWhiteSpace(SmallUp))
                    yield return nameof(SmallUp);

                if (!string.IsNullOrWhiteSpace(SmallDown))
                    yield return nameof(SmallDown);

                if (!string.IsNullOrWhiteSpace(SmallOnly))
                    yield return nameof(SmallOnly);

                if (!string.IsNullOrWhiteSpace(MediumUp))
                    yield return nameof(MediumUp);

                if (!string.IsNullOrWhiteSpace(MediumDown))
                    yield return nameof(MediumDown);

                if (!string.IsNullOrWhiteSpace(MediumOnly))
                    yield return nameof(MediumOnly);

                if (!string.IsNullOrWhiteSpace(LargeUp))
                    yield return nameof(LargeUp);

                if (!string.IsNullOrWhiteSpace(LargeDown))
                    yield return nameof(LargeDown);

                if (!string.IsNullOrWhiteSpace(LargeOnly))
                    yield return nameof(LargeOnly);

                if (!string.IsNullOrWhiteSpace(ExtraLargeUp))
                    yield return nameof(ExtraLargeUp);

                if (!string.IsNullOrWhiteSpace(ExtraLargeDown))
                    yield return nameof(ExtraLargeDown);

                if (!string.IsNullOrWhiteSpace(ExtraLargeOnly))
                    yield return nameof(ExtraLargeOnly);
            }
        }
    }
}
