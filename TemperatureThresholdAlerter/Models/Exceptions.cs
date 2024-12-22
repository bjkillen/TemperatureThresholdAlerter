using System;

namespace TemperatureThresholdAlerter.Models
{
    public class BoilingPointMustBeAboveFreezingException : Exception
    {
        public BoilingPointMustBeAboveFreezingException(float? boilingPoint, float? freezingPoint)
            : base($"Boiling point must be above freezing point. " +
                  $"Boiling point: {boilingPoint}, Freezing point: {freezingPoint}")
        {
        }
    }

    public class InvalidBoilingPointException : Exception
    {
        public InvalidBoilingPointException()
            : base($"Invalid boiling point provided")
        {
        }
    }

    public class InvalidFreezingPointException : Exception
    {
        public InvalidFreezingPointException()
            : base($"Invalid freezing point provided")
        {
        }
    }
}

