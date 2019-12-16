using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Skclusive.Material.Card
{
    public class CardMediaComponent : MaterialComponent
    {
        private static readonly List<string> MEDIAS = new List<string>()
        {
            "video",
            "audio",
            "picture",
            "iframe",
            "img"
        };

        private static readonly List<string> IMAGES = new List<string>()
        {
            "picture",
            "img"
        };

        public CardMediaComponent() : base("CardMedia")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string Image { set; get; }

        [Parameter]
        public string Src { set; get; }

        protected bool IsMedia
        {
            get => MEDIAS.Contains(Component);
        }

        protected bool IsImage
        {
            get => IMAGES.Contains(Component);
        }

        protected bool IsImageOnly
        {
            get => !IsMedia && !string.IsNullOrWhiteSpace(Image); // && IsImage;
        }

        protected string _Src => IsMedia ? (Image ?? Src) : null;

        //protected Dictionary<string, object> AdditionalAttributes
        //{ 
        //    get => Attributes.Concat(new Dictionary<string, object>()
        //    {
        //        { "src", IsMedia ? (Image ?? Src) : null }

        //    }).ToDictionary(x => x.Key, v => v.Value);
        //}

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (IsMedia)
                    yield return "Media";

                if (IsImage)
                    yield return "Image";
            }
        }

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                foreach (var item in base.Styles)
                    yield return item;

                if (IsImageOnly)
                    yield return Tuple.Create<string, object>("background-image", $"url(\"{Image}\")");
            }
        }
    }
}
