using System;

namespace TemperatureThresholdAlerter.Models
{
    enum TemperatureThresholdCheckResult
    {
        BoilingPointReachedOrExceeded,
        FreezingPointReachedOrSubceeded,
        InBetweenBoilingAndFreezingPoints,
        NoChangeFromPrevious
    }
}

