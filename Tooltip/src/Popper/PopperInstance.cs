namespace Skclusive.Material.Tooltip
{
    public class PopperInstance
    {
        public int Id { get; set; }
        public PopperState State { get; set; }

        public object SetState { get; set; }
        public object ForceUpdate { get; set; }
        public object Update { get; set; }
        public object Destroy { get; set; }
    }
}
