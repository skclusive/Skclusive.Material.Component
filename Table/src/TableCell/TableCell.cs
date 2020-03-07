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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; }

        /// <summary>
        /// Set scope attribute.
        /// </summary>
        [Parameter]
        public string Scope { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Align" /> that sets the text-align on the table cell content.
        /// <remarks>
        /// Monetary or generally number fields **should be right aligned** as that allows
        /// you to add them up quickly in your head without having to worry about decimals.
        /// </remarks>
        /// </summary>
        [Parameter]
        public Align Align { set; get; } = Align.Inherit;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Portion" /> that specifies the cell type.
        ///  By default, the TableHead, TableBody or TableFooter parent component set the value.
        /// </summary>
        [Parameter]
        public Portion? Portion { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Size" /> that specifies the size of the cell.
        /// By default, the Table parent component set the value (`medium`).
        /// </summary>
        [Parameter]
        public Size? Size { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Sort" /> that sets aria-sort direction.
        /// </summary>
        [Parameter]
        public Sort Sort { set; get; } = Sort.None;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Padding" /> that sets the padding applied to the cell.
        /// By default, the Table parent component set the value (`default`).
        /// </summary>
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
