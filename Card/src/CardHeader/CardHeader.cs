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

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// The content of the Card Title.
        /// </summary>
        [Parameter]
        public string Title { set; get; }

        /// <summary>
        /// The content of the component.
        /// </summary>
        [Parameter]
        public string SubHeader { set; get; }

        /// <summary>
        /// The Avatar for the Card Header.
        /// </summary>
        [Parameter]
        public RenderFragment AvatarContent { set; get; }

        /// <summary>
        /// The action to display in the card header.
        /// </summary>
        [Parameter]
        public RenderFragment ActionContent { set; get; }

        /// <summary>
        /// The complex content of the Card Title.
        /// </summary>
        [Parameter]
        public RenderFragment TitleContent { set; get; }

        /// <summary>
        /// The complex content of the component.
        /// </summary>
        [Parameter]
        public RenderFragment SubHeaderContent { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Avatar</c> element.
        /// </summary>
        [Parameter]
        public string AvatarStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Avatar</c> element.
        /// </summary>
        [Parameter]
        public string AvatarClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Action</c> element.
        /// </summary>
        [Parameter]
        public string ActionStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Action</c> element.
        /// </summary>
        [Parameter]
        public string ActionClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Content</c> element.
        /// </summary>
        [Parameter]
        public string ContentStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Content</c> element.
        /// </summary>
        [Parameter]
        public string ContentClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Title</c> element.
        /// </summary>
        [Parameter]
        public string TitleStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Title</c> element.
        /// </summary>
        [Parameter]
        public string TitleClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Subheader</c> element.
        /// </summary>
        [Parameter]
        public string SubHeaderStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Subheader</c> element.
        /// </summary>
        [Parameter]
        public string SubHeaderClass { set; get; }

        protected bool HasActionContent => ActionContent != null;

        protected bool HasAvatarContent => AvatarContent != null;

        protected bool HasTitleContent => TitleContent != null;

        protected bool HasSubHeaderContent => SubHeaderContent != null;

        protected TypographyVariant TitleVariant => HasAvatarContent ? TypographyVariant.Body2 : TypographyVariant.H5;

        protected TypographyVariant SubHeaderVariant => HasAvatarContent ? TypographyVariant.Body2 : TypographyVariant.Body1;

        protected virtual string _AvatarStyle => CssUtil.ToStyle(AvatarStyles, AvatarStyle);

        protected virtual IEnumerable<Tuple<string, object>> AvatarStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _AvatarClass => CssUtil.ToClass(Selector, AvatarClasses, AvatarClass);

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
