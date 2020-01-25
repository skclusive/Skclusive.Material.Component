using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skclusive.Material.Table
{
    public class TableCellComponent : MaterialComponent
    {
        public TableCellComponent() : base("TableCell")
        {
        }

        [Parameter]
        public string Component { set; get; }

        [Parameter]
        public bool Selected { set; get; }

        [Parameter]
        public bool Hover { set; get; }

        [Parameter]
        public bool Numeric { set; get; }

        [Parameter]
        public string Scope { set; get; }

        [Parameter]
        public Align Align { set; get; } = Align.Inherit;

        [Parameter]
        public Portion? Portion { set; get; }

        [Parameter]
        public Size? Size { set; get; }

        [Parameter]
        public Sort Sort { set; get; } = Sort.None;

        [Parameter]
        public Padding? Padding { set; get; }

        [CascadingParameter]
        public ITableContext TableContext { set; get; }

        [CascadingParameter]
        public ITableContentContext ContentContext { set; get; }

        protected string AriaSort => Sort.ToString();

        protected string _Component => string.IsNullOrWhiteSpace(Component) ? ContentContext?.Portion == Skclusive.Core.Component.Portion.Head ? "th" : "td" : Component;

        protected string _Scope => string.IsNullOrWhiteSpace(Scope) && ContentContext?.Portion == Skclusive.Core.Component.Portion.Head ? "col" : Scope;

        protected Size? _Size => Size == null ? (TableContext?.Size ?? Skclusive.Core.Component.Size.Medium) : Size;

        protected Padding? _Padding => Padding == null ? (TableContext?.Padding ?? Skclusive.Core.Component.Padding.Default) : Padding;

        protected Portion? _Portion => Portion == null ? ContentContext?.Portion : Portion;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{_Portion}";

                if (_Portion == Skclusive.Core.Component.Portion.Head && (TableContext?.StickyHeader ?? false))
                    yield return "StickyHeader";

                if (Align != Align.Inherit)
                    yield return $"{nameof(Align)}-{Align}";

                if (_Padding != Skclusive.Core.Component.Padding.Default)
                    yield return $"{nameof(Padding)}-{_Padding}";

                if (_Size != Skclusive.Core.Component.Size.Medium)
                    yield return $"{nameof(Size)}-{_Size}";
            }
        }
    }
}
