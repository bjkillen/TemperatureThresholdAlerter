using System;

namespace TemperatureThresholdAlerter.Models
{
    public class ThermometerThresholdAlerter
    {
        public ThermometerThresholdAlerter(TemperatureThresholdsResult thresholds)
        {
            Thresholds = thresholds;
        }

        private TemperatureThresholdsResult Thresholds { get; set; }

        public void Validate()
        {
            var invalidInputExceptions = new List<Exception>();

            if (Thresholds.BoilingPointThreshold == null)
            {
                invalidInputExceptions.Add(new InvalidBoilingPointException());
            }

            if (Thresholds.FreezingPointThreshold == null)
            {
                invalidInputExceptions.Add(new InvalidFreezingPointException());
            }

            if (invalidInputExceptions.Count > 0)
            {
                throw new AggregateException(invalidInputExceptions);
            }

            if (Thresholds.BoilingPointThreshold <= this.Thresholds.FreezingPointThreshold)
            {
                throw new BoilingPointMustBeAboveFreezingException
                    (this.Thresholds.BoilingPointThreshold,
                    this.Thresholds.FreezingPointThreshold);
            }
        }

        public TemperatureThresholdCheckResult CheckThresholds(float temperature)
        {
            if (temperature >= this.Thresholds.BoilingPointThreshold)
            {
                return new(TemperatureThresholdCheckResultEnum.BoilingPointReachedOrExceeded);
            }
            else if (temperature <= this.Thresholds.FreezingPointThreshold)
            {
                return new(TemperatureThresholdCheckResultEnum.FreezingPointReachedOrSubceeded);
            }

            return new(TemperatureThresholdCheckResultEnum.InBetweenBoilingAndFreezingPoints);
        }

        public void UpdateThresholds(TemperatureThresholdsResult newThresholds)
        {
            Thresholds = newThresholds;
        }
    }
}
