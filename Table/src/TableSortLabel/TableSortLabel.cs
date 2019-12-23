using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System.Collections.Generic;

namespace Skclusive.Material.Table
{
    public class TableSortLabelComponent : MaterialComponent
    {
        public TableSortLabelComponent() : base("TableSortLabel")
        {
        }

        [Parameter]
        public string Component { set; get; } = "span";

        [Parameter]
        public string IconClass { set; get; }

        [Parameter]
        public bool Active { set; get; } = false;

        [Parameter]
        public bool HideSortIcon { set; get; }

        [Parameter]
        public Sort Direction { set; get; } = Sort.Descending;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Active)
                    yield return nameof(Active);
            }
        }
        
        protected string _IconClass
        {
            get
            {
                return CssUtil.ToClass($"{Selector}-Icon", IconClasses, IconClass);
            }
        }

        protected virtual IEnumerable<string> IconClasses
        {
            get
            {
                yield return string.Empty;

                if (Direction != Sort.None)
                    yield return $"{nameof(Direction)}-{Direction}";
            }
        }

    }
}
