using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;

namespace Skclusive.Material.Selection
{
    public class SwitchComponent : SelectionConfig
    {
        public SwitchComponent() : base("Switch")
        {
            Icon = CheckedIcon = (RenderTreeBuilder builder) =>
            {
                builder.OpenElement(0, "span");
                builder.AddAttribute(1, "class", _ThumbClass);
                builder.AddAttribute(2, "style", _ThumbStyle);
                builder.CloseElement();
            };
        }

        [Parameter]
        public Edge Edge { set; get; } = Edge.None;

        [Parameter]
        public Size Size { set; get; } = Size.Medium;

        [Parameter]
        public string SwitchBaseClass { set; get; }

        [Parameter]
        public string SwitchBaseStyle { set; get; }

        [Parameter]
        public string ThumbClass { set; get; }

        [Parameter]
        public string ThumbStyle { set; get; }

        [Parameter]
        public string TrackClass { set; get; }

        [Parameter]
        public string TrackStyle { set; get; }

        protected string _InputClass => $"~{Selector}-Input {InputClass}";

        protected string _CheckedClass => $"~{Selector}-Checked";

        protected string _DisabledClass => $"~{Selector}-Disabled";

        protected Color _Color => Color == default ? Color.Secondary : Color;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Size != Size.Medium)
                    yield return $"{nameof(Size)}-{Size}";

                if (Edge == Edge.Start || Edge == Edge.End)
                    yield return $"{nameof(Edge)}-{Edge}";
            }
        }

        protected virtual string _SwitchBaseClass
        {
            get => CssUtil.ToClass($"{Selector}-SwitchBase", SwitchBaseClasses, SwitchBaseClass);
        }

        protected virtual IEnumerable<string> SwitchBaseClasses
        {
            get
            {
                yield return string.Empty;

                yield return $"~Switch-{nameof(Color)}-{_Color}";
            }
        }

        protected virtual string _SwitchBaseStyle
        {
            get => CssUtil.ToStyle(SwitchBaseStyles, SwitchBaseStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> SwitchBaseStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ThumbClass
        {
            get => CssUtil.ToClass($"{Selector}-Thumb", ThumbClasses, ThumbClass);
        }

        protected virtual IEnumerable<string> ThumbClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected virtual string _ThumbStyle
        {
            get => CssUtil.ToStyle(ThumbStyles, ThumbStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ThumbStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _TrackClass
        {
            get => CssUtil.ToClass($"{Selector}-Track", TrackClasses, TrackClass);
        }

        protected virtual IEnumerable<string> TrackClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected virtual string _TrackStyle
        {
            get => CssUtil.ToStyle(TrackStyles, TrackStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> TrackStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }
    }
}
