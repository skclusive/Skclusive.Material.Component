using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Material.Core;
using System.Collections.Generic;
using Skclusive.Material.Typography;
using System;
using System.Linq;
using System.Threading.Tasks;
using Skclusive.Core.Component;

namespace Skclusive.Material.List
{
    public class ListItemTextComponent : MaterialComponent
    {
        public ListItemTextComponent() : base("ListItemText")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// The main content as text.
        /// </summary>
        [Parameter]
        public string Primary { set; get; }

        /// <summary>
        /// The secondary content as text.
        /// </summary>
        [Parameter]
        public string Secondary { set; get; }

        /// <summary>
        /// If <c>true</c>, the children will be indented.
        /// This should be used if there is no left avatar or left icon.
        /// </summary>
        [Parameter]
        public bool Inset { set; get; } = false;

        /// <summary>
        /// If <c>true</c>, the children won't be wrapped by a Typography component.
        /// This can be useful to render an alternative Typography variant by wrapping
        /// the <c>children</c> (or <c>primary</c>) text, and optional <c>secondary</c> text
        /// with the Typography component.
        /// </summary>
        [Parameter]
        public bool DisableTypography { set; get; } = false;

        /// <summary>
        /// <c>style</c> applied on the <c>Primary</c> element.
        /// </summary>
        [Parameter]
        public string PrimaryStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Primary</c> element.
        /// </summary>
        [Parameter]
        public string PrimaryClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Secondary</c> element.
        /// </summary>
        [Parameter]
        public string SecondaryStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Secondary</c> element.
        /// </summary>
        [Parameter]
        public string SecondaryClass { set; get; }

        /// <summary>
        /// The main content element.
        /// </summary>
        [Parameter]
        public RenderFragment PrimaryContent { set; get; }

        /// <summary>
        /// The secondary content element.
        /// </summary>
        [Parameter]
        public RenderFragment SecondaryContent { set; get; }

        /// <summary>
        /// The main content element typography props.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> PrimaryTypographyProps { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// The secondary content element typography props.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> SecondaryTypographyProps { get; set; } = new Dictionary<string, object>();


        [CascadingParameter]
        public IListContext ListContext { set; get; }

        protected RenderFragment PrimaryFragment { set; get; }

        protected RenderFragment SecondaryFragment { set; get; }


        protected bool IsDense => ListContext?.Dense ?? false;

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            RenderFragment primaryContent = null;

            if (PrimaryContent != null || !string.IsNullOrWhiteSpace(Primary))
            {
                primaryContent = PrimaryContent ?? (RenderFragment)((builder) =>
                {
                    builder.AddContent(1, Primary);
                });
            }

            if(primaryContent != null)
            {
                if (!DisableTypography)
                {
                    PrimaryFragment = (RenderTreeBuilder builder) =>
                    {
                        builder.OpenRegion(1);
                        builder.OpenComponent<Typography.Typography>(0);
                        builder.AddAttribute(1, "Component", "span");
                        builder.AddAttribute(2, "Style", _PrimaryStyle);
                        builder.AddAttribute(3, "Class", _PrimaryClass);
                        builder.AddMultipleAttributes(4, PrimaryTypographyProps);
                        builder.AddAttribute(5, "Variant", IsDense ? TypographyVariant.Body2 : TypographyVariant.Body1);
                        builder.AddAttribute(6, "ChildContent", primaryContent);
                        builder.CloseComponent();
                        builder.CloseRegion();
                    };
                } else
                {
                    PrimaryFragment = primaryContent;
                }
            }

            RenderFragment secondaryContent = null;

            if (SecondaryContent != null || !string.IsNullOrWhiteSpace(Secondary))
            {
                secondaryContent = SecondaryContent ?? (RenderFragment)((builder) =>
                {
                    builder.AddContent(1, Secondary);
                });
            }

            if(secondaryContent != null)
            {
                if (!DisableTypography)
                {
                    SecondaryFragment = (RenderTreeBuilder builder) =>
                    {
                        builder.OpenRegion(2);
                        builder.OpenComponent<Typography.Typography>(0);
                        builder.AddAttribute(1, "Color", Color.TextSecondary);
                        builder.AddAttribute(2, "Style", _SecondaryStyle);
                        builder.AddAttribute(3, "Class", _SecondaryClass);
                        builder.AddMultipleAttributes(4, SecondaryTypographyProps);
                        builder.AddAttribute(5, "Variant", TypographyVariant.Body2);
                        builder.AddAttribute(6, "ChildContent", secondaryContent);
                        builder.CloseComponent();
                        builder.CloseRegion();
                    };
                } else
                {
                    SecondaryFragment = secondaryContent;
                }
            }
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (IsDense)
                    yield return "Dense";

                if (Inset)
                    yield return nameof(Inset);

                if (PrimaryContent != null && SecondaryContent != null)
                    yield return "Multiline";
            }
        }

        protected virtual string _PrimaryStyle
        {
            get => CssUtil.ToStyle(PrimaryStyles, PrimaryStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> PrimaryStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _PrimaryClass
        {
            get => CssUtil.ToClass($"{Selector}-Primary", PrimaryClasses, PrimaryClass);
        }

        protected virtual IEnumerable<string> PrimaryClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected virtual string _SecondaryStyle
        {
            get => CssUtil.ToStyle(SecondaryStyles, SecondaryStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> SecondaryStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _SecondaryClass
        {
            get => CssUtil.ToClass($"{Selector}-Secondary", SecondaryClasses, SecondaryClass);
        }

        protected virtual IEnumerable<string> SecondaryClasses
        {
            get
            {
                yield return string.Empty;
            }
        }
    }
}
