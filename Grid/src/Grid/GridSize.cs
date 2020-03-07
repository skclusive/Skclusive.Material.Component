namespace Skclusive.Material.Grid
{
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
}