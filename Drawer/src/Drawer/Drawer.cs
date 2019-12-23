using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;

namespace Skclusive.Material.Drawer
{
    public enum DrawerVariant
    {
        Permanent,

        Temporary,

        Persistent
    }

    public class DrawerComponent : MaterialComponent
    {
        public DrawerComponent() : base("Drawer")
        {
        }

        [Parameter]
        public int? TransitionDuration { set; get; }

        [Parameter]
        public int? AppearTimeout { set; get; }

        [Parameter]
        public int? EnterTimeout { set; get; }

        [Parameter]
        public int? ExitTimeout { set; get; }

        [Parameter]
        public bool Open { set; get; }

        [Parameter]
        public int Elevation { set; get; } = 16;

        [Parameter]
        public Placement Anchor { set; get; } = Placement.Start;

        [Parameter]
        public DrawerVariant Variant { set; get; } = DrawerVariant.Temporary;

        [Parameter]
        public string PaperClass { set; get; }

        [Parameter]
        public string PaperStyle { set; get; }

        [Parameter]
        public RenderFragment<IModalContext> BackdropContent { set; get; }

        [Parameter]
        public Action OnClose { set; get; }

        protected int _Elevation => Variant == DrawerVariant.Temporary ? Elevation : 0;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (Variant != DrawerVariant.Permanent)
                    yield return "Docked";
            }
        }

        protected virtual string _PaperStyle
        {
            get => CssUtil.ToStyle(PaperStyles, PaperStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> PaperStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _PaperClass
        {
            get => CssUtil.ToClass($"{Selector}-Paper", PaperClasses, PaperClass);
        }

        protected virtual IEnumerable<string> PaperClasses
        {
            get
            {
                yield return string.Empty;

                yield return $"{nameof(Anchor)}-{Anchor}";

                if (Variant != DrawerVariant.Temporary)
                yield return  $"{nameof(Anchor)}-Docked-{Anchor}";

                if (Variant == DrawerVariant.Temporary)
                yield return "Modal";
            }
        }

        protected Placement Placement
        {
            get
            {
                switch (Anchor)
                {
                    case Placement.Start:
                        return Placement.End;
                    case Placement.Top:
                        return Placement.Bottom;
                    case Placement.Bottom:
                        return Placement.Top;
                    case Placement.End:
                        return Placement.Start;
                    default:
                        return Placement.Start;
                }
            }
        }

        protected void HandleClose(ModalCloseReason reason)
        {
            OnClose?.Invoke();
        }
    }
}
