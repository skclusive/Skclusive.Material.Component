using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Transition.Component;
using Skclusive.Script.DomHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Skclusive.Material.Transition.TransitionUtil;

namespace Skclusive.Material.Transition
{
    public partial class Grow : MaterialComponentBase
    {
        [Inject]
        public DomHelpers DomHelpers { set; get; }

        public Grow() : base("Grow")
        {
        }

        /// <summary>
        /// If <c>true</c>, show the component; triggers the enter or exit animation.
        /// </summary>
        [Parameter]
        public bool In { set; get; }

        /// <summary>
        /// ChildContent of the current component which gets component <see cref="ITransitionContext" />.
        /// </summary>
        [Parameter]
        public RenderFragment<ITransitionContext> ChildContent { get; set; }

        /// <summary>
        /// Callback fired before the Menu enters.
        /// </summary>
        [Parameter]
        public EventCallback<(IReference, bool)> OnEnter { set; get; }

        /// <summary>
        /// Callback fired when the Menu is entering.
        /// </summary>
        [Parameter]
        public EventCallback<(IReference, bool)> OnEntering { set; get; }

        /// <summary>
        /// Callback fired when the Menu has entered.
        /// </summary>
        [Parameter]
        public EventCallback<(IReference, bool)> OnEntered { set; get; }

        /// <summary>
        /// Callback fired before the Menu exits.
        /// </summary>
        [Parameter]
        public EventCallback<IReference> OnExit { set; get; }

        /// <summary>
        /// Callback fired when the Menu is exiting.
        /// </summary>
        [Parameter]
        public EventCallback<IReference> OnExiting { set; get; }

        /// <summary>
        /// Callback fired when the Menu has exited.
        /// </summary>
        [Parameter]
        public EventCallback<IReference> OnExited { set; get; }

        /// <summary>
        /// grow transition duration.
        /// </summary>
        [Parameter]
        public int? TransitionDuration { set; get; }

        /// <summary>
        /// grow transition delay.
        /// </summary>
        [Parameter]
        public int TransitionDelay { set; get; }

        /// <summary>
        /// grow transition timeout.
        /// </summary>
        [Parameter]
        public int Timeout { set; get; } = 225;

        /// <summary>
        /// grow appear timeout.
        /// </summary>
        [Parameter]
        public int? AppearTimeout { set; get; }

        /// <summary>
        /// grow enter timeout.
        /// </summary>
        [Parameter]
        public int? EnterTimeout { set; get; }

        /// <summary>
        /// grow exit timeout.
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

        protected int GetEnterDuration()
        {
            int duration;

            if (TransitionDuration.HasValue)
            {
                duration = TransitionDuration.Value;
            }
            else if (EnterTimeout.HasValue)
            {
                duration = EnterTimeout.Value;
            }
            else
            {
                duration = Timeout;
            }

            return duration;
        }

        protected int GetExitDuration()
        {
            int duration;

            if (TransitionDuration.HasValue)
            {
                duration = TransitionDuration.Value;
            }
            else if (ExitTimeout.HasValue)
            {
                duration = ExitTimeout.Value;
            }
            else
            {
                duration = Timeout;
            }

            return duration;
        }

        private static string ToScale(double value) => $"scale({value}, {Math.Pow(value, 2)})";

        protected IEnumerable<Tuple<string, object>> GetChildStyles(ITransitionContext context)
        {
            var opacity = context.State == TransitionState.Entering || context.State == TransitionState.Entered ? 1 : 0;

            yield return Tuple.Create<string, object>("opacity", opacity);

            yield return Tuple.Create<string, object>("visibility", context.State == TransitionState.Exited && !In ? "hidden" : "default");

            if (context.State == TransitionState.Entering)
            {
                yield return Tuple.Create<string, object>("transform", ToScale(1));
            }
            else if (context.State == TransitionState.Entered)
            {
                yield return Tuple.Create<string, object>("transform", "none");
            }
            else
            {
                yield return Tuple.Create<string, object>("transform", ToScale(0.75));
            }
        }

        protected ITransitionContext GetChildContext(ITransitionContext context)
        {
            return new TransitionContextBuilder()
            .With(context)
            .WithStyles(GetChildStyles(context))
            .Build();
        }

        protected async Task HandleEnterAsync((IReference, bool) args)
        {
            (IReference refback, bool appear) = args;

            var transition = GetTransition(GetEnterDuration(), TransitionDelay);

            var styles = new Dictionary<string, object>
            {
                { "opacity", 1 },
                { "transition", transition },
                { "webkitTransition", transition }
            };

            await DomHelpers.SetStyleAsync(refback.Current, styles, trigger: true);

            await OnEnter.InvokeAsync(args);
        }

        protected Task HandleEnteringAsync((IReference, bool) args)
        {
            return OnEntering.InvokeAsync(args);
        }

        protected Task HandleEnteredAsync((IReference, bool) args)
        {
            return OnEntered.InvokeAsync(args);
        }

        protected async Task HandleExitAsync(IReference refback)
        {
            var transition = GetTransition(GetExitDuration(), TransitionDelay);

            var styles = new Dictionary<string, object>
            {
                { "opacity", 0 },
                { "transform", ToScale(0.75) },
                { "transition", transition },
                { "webkitTransition", transition }
            };

            await DomHelpers.SetStyleAsync(refback.Current, styles, trigger: true);

            await OnExit.InvokeAsync(refback);
        }

        protected Task HandleExitingAsync(IReference refback)
        {
            return OnExiting.InvokeAsync(refback);
        }

        protected Task HandleExitedAsync(IReference refback)
        {
            return OnExited.InvokeAsync(refback);
        }

        protected string GetTransition(int duration, int delay)
        {
            var opacity = CreateTransition("opacity", duration, delay, TransitionEasing.EasingSharp);

            var transform = CreateTransition("transform", duration * 0.666, delay, TransitionEasing.EasingSharp);

            return $"{opacity},{transform}";
        }

        protected void SetTransition(IReference refback, int duration, int delay)
        {
            var transition = GetTransition(duration, delay);

            var styles = new Dictionary<string, object>
            {
                { "transition", transition },
                { "webkitTransition", transition }
            };

            SetStyle(refback, styles, true);
        }

        protected void SetStyle(IReference refback, IDictionary<string, object> styles, bool trigger = false)
        {
            _ = DomHelpers.SetStyleAsync(refback.Current, styles, trigger);
        }
    }
}
