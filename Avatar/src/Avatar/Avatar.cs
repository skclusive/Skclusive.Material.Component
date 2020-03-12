using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Material.Avatar
{
    public class AvatarComponent : MaterialComponent
    {
        public AvatarComponent() : base("Avatar")
        {
        }

        /// <summary>
        /// html component tag to be used as container.
        /// </summary>
        [Parameter]
        public string Component { set; get; } = "div";

        /// <summary>
        /// Used in combination with `src` or `srcSet` to
        /// provide an alt attribute for the rendered `img` element.
        /// </summary>
        [Parameter]
        public string Alt { set; get; }

        /// <summary>
        /// The <c>src</c> attribute for the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string Src { set; get; }

        /// <summary>
        /// The <c>srcSet</c> attribute for the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string SrcSet { set; get; }

        /// <summary>
        /// The <c>sizes</c> attribute for the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string Sizes { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string ImageStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>img</c> element.
        /// </summary>
        [Parameter]
        public string ImageClass { set; get; }

        /// <summary>
        /// additional props passed to image tag.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> ImageProps { get; set; }

        protected bool IsImage => !string.IsNullOrWhiteSpace(Src) || !string.IsNullOrWhiteSpace(SrcSet);

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (!IsImage)
                    yield return "Color-Default";
            }
        }

        protected virtual string _ImageStyle
        {
            get => CssUtil.ToStyle(ImageStyles, ImageStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ImageStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ImageClass
        {
            get => CssUtil.ToClass(Selector, ImageClasses, ImageClass);
        }

        protected virtual IEnumerable<string> ImageClasses
        {
            get
            {
                yield return "Image";
            }
        }
    }
}
