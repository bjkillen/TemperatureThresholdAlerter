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

        public String Message()
        {
            switch (this.Result)
            {
                case TemperatureThresholdCheckResultEnum.BoilingPointReachedOrExceeded:
                    return "Temperature is at or above boiling point";
                case TemperatureThresholdCheckResultEnum.FreezingPointReachedOrSubceeded:
                    return "Temperature is at or below freezing point";
                default:
                    return "Temperature is between boiling and freezing points";
            }
        }
    }
}

