using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        [Parameter]
        public IReference ContainerRef { set; get; } = new Reference();

        [Parameter]
        public IReference AnchorRef { get; set; } = new Reference();

        [Parameter]
        public IReference ContentAnchorRef { get; set; } = new Reference();

        [Parameter]
        public int Elevation { set; get; } = 8;

        [Parameter]
        public bool Square { set; get; } = true;

        [Parameter]
        public bool Open { set; get; }

        [Parameter]
        public bool BackdropInvisible { set; get; } = true;

        [Parameter]
        public int? TransitionDuration { set; get; }

        [Parameter]
        public int? AppearTimeout { set; get; }

        [Parameter]
        public int? EnterTimeout { set; get; }

        [Parameter]
        public int? ExitTimeout { set; get; }

        [Parameter]
        public bool MountOnEnter { set; get; }

        [Parameter]
        public bool UnmountOnExit { set; get; }

        [Parameter]
        public Action<IReference, bool> OnEnter { set; get; }

        [Parameter]
        public Action<IReference, bool> OnEntering { set; get; }

        [Parameter]
        public Action<IReference, bool> OnEntered { set; get; }

        [Parameter]
        public Action<IReference> OnExit { set; get; }

        [Parameter]
        public Action<IReference> OnExiting { set; get; }

        [Parameter]
        public Action<IReference> OnExited { set; get; }

        [Parameter]
        public Action OnClose { set; get; }

        [Parameter]
        public string PaperClass { set; get; }

        [Parameter]
        public string PaperStyle { set; get; }

        [Parameter]
        public double MarginThreshold { set; get; } = 16;

        [Parameter]
        public HorizontalOrigin AnchorHorizontalOrigin { set; get; } = HorizontalOrigin.Left;

        [Parameter]
        public VerticalOrigin AnchorVerticalOrigin { set; get; } = VerticalOrigin.Top;

        [Parameter]
        public double? AnchorHorizontalOriginValue { set; get; }

        [Parameter]
        public double? AnchorVerticalOriginValue { set; get; }

        [Parameter]
        public HorizontalOrigin TransformHorizontalOrigin { set; get; } = HorizontalOrigin.Left;

        [Parameter]
        public VerticalOrigin TransformVerticalOrigin { set; get; } = VerticalOrigin.Top;

        [Parameter]
        public double? TransformHorizontalOriginValue { set; get; }

        [Parameter]
        public double? TransformVerticalOriginValue { set; get; }

        [Parameter]
        public double AnchorLeft { set; get; }

        [Parameter]
        public double AnchorTop { set; get; }

        [Parameter]
        public AnchorType AnchorType { set; get; } = AnchorType.Element;

        [Parameter]
        public Action OnBackdropClick { set; get; }

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
                styles.Add("transform-origin", $"{horizontal}px {vertical}px");
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

                styles.Add("top", $"{top}px");
                styles.Add("left", $"{left}px");
                styles.Add("transform-origin", $"{horizontal}px {vertical}px");
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
