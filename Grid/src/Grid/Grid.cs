using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Grid
{
    public class GridComponent : MaterialComponent
    {
        public GridComponent() : base("Grid")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If <c>true</c>, it sets <c>min-width: 0</c> on the item.
        /// Refer to the limitations section of the documentation to better understand the use case.
        /// </summary>
        [Parameter]
        public bool ZeroMinWidth { set; get; } = false;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Wrap" /> which defines the <c>flex-wrap</c> style property.
        /// It's applied for all screen sizes.
        /// </summary>
        [Parameter]
        public Wrap Wrap { set; get; } = Wrap.Wrap;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Justify" /> which defines the <c>justify-content</c> style property.
        /// It is applied for all screen sizes.
        /// </summary>
        [Parameter]
        public Justify Justify { set; get; } = Justify.FlexStart;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Direction" /> which defines the <c>flex-direction</c> style property.
        /// It is applied for all screen sizes.
        /// </summary>
        [Parameter]
        public Direction Direction { set; get; } = Direction.Row;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.AlignItems" /> which defines the <c>align-items</c> style property.
        /// It's applied for all screen sizes.
        /// </summary>
        [Parameter]
        public AlignItems AlignItems { set; get; } = AlignItems.Stretch;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.AlignContent" /> which defines the <c>align-content</c> style property.
        /// It's applied for all screen sizes.
        /// </summary>
        [Parameter]
        public AlignContent AlignContent { set; get; } = AlignContent.Stretch;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Spacing" /> which defines the space between the type <c>Item</c> component.
        /// It can only be used on a type <c>container</c> component.
        /// </summary>
        [Parameter]
        public Spacing Spacing { set; get; } = Spacing.Zero;

        /// <summary>
        /// If <c>true</c>, the component will have the flex *container* behavior.
        /// You should be wrapping *items* with a *container*.
        /// </summary>
        [Parameter]
        public bool Container { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the component will have the flex *item* behavior.
        /// You should be wrapping *items* with a *container*.
        /// </summary>
        [Parameter]
        public bool Item { set; get; } = false;

        /// <summary>
        /// The <see cref="GridSize" /> which defines the number of grids the component is going to use.
        /// It's applied for all the screen sizes with the lowest priority.
        /// </summary>
        [Parameter]
        public GridSize ExtraSmall { set; get; } = GridSize.False;

        /// <summary>
        /// The <see cref="GridSize" /> which defines the number of grids the component is going to use.
        /// It's applied for the <c>Small</c> breakpoint and wider screens if not overridden.
        /// </summary>
        [Parameter]
        public GridSize Small { set; get; } = GridSize.False;

        /// <summary>
        /// The <see cref="GridSize" /> which defines the number of grids the component is going to use.
        /// It's applied for the <c>Medium</c> breakpoint and wider screens if not overridden.
        /// </summary>
        [Parameter]
        public GridSize Medium { set; get; } = GridSize.False;

        /// <summary>
        /// The <see cref="GridSize" /> which defines the number of grids the component is going to use.
        /// It's applied for the <c>Large</c> breakpoint and wider screens if not overridden.
        /// </summary>
        [Parameter]
        public GridSize Large { set; get; } = GridSize.False;

        /// <summary>
        /// The <see cref="GridSize" /> which defines the number of grids the component is going to use.
        /// It's applied for the <c>ExtraLarge</c> breakpoint and wider screens.
        /// </summary>
        [Parameter]
        public GridSize ExtraLarge { set; get; } = GridSize.False;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Container)
                    yield return nameof(Container);

                if (Item)
                    yield return nameof(Item);

                if (ZeroMinWidth)
                    yield return nameof(ZeroMinWidth);

                if (Container && Spacing != Spacing.Zero)
                    yield return $"{nameof(Spacing)}-XS-{(int)Spacing}";

                if (Direction != Direction.Row)
                    yield return $"{nameof(Direction)}-XS-{Direction}";

                if (Wrap != Wrap.Wrap)
                    yield return $"{nameof(Wrap)}-XS-{Wrap}";

                if (AlignItems != AlignItems.Stretch)
                    yield return $"{nameof(AlignItems)}-XS-{AlignItems}";

                if (AlignContent != AlignContent.Stretch)
                    yield return $"{nameof(AlignContent)}-XS-{AlignContent}";

                if (Justify != Justify.FlexStart)
                    yield return $"{nameof(Justify)}-XS-{Justify}";

                if (ExtraSmall != GridSize.False)
                    yield return $"XS-{ExtraSmall.AsString()}";

                if (Small != GridSize.False)
                    yield return $"SM-{Small.AsString()}";

                if (Medium != GridSize.False)
                    yield return $"MD-{Medium.AsString()}";

                if (Large != GridSize.False)
                    yield return $"LG-{Large.AsString()}";

                if (ExtraLarge != GridSize.False)
                    yield return $"XL-{ExtraLarge.AsString()}";
            }
        }
    }
}
