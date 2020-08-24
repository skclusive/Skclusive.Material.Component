using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Skclusive.Material.Theme
{
    public static class ShapeFactory
    {
        public static Shape CreateShape(ShapeConfig config)
        {
           return new Shape
            {
                BorderRadius = config?.BorderRadius ?? 4
            };
        }
    }
}