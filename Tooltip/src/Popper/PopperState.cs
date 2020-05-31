using System.Collections.Generic;

namespace Skclusive.Material.Tooltip
{
    public class PopperState
    {
        public string Placement { get; set; }
        public IList<object> OrderedModifiers { get; set; }
        public PopperOptions Options { get; set; }
        public object ModifiersData { get; set; }
        public object Elements { get; set; }
        public object Attributes { get; set; }
        public object Styles { get; set; }
    }
}
