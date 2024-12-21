﻿using System;

namespace TemperatureThresholdAlerter.Models
{
    public class ThermometerThresholdAlerter
    {
        public ThermometerThresholdAlerter(TemperatureThresholdsResult thresholds)
        {
            Thresholds = thresholds;
        }

        public TemperatureThresholdsResult Thresholds { get; }

        public void Validate()
        {
            var invalidInputExceptions = new List<Exception>();

            if (this.Thresholds.BoilingPointThreshold == null)
            {
                invalidInputExceptions.Add(new InvalidBoilingPointException());
            }

            if (this.Thresholds.FreezingPointThreshold == null)
            {
                invalidInputExceptions.Add(new InvalidFreezingPointException());
            }

            if (invalidInputExceptions.Count > 0)
            {
                throw new AggregateException(invalidInputExceptions);
            }

            if (this.Thresholds.BoilingPointThreshold <= this.Thresholds.FreezingPointThreshold)
            {
                throw new BoilingPointMustBeAboveFreezingException
                    (this.Thresholds.BoilingPointThreshold,
                    this.Thresholds.FreezingPointThreshold);
            }
        }
    }
}
