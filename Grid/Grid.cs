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

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public bool ZeroMinWidth { set; get; } = false;

        [Parameter]
        public Wrap Wrap { set; get; } = Wrap.Wrap;

        [Parameter]
        public Justify Justify { set; get; } = Justify.FlexStart;

        [Parameter]
        public Direction Direction { set; get; } = Direction.Row;

        [Parameter]
        public AlignItems AlignItems { set; get; } = AlignItems.Stretch;

        [Parameter]
        public AlignContent AlignContent { set; get; } = AlignContent.Stretch;

        [Parameter]
        public Spacing Spacing { set; get; } = Spacing.Zero;

        [Parameter]
        public bool Container { set; get; } = false;

        [Parameter]
        public bool Item { set; get; } = false;

        [Parameter]
        public GridSize ExtraSmall { set; get; } = GridSize.False;

        [Parameter]
        public GridSize Small { set; get; } = GridSize.False;

        [Parameter]
        public GridSize Medium { set; get; } = GridSize.False;

        [Parameter]
        public GridSize Large { set; get; } = GridSize.False;

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

    internal static class GridSizeExtension
    {
        internal static string AsString(this GridSize size)
        {
            switch(size)
            {
                case GridSize.Auto: return nameof(GridSize.Auto);
                case GridSize.True: return nameof(GridSize.True);
                case GridSize.False: return nameof(GridSize.False);
                default: return $"{(int)size}";
            }
        }
    }

    public enum AlignContent
    {
        Stretch,
        Center,
        FlexStart,
        FlexEnd,
        SpaceBetween,
        SpaceAround
    }

    public enum GridSize
    {
        False = -2,
        Auto = -1,
        True = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Eleven = 11,
        Twelve = 12
    }
}
