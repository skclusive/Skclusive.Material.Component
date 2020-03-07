using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;

namespace Skclusive.Material.Drawer
{
    public class DrawerComponent : MaterialComponent
    {
        public DrawerComponent() : base("Drawer")
        {
        }

        /// <summary>
        /// Reference attached to the container element of the component.
        /// </summary>
        [Parameter]
        public IReference ContainerRef { set; get; } = new Reference();

        /// <summary>
        /// drawer transition duration.
        /// </summary>
        [Parameter]
        public int? TransitionDuration { set; get; }

        /// <summary>
        /// drawer appear timeout.
        /// </summary>
        [Parameter]
        public int? AppearTimeout { set; get; }

        /// <summary>
        /// drawer enter timeout.
        /// </summary>
        [Parameter]
        public int? EnterTimeout { set; get; }

        /// <summary>
        /// drawer exit timeout.
        /// </summary>
        [Parameter]
        public int? ExitTimeout { set; get; }

        /// <summary>
        /// If <c>true</c>, the Drawer is open.
        /// </summary>
        [Parameter]
        public bool Open { set; get; }

        /// <summary>
        /// The elevation of the drawer.
        /// </summary>
        [Parameter]
        public int Elevation { set; get; } = 16;

        /// <summary>
        /// The <see cref="Skclusive.Core.Component.Anchor" /> Side from which the drawer will appear.
        /// </summary>
        [Parameter]
        public Anchor Anchor { set; get; } = Anchor.Left;

        /// <summary>
        /// The <see cref="DrawerVariant"> variant to use.
        /// </summary>
        [Parameter]
        public DrawerVariant Variant { set; get; } = DrawerVariant.Temporary;

        /// <summary>
        /// <c>class</c> applied on the <c>Paper</c> element.
        /// </summary>
        [Parameter]
        public string PaperClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Paper</c> element.
        /// </summary>
        [Parameter]
        public string PaperStyle { set; get; }

        /// <summary>
        /// <c>class</c> applied on the <c>Backdrop</c> element.
        /// </summary>
        [Parameter]
        public string BackdropClass { set; get; }

        /// <summary>
        /// <c>style</c> applied on the <c>Backdrop</c> element.
        /// </summary>
        [Parameter]
        public string BackdropStyle { set; get; }

        /// <summary>
        /// If <c>true</c>, positions the drawer absolute to tha relative parent.
        /// </summary>
        [Parameter]
        public bool Absolute { set; get; }

        /// <summary>
        /// custom backdrop content for the drawer.
        /// </summary>
        [Parameter]
        public RenderFragment<IModalContext> BackdropContent { set; get; }

        /// <summary>
        /// Callback fired when the drawer is getting closed.
        /// </summary>
        [Parameter]
        public Action OnClose { set; get; }

        protected int _Elevation => Variant == DrawerVariant.Temporary ? Elevation : 0;

        protected override IEnumerable<Tuple<string, object>> Styles
        {
            get
            {
                if (Absolute)
                {
                    yield return Tuple.Create<string, object>("position", "absolute");

                    yield return Tuple.Create<string, object>("top", "0px");

                    yield return Tuple.Create<string, object>("bottom", "0px");

                    if (Anchor == Anchor.Left)
                    yield return Tuple.Create<string, object>("left",  "0px");

                    if (Anchor == Anchor.Right)
                    yield return Tuple.Create<string, object>("right", "0px");
                }
            }
        }

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
            get
            {
                if (Absolute)
                    yield return Tuple.Create<string, object>("position", "relative");
            }
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

        protected virtual string _BackdropStyle
        {
            get => CssUtil.ToStyle(BackdropStyles, BackdropStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> BackdropStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _BackdropClass
        {
            get => CssUtil.ToClass($"{Selector}-Backdrop", BackdropClasses, BackdropClass);
        }

        protected virtual IEnumerable<string> BackdropClasses
        {
            get
            {
                yield return string.Empty;
            }
        }

        protected Placement Placement
        {
            get
            {
                switch (Anchor)
                {
                    case Anchor.Left:
                        return Placement.End;
                    case Anchor.Top:
                        return Placement.Bottom;
                    case Anchor.Bottom:
                        return Placement.Top;
                    case Anchor.Right:
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
