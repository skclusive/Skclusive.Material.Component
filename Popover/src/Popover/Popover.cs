using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Modal;
using Skclusive.Material.Script;

namespace Skclusive.Material.Popover
{
    public class PopoverComponent : MaterialComponent
    {
        public PopoverComponent() : base("Popover")
        {
        }

        [Inject]
        public PopoverHelper PopoverHelper { set; get; }

        [Inject]
        public EventDelegator EventDelegator { set; get; }

        /// <summary>
        /// Disable the portal behavior.
        /// The children stay within it's parent DOM hierarchy.
        /// </summary>
        [Parameter]
        public bool DisablePortal { get; set; } = false;

        /// <summary>
        /// Reference attached to the portal target.
        /// </summary>
        [Parameter]
        public IReference PortalTargetRef { get; set; }

        /// <summary>
        /// Reference attached to the portal target body.
        /// </summary>
        [Parameter]
        public IReference PortalTargetBodyRef { get; set; }

        /// <summary>
        /// Reference attached to the container element of the popover.
        /// </summary>
        [Parameter]
        public IReference ContainerRef { set; get; } = new Reference();

        /// <summary>
        /// Reference attached to the anchor element of the popover.
        /// </summary>
        [Parameter]
        public IReference AnchorRef { get; set; } = new Reference();

        /// <summary>
        /// Reference attached to the content element of the popover.
        /// </summary>
        [Parameter]
        public IReference ContentAnchorRef { get; set; } = new Reference();

        /// <summary>
        /// The elevation of the popover.
        /// </summary>
        [Parameter]
        public int Elevation { set; get; } = 8;

        /// <summary>
        /// If <c>true</c>, rounded corners are disabled.
        /// </summary>
        [Parameter]
        public bool Square { set; get; } = true;

        /// <summary>
        /// If <c>true</c>, the popover is visible.
        /// </summary>
        [Parameter]
        public bool Open { set; get; }

        /// <summary>
        /// If <c>true</c>, the backdrop is invisible.
        /// It can be used when rendering a popover or a custom select component.
        /// </summary>
        [Parameter]
        public bool BackdropInvisible { set; get; } = true;

        /// <summary>
        /// popover transition duration.
        /// </summary>
        [Parameter]
        public int? TransitionDuration { set; get; }

        /// <summary>
        /// popover appear timeout.
        /// </summary>
        [Parameter]
        public int? AppearTimeout { set; get; }

        /// <summary>
        /// popover enter timeout.
        /// </summary>
        [Parameter]
        public int? EnterTimeout { set; get; }

        /// <summary>
        /// popover exit timeout.
        /// </summary>
        [Parameter]
        public int? ExitTimeout { set; get; }

        /// <summary>
        /// By default the child component is mounted immediately along with
        /// the parent <c>Transition</c> component. If you want to "lazy mount" the component on the
        /// first <c>In="true"</c> you can set <c>MountOnEnter</c>. After the first enter transition the component will stay
        /// mounted, even on "exited", unless you also specify <c>UnmountOnExit</c>.
        /// </summary>
        [Parameter]
        public bool MountOnEnter { set; get; }

        /// <summary>
        /// By default the child component stays mounted after it reaches the <c>'exited'</c> state.
        /// Set <c>UnmountOnExit</c> if you'd prefer to unmount the component after it finishes exiting.
        /// </summary>
        [Parameter]
        public bool UnmountOnExit { set; get; }

        /// <summary>
        /// Callback fired before the Ppopover enters.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEnter { set; get; }

        /// <summary>
        /// Callback fired when the Ppopover is entering.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEntering { set; get; }

        /// <summary>
        /// Callback fired when the Ppopover has entered.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEntered { set; get; }

        /// <summary>
        /// Callback fired before the Ppopover exits.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExit { set; get; }

        /// <summary>
        /// Callback fired when the Ppopover is exiting.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExiting { set; get; }

        /// <summary>
        /// Callback fired when the Ppopover has exited.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExited { set; get; }

        [Parameter]
        public Action OnClose { set; get; }

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
        /// Specifies how close to the edge of the window the popover can appear.
        /// </summary>
        [Parameter]
        public double MarginThreshold { set; get; } = 16;

        /// <summary>
        /// This is the horizontal point on the anchor where the popover's
        /// <c>AnchorRef</c> will attach to. This is not used when the
        /// AnchorType is 'AnchorType.Location'.
        /// </summary>
        [Parameter]
        public HorizontalOrigin AnchorHorizontalOrigin { set; get; } = HorizontalOrigin.Left;

        /// <summary>
        /// This is the vertical point on the anchor where the popover's
        /// <c>AnchorRef</c> will attach to. This is not used when the
        /// AnchorType is 'AnchorType.Location'.
        /// </summary>
        [Parameter]
        public VerticalOrigin AnchorVerticalOrigin { set; get; } = VerticalOrigin.Top;

