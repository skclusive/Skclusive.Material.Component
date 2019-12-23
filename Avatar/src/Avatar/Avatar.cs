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

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string Alt { set; get; }

        [Parameter]
        public string Src { set; get; }


        [Parameter]
        public string SrcSet { set; get; }

        [Parameter]
        public string Sizes { set; get; }

        [Parameter]
        public string ImageStyle { set; get; }

        [Parameter]
        public string ImageClass { set; get; }

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
