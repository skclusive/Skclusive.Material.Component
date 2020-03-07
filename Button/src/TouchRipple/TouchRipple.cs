using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Skclusive.Material.Core;
using Skclusive.Transition.Component;
using System;
using System.Linq;
using Skclusive.Core.Component;

namespace Skclusive.Material.Button
{
    public class TouchPoint
    {
        public bool IsTouch { set; get; }

        public double? ClientX { set; get; }

        public double? ClientY { set; get; }
    }

    public class TouchRippleComponent : MaterialComponentBase
    {
        public TouchRippleComponent() : base("TouchRipple")
        {
        }

        /// <summary>
        /// If <c>true</c>, the ripple starts at the center of the component
        /// rather than at the point of interaction.
        /// </summary>
        [Parameter]
        public bool Center { set; get; }

        public List<ITransitionItem> Ripples { set; get; } = new List<ITransitionItem>();

        private readonly static int DURATION = 550;

        private int NextKey = 0;

        // private readonly static int DELAY_RIPPLE = 80;

        public void StartRipple(bool pulsate, double rippleX, double rippleY, double rippleSize)
        {
            Ripples.Add(
                new TransitionItemBuilder()
                .WithKey(NextKey++)
                .WithName($"T{NextKey}")
                .WithTemplate(CreateRipple(pulsate, rippleX, rippleY, rippleSize))
                .Build()
            );

            StateHasChanged();
        }

        public void Stop()
        {
            RunTimeout(() =>
            {
                if (Ripples.Count > 0)
                {
                    Ripples = Ripples.Skip(1).ToList();

                    StateHasChanged();
                }
            }, 200);
        }

        public void Pulsate(TouchPoint point, Boundry boundry)
        {
            Start(true, null, point, boundry);
        }

        public void Start(bool? opulsate, bool? ocenter, TouchPoint point, Boundry boundry)
        {
            var pulsate = opulsate ?? false;
            var center = ocenter ?? (Center || pulsate);

            double rippleX, rippleY, rippleSize;

            double? clientX = point.ClientX;
            double? clientY = point.ClientY;

            if (center || (clientX is null || clientX.Value == 0) || !point.IsTouch)
            {
                rippleX = boundry.Width / 2;
                rippleY = boundry.Height / 2;
            }
            else
            {
                rippleX = clientX.Value - boundry.Left;
                rippleY = clientY.Value - boundry.Top;
            }

            if (center)
            {
                rippleSize = (int)Math.Sqrt((Math.Pow(2 * boundry.Width, 2) + Math.Pow(boundry.Height, 2)) / 3);

                // For some reason the animation is broken on Mobile Chrome if the size if even.
                if (rippleSize % 2 == 0)
                {
                    rippleSize += 1;
                }
            }
            else
            {
                double sizeX =
                  Math.Max(Math.Abs(boundry.Width - rippleX), rippleX) * 2 + 2;
                double sizeY =
                  Math.Max(Math.Abs(boundry.Height - rippleY), rippleY) * 2 + 2;

                rippleSize = Math.Sqrt(Math.Pow(sizeX, 2) + Math.Pow(sizeY, 2));
            }

            StartRipple(pulsate, rippleX, rippleY, rippleSize);
        }

        private RenderFragment<ITransitionItemContext> CreateRipple(bool pulsate, double rippleX, double rippleY, double rippleSize) => ((context) =>
            (builder) =>
            {
                builder.OpenRegion(context.Key);
                builder.OpenComponent<Ripple>(context.Key + 1);
                builder.AddAttribute(context.Key + 2, "In", context.In);
                builder.AddAttribute(context.Key + 3, "OnExited", context.OnExited);
                builder.AddAttribute(context.Key + 4, "Timeout", DURATION);
                builder.AddAttribute(context.Key + 5, "Pulsate", pulsate);
                builder.AddAttribute(context.Key + 6, "RippleX", rippleX);
                builder.AddAttribute(context.Key + 7, "RippleY", rippleY);
                builder.AddAttribute(context.Key + 8, "RippleSize", rippleSize);
                builder.SetKey(context.Name);
                builder.CloseComponent();
                builder.CloseRegion();
            });
    }
}
