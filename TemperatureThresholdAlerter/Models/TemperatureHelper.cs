using System;
namespace TemperatureThresholdAlerter.Models
{
    public static class TemperatureHelper
    {
        private static readonly float celsiusConversionConstant = (float)(5.0 / 9.0);

        public static float ConvertToCelsius(float temperature)
        {
            return (temperature - 32) * celsiusConversionConstant;
        }
    }
}

