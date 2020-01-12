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
    public class GrowComponent : MaterialComponentBase
    {
        [Inject]
        public DomHelpers DomHelpers { set; get; }

        public GrowComponent() : base("Grow")
        {
        }

        [Parameter]
        public bool In { set; get; }

        [Parameter]
        public RenderFragment<ITransitionContext> ChildContent { get; set; }

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
        public int? TransitionDuration { set; get; }

        [Parameter]
        public int TransitionDelay { set; get; }

        [Parameter]
        public int Timeout { set; get; } = 225;

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

        protected void HandleEnter(IReference refback, bool appear)
        {
            _ = HandleEnterAsync(refback, appear);
        }

        protected async Task HandleEnterAsync(IReference refback, bool appear)
        {
            var transition = GetTransition(GetEnterDuration(), TransitionDelay);

            var styles = new Dictionary<string, object>
            {
                { "opacity", 1 },
                { "transition", transition },
                { "webkitTransition", transition }
            };

            await DomHelpers.SetStyleAsync(refback.Current, styles, trigger: true);

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
            _ = HandleExitAsync(refback);
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
