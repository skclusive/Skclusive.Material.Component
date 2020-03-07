using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Table
{
    public class TableSortLabelComponent : MaterialComponent
    {
        public TableSortLabelComponent() : base("TableSortLabel")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "span";

        /// <summary>
        /// <c>style</c> applied on the <c>Icon</c> element.
        /// </summary>
        [Parameter]
        public string IconStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Icon</c> element.
        /// </summary>
        [Parameter]
        public string IconClass { set; get; }

        /// <summary>
        /// If <c>true</c>, the label will have the active styling (should be true for the sorted column).
        /// </summary>
        [Parameter]
        public bool Active { set; get; } = false;

        /// <summary>
        /// Hide sort icon when active is false.
        /// </summary>
        [Parameter]
        public bool HideSortIcon { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Sort" /> current sort direction.
        /// </summary>
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

        protected virtual string _IconStyle
        {
            get => CssUtil.ToStyle(IconStyles, IconStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> IconStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }
    }
}
