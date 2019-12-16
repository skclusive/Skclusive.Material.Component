using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Typography;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Card
{
    public class CardHeaderComponent : MaterialComponent
    {
        public CardHeaderComponent() : base("CardHeader")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string Title { set; get; }

        [Parameter]
        public string SubHeader { set; get; }

        [Parameter]
        public RenderFragment AvatarContent { set; get; }

        [Parameter]
        public RenderFragment ActionContent { set; get; }

        [Parameter]
        public RenderFragment TitleContent { set; get; }

        [Parameter]
        public RenderFragment SubHeaderContent { set; get; }

        [Parameter]
        public string AvatarStyle { set; get; }

        [Parameter]
        public string AvatarClass { set; get; }

        [Parameter]
        public string ActionStyle { set; get; }

        [Parameter]
        public string ActionClass { set; get; }

        [Parameter]
        public string ContentStyle { set; get; }

        [Parameter]
        public string ContentClass { set; get; }

        [Parameter]
        public string TitleStyle { set; get; }

        [Parameter]
        public string TitleClass { set; get; }

        [Parameter]
        public string SubHeaderStyle { set; get; }

        [Parameter]
        public string SubHeaderClass { set; get; }

        protected bool HasActionContent
        {
            get => ActionContent != null;
        }

        protected bool HasAvatarContent
        {
            get => AvatarContent != null;
        }

        protected bool HasTitleContent
        {
            get => TitleContent != null;
        }

        protected bool HasSubHeaderContent
        {
            get => SubHeaderContent != null;
        }

        protected TypographyVariant TitleVariant
        {
            get => HasAvatarContent ? TypographyVariant.Body2 : TypographyVariant.H5;
        }

        protected TypographyVariant SubHeaderVariant
        {
            get => HasAvatarContent ? TypographyVariant.Body2 : TypographyVariant.Body1;
        }

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
            get => CssUtil.ToClass(Selector, AvatarClasses, AvatarClass);
        }

        protected virtual IEnumerable<string> AvatarClasses
        {
            get
            {
                yield return nameof(Avatar);
            }
        }

        protected virtual string _ActionStyle
        {
            get => CssUtil.ToStyle(ActionStyles, ActionStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ActionStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ActionClass
        {
            get => CssUtil.ToClass(Selector, ActionClasses, ActionClass);
        }

        protected virtual IEnumerable<string> ActionClasses
        {
            get
            {
                yield return nameof(Action);
            }
        }

        protected virtual string _ContentStyle
        {
            get => CssUtil.ToStyle(ContentStyles, ContentStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ContentStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ContentClass
        {
            get => CssUtil.ToClass(Selector, ContentClasses, ContentClass);
        }

        protected virtual IEnumerable<string> ContentClasses
        {
            get
            {
                yield return "Content";
            }
        }

        protected virtual string _TitleStyle
        {
            get => CssUtil.ToStyle(TitleStyles, TitleStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> TitleStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _TitleClass
        {
            get => CssUtil.ToClass(Selector, TitleClasses, TitleClass);
        }

        protected virtual IEnumerable<string> TitleClasses
        {
            get
            {
                yield return nameof(Title);
            }
        }

        protected virtual string _SubHeaderStyle
        {
            get => CssUtil.ToStyle(SubHeaderStyles, SubHeaderStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> SubHeaderStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _SubHeaderClass
        {
            get => CssUtil.ToClass(Selector, SubHeaderClasses, SubHeaderClass);
        }

        protected virtual IEnumerable<string> SubHeaderClasses
        {
            get
            {
                yield return nameof(SubHeader);
            }
        }
    }
}
