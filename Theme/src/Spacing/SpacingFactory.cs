using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public static class SpacingFactory
    {
        public static Spacing CreateSpacing(SpacingConfig config)
        {
            var input = config?.Input ?? 8;

            var unit = config?.Unit ?? "px";

            var transform = config?.Transform;

            var spacing = transform != null ? new Spacing(transform, unit) : new Spacing(input, unit);

            return spacing;
        }
    }
}