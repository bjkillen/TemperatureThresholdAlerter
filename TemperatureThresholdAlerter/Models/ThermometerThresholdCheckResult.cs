using System;

namespace TemperatureThresholdAlerter.Models
{
    public enum TemperatureThresholdCheckResultEnum
    {
        BoilingPointReachedOrExceeded,
        FreezingPointReachedOrSubceeded,
        InBetweenBoilingAndFreezingPoints
    }

    public struct TemperatureThresholdCheckResult : IEquatable<TemperatureThresholdCheckResult>
    {
        public TemperatureThresholdCheckResult(TemperatureThresholdCheckResultEnum result)
        {
            Result = result;
        }

        public readonly TemperatureThresholdCheckResultEnum Result { get; }

        public readonly bool Equals(TemperatureThresholdCheckResult other)
        {
            return (other.Result == Result);
        }

        public override readonly bool Equals(object other)
        {
            if (other is TemperatureThresholdCheckResultEnum)
            {
                return Equals(other);
            }
            else
            {
                return false;
            }
        }

        public override readonly int GetHashCode()
        {
            return Result.GetHashCode();
        }

        public static bool operator ==(TemperatureThresholdCheckResult term1, TemperatureThresholdCheckResult term2)
        {
            return term1.Equals(term2);
        }

        public static bool operator !=(TemperatureThresholdCheckResult term1, TemperatureThresholdCheckResult term2)
        {
            return !term1.Equals(term2);
        }

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

