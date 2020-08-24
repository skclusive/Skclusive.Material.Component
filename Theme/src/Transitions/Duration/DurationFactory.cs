using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public class DurationFactory
    {
        public static Duration CreateDuration(DurationConfig config)
        {
            var duration = new Duration
            {
                Shortest = config?.Shortest ?? 150,

                Shorter = config?.Shorter ?? 200,

                Short = config?.Short ?? 250,

                Standard = config?.Standard ?? 300,

                Complex = config?.Complex ?? 375,

                EnteringScreen = config?.EnteringScreen ?? 225,

                LeavingScreen = config?.LeavingScreen ?? 195,
            };

            return duration;
        }
    }
}