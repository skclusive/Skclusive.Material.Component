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

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            if (string.IsNullOrWhiteSpace(Component))
            {
                Component = ContentContext?.Portion == Skclusive.Core.Component.Portion.Head ? "th" : "td";
            }

            if (string.IsNullOrWhiteSpace(Scope) && ContentContext?.Portion == Skclusive.Core.Component.Portion.Head)
            {
                Scope = "col";
            }

            if (Padding == null)
            {
                Padding = TableContext?.Padding ?? Skclusive.Core.Component.Padding.Default;
            }

            if (Size == null)
            {
                Size = TableContext?.Size ?? Skclusive.Core.Component.Size.Medium;
            }

            if (Portion == null)
            {
                Portion = ContentContext?.Portion;
            }
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                yield return $"{Portion}";

                if (Portion == Skclusive.Core.Component.Portion.Head && (TableContext?.StickyHeader ?? false))
                    yield return "StickyHeader";

                if (Align != Align.Inherit)
                    yield return $"{nameof(Align)}-{Align}";

                if (Padding != Skclusive.Core.Component.Padding.Default)
                    yield return $"{nameof(Padding)}-{Padding}";

                if (Size != Skclusive.Core.Component.Size.Medium)
                    yield return $"{nameof(Size)}-{Size}";
            }
        }
    }
}
