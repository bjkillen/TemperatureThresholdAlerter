using System;
using TemperatureThresholdAlerter.Models;

namespace TemperatureThresholdAlerter.Controllers
{
    public struct TemperatureThresholdCheckOverallResult
    {

    }

    public class BaseController
    {
        public BaseController(
            ThermometerThresholdAlerter temperatureThresholdAlerter,
            TemperatureThresholdsResult thresholds,
            bool alertOnlyWhenTempEntersFromOutsideThresholds,
            bool alertOnlyWhenChangeIsSignificant)
        {
            TemperatureThresholdAlerter = temperatureThresholdAlerter;
            Thresholds = thresholds;
            AlertOnlyWhenTempEntersFromOutsideThresholds = alertOnlyWhenTempEntersFromOutsideThresholds;
            AlertOnlyWhenChangeIsSignificant = alertOnlyWhenChangeIsSignificant;
        }

        private ThermometerThresholdAlerter TemperatureThresholdAlerter { get; set; }
        public TemperatureThresholdsResult Thresholds { get; }
        private TemperatureThresholdCheckResult PreviousResult { get; set; }

        private bool AlertOnlyWhenTempEntersFromOutsideThresholds { get; set; }
        private bool AlertOnlyWhenChangeIsSignificant { get; set; }

        private static float TemperatureChangeInsignifiganceThreshold = 0.5f;

        public TemperatureThresholdCheckResult? CheckThresholds(float inputTemperature)
        {
            var temperatureThresholdResult = TemperatureThresholdAlerter.CheckThresholds(inputTemperature);

            var previousResult = PreviousResult;
            PreviousResult = temperatureThresholdResult;

            if (AlertOnlyWhenChangeIsSignificant)
            {
                if (Thresholds.BoilingPointThreshold is not null)
                {
                    var boilingPointTemperatureDeltaAbs = Math.Abs(inputTemperature - (float)Thresholds.BoilingPointThreshold);

                    if (boilingPointTemperatureDeltaAbs <= TemperatureChangeInsignifiganceThreshold)
                    {
                        return null;
                    }
                    else
                    {
                        return temperatureThresholdResult;
                    }
                }

                if (Thresholds.FreezingPointThreshold is not null)
                {
                    var freezingPointTemperatureDeltaAbs = Math.Abs(inputTemperature - (float)Thresholds.FreezingPointThreshold);

                    if (freezingPointTemperatureDeltaAbs <= TemperatureChangeInsignifiganceThreshold)
                    {
                        return null;
                    }
                    else
                    {
                        return temperatureThresholdResult;
                    }
                }
            }

            if (temperatureThresholdResult == previousResult)
            {
                if (AlertOnlyWhenTempEntersFromOutsideThresholds)
                {
                    return null;
                } 
            }

            return temperatureThresholdResult;
        }
    }
}

