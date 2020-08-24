using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Skclusive.Material.Core;
using Skclusive.Script.DomHelpers;
using Skclusive.Material.Icon;
using Skclusive.Material.Avatar;

namespace Skclusive.Material.Chip
{
    public class ChipComponent : MaterialComponentBase
    {
        public ChipComponent() : base("Chip")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// If `true`, the chip will hover on mouse over and ripple on click.
        /// </summary>
        [Parameter]
        public bool? Clickable { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public RenderFragment LabelContent { get; set; }

        /// <summary>
        /// Avatar placed before the children instead of DeleteIcon.
        /// </summary>
        [Parameter]
        public RenderFragment AvatarContent { set; get; }

        /// <summary>
        /// The <see cref="ChipVariant" /> defines the look of the chip.
        /// </summary>
        [Parameter]
        public ChipVariant Variant { set; get; } = ChipVariant.Default;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Size" /> of the button.
        /// </summary>
        [Parameter]
        public Size Size { set; get; } = Size.Medium;

        /// <summary>
        /// Element placed before the children.
        /// </summary>
        [Parameter]
        public RenderFragment IconContent { set; get; }

        /// <summary>
        /// Element placed after the children.
        /// </summary>
        [Parameter]
        public RenderFragment DeleteIconContent { set; get; }

        /// <summary>
        /// The URL to link to when the button is clicked.
        /// If defined, an <c>a</c> element will be used as the root node.
        /// </summary>
        [Parameter]
        public string Href { set; get; }

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Color" /> of the component. It supports those theme colors that make sense for this component.
        /// </summary>
        [Parameter]
        public Color Color { set; get; } = Color.Default;

        [Parameter]
        public EventCallback<EventArgs> OnDelete { get; set; }

        [Inject]
        public DomHelpers DomHelpers { set; get; }

        protected bool Deletable => OnDelete.HasDelegate;

        protected bool HasIcon => IsClickable || Deletable;

        protected string _Role => HasIcon ? "button" : Role;

        protected int? _TabIndex => HasIcon ? 0 : TabIndex;

        protected bool HasLabelContent => LabelContent != null;

        protected bool HasAvatarContent => AvatarContent != null;

        protected bool HasIconContent => IconContent != null;

        protected bool HasDeleteIconContent => DeleteIconContent != null;

        protected bool IsClickable => (!Clickable.HasValue || Clickable.Value) && OnClick.HasDelegate ? true : Clickable.HasValue && Clickable.Value;

        protected ISvgIconContext IconContext => new SvgIconContextBuilder()
           .WithClass(_IconClass)
           .WithStyle(_IconStyle)
           .Build();

        protected ISvgIconContext DeleteIconContext => new SvgIconContextBuilder()
           .WithClass(_DeleteIconClass)
           .WithStyle(_DeleteIconStyle)
           // .WithOnClick() TODO: pass OnClick
           .Build();

        protected IAvatarContext AvatarContext => new AvatarContextBuilder()
           .WithClass(_AvatarClass)
           .WithStyle(_AvatarStyle)
           .Build();

        protected override async Task HandleKeyUpAsync(KeyboardEventArgs args)
        {
            await base.HandleKeyUpAsync(args);

            var key = args.Key;

            if (key == " " || key == "Enter")
            {
                await HandleClickAsync(args);
            }
            else if (Deletable && (key == "Backspace" || key == "Delete"))
            {
                await OnDelete.InvokeAsync(args);
            }
            else if (key == "Escape")
            {
                await DomHelpers.BlurAsync(RootRef.Current);
            }
        }

        protected async Task HandleDeleteClickAsync(EventArgs args)
        {
            await OnDelete.InvokeAsync(args);
        }

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Size == Size.Small)
                yield return $"{nameof(Size)}-{nameof(Size.Small)}";

                if (Color != Color.Default)
                yield return $"{nameof(Color)}-{Color}";

                if (IsClickable)
                {
                    yield return $"{nameof(Clickable)}";

                    if (Color != Color.Default)
                    yield return $"{nameof(Clickable)}-{nameof(Color)}-{Color}";
                }

