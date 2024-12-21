using System;

namespace TemperatureThresholdAlerter.Models
{
    public enum TemperatureThresholdCheckResultEnum
    {
        BoilingPointReachedOrExceeded,
        FreezingPointReachedOrSubceeded,
        InBetweenBoilingAndFreezingPoints
    }

    public struct TemperatureThresholdCheckResult
    {
        public TemperatureThresholdCheckResult(TemperatureThresholdCheckResultEnum result)
        {
            Result = result;
        }

        private TemperatureThresholdCheckResultEnum Result { get; set; }

        public readonly string Message()
        {
            return Result switch
            {
                TemperatureThresholdCheckResultEnum.BoilingPointReachedOrExceeded => "Temperature is at or above boiling point",
                TemperatureThresholdCheckResultEnum.FreezingPointReachedOrSubceeded => "Temperature is at or below freezing point",
                _ => "Temperature is between boiling and freezing points",
            };
        }
    }
}