        /// <summary>
        /// This is the position that may be to set the horizontal position of the popover.
        /// The coordinates are relative to the application's client area.
        /// </summary>
        [Parameter]
        public double? AnchorHorizontalOriginValue { set; get; }

        /// <summary>
        /// This is the position that may be to set the vertical position of the popover.
        /// The coordinates are relative to the application's client area.
        /// </summary>
        [Parameter]
        public double? AnchorVerticalOriginValue { set; get; }

        /// <summary>
        /// This is the point on the popover which will attach to the anchor's horizontal origin.
        /// </summary>
        [Parameter]
        public HorizontalOrigin TransformHorizontalOrigin { set; get; } = HorizontalOrigin.Left;

        /// <summary>
        /// This is the point on the popover which will attach to the anchor's vertical origin.
        /// </summary>
        [Parameter]
        public VerticalOrigin TransformVerticalOrigin { set; get; } = VerticalOrigin.Top;

        /// <summary>
        /// This is the point on the popover which will attach to the anchor's horizontal origin.
        /// </summary>
        [Parameter]
        public double? TransformHorizontalOriginValue { set; get; }

        /// <summary>
        /// This is the point on the popover which will attach to the anchor's vertical origin.
        /// </summary>
        [Parameter]
        public double? TransformVerticalOriginValue { set; get; }

        /// <summary>
        /// This is the position that may be used
        /// to set the left position of the popover.
        /// The coordinates are relative to
        /// the application's client area.
        /// </summary>
        [Parameter]
        public double AnchorLeft { set; get; }

        /// <summary>
        /// This is the position that may be used
        /// to set the top position of the popover.
        /// The coordinates are relative to
        /// the application's client area.
        /// </summary>
        [Parameter]
        public double AnchorTop { set; get; }

        /// <summary>
        /// This determines which anchor prop to refer to to setvthe position of the popover.
        /// </summary>
        [Parameter]
        public AnchorType AnchorType { set; get; } = AnchorType.Element;

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
        /// If <c>true</c>, positions the modal absolute to tha relative parent.
        /// </summary>
        [Parameter]
        public bool Absolute { set; get; }

        /// <summary>
        /// Callback fired when the backdrop is clicked.
        /// </summary>
        [Parameter]
        public Action OnBackdropClick { set; get; }

        /// <summary>
        /// Callback fired when the escape key is pressed,
        /// <c>DisableEscapeKeyDown</c> is false and the modal is in focus.
        /// </summary>
        [Parameter]
        public Action OnEscapeKeyDown { set; get; }

        protected IReference PaperRef { get; set; } = new Reference();

        public Action<IReference, bool> CreateOnEnter(Action<IReference, bool> onEnter)
        {
            return (IReference reference, bool appearing) =>
            {
                _ = SetPositioningStylesAsync(reference.Current);
                onEnter?.Invoke(reference, appearing);
                OnEnter?.Invoke(reference, appearing);
            };
        }

