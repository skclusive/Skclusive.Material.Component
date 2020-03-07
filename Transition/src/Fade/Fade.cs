using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Transition.Component;
using Skclusive.Script.DomHelpers;
using System;
using System.Collections.Generic;
using static Skclusive.Material.Transition.TransitionUtil;

namespace Skclusive.Material.Transition
{
    public class FadeComponent : MaterialComponentBase
    {
        [Inject]
        public DomHelpers DomHelpers { set; get; }

        public FadeComponent() : base("Fade")
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
        public Action<IReference, bool> OnEnter { set; get; }

        /// <summary>
        /// Callback fired when the Menu is entering.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEntering { set; get; }

        /// <summary>
        /// Callback fired when the Menu has entered.
        /// </summary>
        [Parameter]
        public Action<IReference, bool> OnEntered { set; get; }

        /// <summary>
        /// Callback fired before the Menu exits.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExit { set; get; }

        /// <summary>
        /// Callback fired when the Menu is exiting.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExiting { set; get; }

        /// <summary>
        /// Callback fired when the Menu has exited.
        /// </summary>
        [Parameter]
        public Action<IReference> OnExited { set; get; }

        /// <summary>
        /// fade transition duration.
        /// </summary>
        [Parameter]
        public int? TransitionDuration { set; get; }

        /// <summary>
        /// fade transition delay.
        /// </summary>
        [Parameter]
        public int TransitionDelay { set; get; }

        /// <summary>
        /// fade transition timeout.
        /// </summary>
        [Parameter]
        public int Timeout { set; get; } = 225;

        /// <summary>
        /// fade appear timeout.
        /// </summary>
        [Parameter]
        public int? AppearTimeout { set; get; }

        /// <summary>
        /// fade enter timeout.
        /// </summary>
        [Parameter]
        public int? EnterTimeout { set; get; }

        /// <summary>
        /// fade exit timeout.
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

        protected IEnumerable<Tuple<string, object>> GetChildStyles(ITransitionContext context)
        {
            var opacity = context.State == TransitionState.Entering || context.State == TransitionState.Entered ? 1 : 0;

            yield return Tuple.Create<string, object>("opacity", opacity);

            yield return Tuple.Create<string, object>("visibility", context.State == TransitionState.Exited && !In ? "hidden" : "default");

            string transition = null;

            if (context.State == TransitionState.Entering)
            {
                transition = GetTransition(GetEnterDuration(), TransitionDelay);
            }
            else if (context.State == TransitionState.Exiting)
            {
                transition = GetTransition(GetExitDuration(), TransitionDelay);
            }

            if (!string.IsNullOrWhiteSpace(transition))
            {
                yield return Tuple.Create<string, object>("transition", transition);

                yield return Tuple.Create<string, object>("-webkit-transition", transition);
            }
        }

        protected ITransitionContext GetChildContext(ITransitionContext context)
        {
            return new TransitionContextBuilder()
            .With(context)
            .WithStyles(GetChildStyles(context))
            .Build();
        }

        protected void HandleEnter(IReference refback, bool appear)
        {
            //SetTransition(refback, GetEnterDuration(), TransitionDelay);

            OnEnter?.Invoke(refback, appear);
        }

        protected void HandleEntering(IReference refback, bool appearing)
        {
            OnEntering?.Invoke(refback, appearing);
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

        protected void HandleExited(IReference refback)
        {
            OnExited?.Invoke(refback);
        }

        protected string GetTransition(int duration, int delay)
        {
            return CreateTransition("opacity", duration, delay, TransitionEasing.EasingSharp);
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
