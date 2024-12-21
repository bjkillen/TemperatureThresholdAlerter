using System;

namespace TemperatureThresholdAlerter.Extensions
{
    public static class FloatExtensions
    {
        public static float? TryParse(this string? Source)
        {
            if (float.TryParse(Source, out float result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