                if (Deletable)
                {
                    yield return $"{nameof(Deletable)}";

                    if (Color != Color.Default)
                    yield return $"{nameof(Clickable)}-{nameof(Color)}-{Color}";
                }

                if (Variant == ChipVariant.Outlined)
                {
                    yield return $"{nameof(ChipVariant.Outlined)}";

                    if (Color == Color.Primary)
                    yield return $"{nameof(ChipVariant.Outlined)}-{nameof(Color.Primary)}";

                    if (Color == Color.Secondary)
                    yield return $"{nameof(ChipVariant.Outlined)}-{nameof(Color.Secondary)}";
                }
            }
        }

        /// <summary>
        /// The <c>style</c> applied on the end icon.
        /// </summary>
        [Parameter]
        public string IconStyle { set; get; }

        /// <summary>
        /// The <c>class</c> applied on the end icon.
        /// </summary>
        [Parameter]
        public string IconClass { set; get; }

        protected virtual string _IconStyle
        {
            get => CssUtil.ToStyle(IconStyles, IconStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> IconStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _IconClass
        {
            get => CssUtil.ToClass($"{Selector}-Icon", IconClasses, IconClass);
        }

        protected virtual IEnumerable<string> IconClasses
        {
            get
            {
                yield return string.Empty;

                if (Size == Size.Small)
                yield return $"{nameof(Size.Small)}";

                if (Color != Color.Default)
                yield return $"{nameof(Color)}-{Color}";
            }
        }

        /// <summary>
        /// The <c>style</c> applied on the start icon.
        /// </summary>
        [Parameter]
        public string DeleteIconStyle { set; get; }

        /// <summary>
        /// The <c>class</c> applied on the start icon.
        /// </summary>
        [Parameter]
        public string DeleteIconClass { set; get; }

        protected virtual string _DeleteIconStyle
        {
            get => CssUtil.ToStyle(DeleteIconStyles, DeleteIconStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> DeleteIconStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _DeleteIconClass
        {
            get => CssUtil.ToClass($"{Selector}-DeleteIcon", DeleteIconClasses, DeleteIconClass);
        }

        protected virtual IEnumerable<string> DeleteIconClasses
        {
            get
            {
                yield return string.Empty;

                if (Size == Size.Small)
                yield return $"{nameof(Size.Small)}";

                if (Color != Color.Default)
                {
                    if (Variant != ChipVariant.Outlined)
                    yield return $"{nameof(Color)}-{Color}";

                    if (Variant == ChipVariant.Outlined)
                    yield return $"{nameof(ChipVariant.Outlined)}-{nameof(Color)}-{Color}";
                }
            }
        }

        /// <summary>
        /// The <c>style</c> applied on the end icon.
        /// </summary>
        [Parameter]
        public string AvatarStyle { set; get; }

        /// <summary>
        /// The <c>class</c> applied on the end icon.
        /// </summary>
        [Parameter]
        public string AvatarClass { set; get; }

        protected virtual string _AvatarStyle
        {
            get => CssUtil.ToStyle(AvatarStyles, AvatarStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> AvatarStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _AvatarClass
        {
            get => CssUtil.ToClass($"{Selector}-Avatar", AvatarClasses, AvatarClass);
        }

        protected virtual IEnumerable<string> AvatarClasses
        {
            get
            {
                yield return string.Empty;

                if (Size == Size.Small)
                yield return $"{nameof(Size.Small)}";

                if (Color != Color.Default)
                yield return $"{nameof(Color)}-{Color}";
            }
        }

        /// <summary>
        /// The <c>class</c> applied to the label.
        /// </summary>
        [Parameter]
        public string LabelClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the label.
        /// </summary>
        [Parameter]
        public string LabelStyle { set; get; }

        protected virtual string _LabelClass
        {
            get => CssUtil.ToClass($"{Selector}-Label", LabelClasses, LabelClass);
        }

        protected virtual IEnumerable<string> LabelClasses
        {
            get
            {
                yield return string.Empty;

                if (Size == Size.Small)
                yield return $"{nameof(Size.Small)}";
            }
        }

        protected virtual string _LabelStyle
        {
            get => CssUtil.ToStyle(LabelStyles, LabelStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> LabelStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }
    }
}