        public Action<IReference> CreateOnExited(Action<IReference> onExited)
        {
            return (IReference reference) =>
            {
                onExited?.Invoke(reference);
                OnExited?.Invoke(reference);
            };
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

        protected void HandleClose(ModalCloseReason reason)
        {
            OnClose?.Invoke();
        }

        protected void HandleEscapeKeyDown()
        {
            OnEscapeKeyDown?.Invoke();
        }

        protected void HandleEntering(IReference refback, bool appearing)
        {
            OnEntering?.Invoke(refback, appearing);

            // _ = SetPositioningStylesAsync(refback.Current);
        }

        protected void HandleEntered(IReference refback, bool appeared)
        {
            OnEntered?.Invoke(refback, appeared);
        }

        protected void HandleExit(IReference refback)
        {
            OnExit?.Invoke(refback);
        }

        protected void HandleExiting(IReference refback)
        {
            OnExiting?.Invoke(refback);
        }

        protected async Task<double> GetContentAnchorOffsetAsync(ElementReference? element)
        {
            if (AnchorType == AnchorType.Element && ContentAnchorRef.Current.HasValue)
            {
                return await PopoverHelper.GetContentAnchorOffsetAsync(ContentAnchorRef.Current, element);
            }

            return 0;
        }

        protected async Task<Location> GetAnchorOffsetAsync(double contentAnchorOffset)
        {
            if (AnchorType == AnchorType.Location)
            {
                return new Location
                {
                    Left = AnchorLeft,

                    Top = AnchorTop
                };
            }

            var anchorBoundry = await PopoverHelper.GetAnchorBoundryAsync(AnchorRef.Current, PaperRef.Current);

            VerticalOrigin anchorVertical = contentAnchorOffset == 0 ? AnchorVerticalOrigin : VerticalOrigin.Center;

            return new Location
            {
                Top = anchorBoundry.Top + GetOffsetTop(anchorBoundry, AnchorVerticalOriginValue, anchorVertical),

                Left = anchorBoundry.Left + GetOffsetLeft(anchorBoundry, AnchorHorizontalOriginValue, AnchorHorizontalOrigin)
            };
        }

        public (double vertical, double horizontal) GetTransformOrigin(Boundry rect, double contentAnchorOffset)
        {
            double vertical = GetOffsetTop(rect, TransformVerticalOriginValue, TransformVerticalOrigin);

            double horizontal = GetOffsetLeft(rect, TransformHorizontalOriginValue, TransformHorizontalOrigin);

            return (vertical, horizontal);
        }

        public async Task<IDictionary<string, object>> GetPositioningStylesAsync(ElementReference? element)
        {
            IDictionary<string, object> styles = new Dictionary<string, object>();

            var contentAnchorOffset = await GetContentAnchorOffsetAsync(element);

            var elementRect = await PopoverHelper.GetOffsetAsync(element);

            (double vertical, double horizontal) = GetTransformOrigin(elementRect, contentAnchorOffset);

            if (AnchorType == AnchorType.None)
            {
                styles.Add("transform-origin", $"{horizontal.ToString(CultureInfo.InvariantCulture)}px {vertical.ToString(CultureInfo.InvariantCulture)}px");
            }
            else
            {
                var anchorOffset = await GetAnchorOffsetAsync(contentAnchorOffset);

                // Calculate element positioning
                var top = anchorOffset.Top - vertical;
                var left = anchorOffset.Left - horizontal;
                var bottom = top + elementRect.Height;
                var right = left + elementRect.Width;

                var windowOffset = await PopoverHelper.GetWindowOffsetAsync(AnchorRef.Current);

                var heightThreshold = windowOffset.Height - MarginThreshold;
                var widthThreshold = windowOffset.Width - MarginThreshold;

                // Check if the vertical axis needs shifting
                if (top < MarginThreshold)
                {
                    var diff = top - MarginThreshold;
                    top -= diff;
                    vertical += diff;
                }
                else if (bottom > heightThreshold)
                {
                    var diff = bottom - heightThreshold;
                    top -= diff;
                    vertical += diff;
                }

                // Check if the horizontal axis needs shifting
                if (left < MarginThreshold)
                {
                    var diff = left - MarginThreshold;
                    left -= diff;
                    horizontal += diff;
                }
                else if (right > widthThreshold)
                {
                    var diff = right - widthThreshold;
                    left -= diff;
                    horizontal += diff;
                }

                styles.Add("top", $"{top.ToString(CultureInfo.InvariantCulture)}px");
                styles.Add("left", $"{left.ToString(CultureInfo.InvariantCulture)}px");
                styles.Add("transform-origin", $"{horizontal.ToString(CultureInfo.InvariantCulture)}px {vertical.ToString(CultureInfo.InvariantCulture)}px");
            }

            return styles;
        }

        public async Task SetPositioningStylesAsync(ElementReference? element)
        {
            var styles = await GetPositioningStylesAsync(element);

            await PopoverHelper.SetPositioningStylesAsync(element, styles, trigger: true);
        }

        public static double GetOffsetTop(Boundry rect, double? verticalValue, VerticalOrigin verticalOrigin)
        {
            double offset = 0;
            if (verticalValue.HasValue)
            {
                offset = verticalValue.Value;
            }
            else if (verticalOrigin == VerticalOrigin.Center)
            {
                offset = rect.Height / 2;
            }
            else if (verticalOrigin == VerticalOrigin.Bottom)
            {
                offset = rect.Height;
            }
            return offset;
        }

        public static double GetOffsetLeft(Boundry rect, double? horizontalValue, HorizontalOrigin horizontalOrigin)
        {
            double offset = 0;
            if (horizontalValue.HasValue)
            {
                offset = horizontalValue.Value;
            }
            else if (horizontalOrigin == HorizontalOrigin.Center)
            {
                offset = rect.Width / 2;
            }
            else if (horizontalOrigin == HorizontalOrigin.Right)
            {
                offset = rect.Width;
            }
            return offset;
        }

        private void OnWindowResize(object sender, string e)
        {
            _ = SetPositioningStylesAsync(PaperRef.Current);
        }

        protected override async Task OnAfterMountAsync()
        {
            await base.OnAfterMountAsync();

            EventDelegator.OnEvent += OnWindowResize;

            await EventDelegator.RegisterAsync(default(ElementReference), "resize", 200);
        }

        protected override void Dispose()
        {
            base.Dispose();

            EventDelegator.OnEvent -= OnWindowResize;

            EventDelegator.Dispose();
        }
    }
}
