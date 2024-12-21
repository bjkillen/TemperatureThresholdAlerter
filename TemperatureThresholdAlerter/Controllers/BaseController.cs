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

        private static readonly float TemperatureChangeInsignifiganceThreshold = 0.5f;

        public TemperatureThresholdCheckResult? CheckThresholds(float inputTemperature)
        {
            var temperatureThresholdResult = TemperatureThresholdAlerter.CheckThresholds(inputTemperature);

            var previousResult = PreviousResult;
            PreviousResult = temperatureThresholdResult;

            if (AlertOnlyWhenChangeIsSignificant && temperatureThresholdResult != previousResult)
            {
                if (temperatureThresholdResult.Result == TemperatureThresholdCheckResultEnum.BoilingPointReachedOrExceeded)
                {
                    TemperatureThresholdAlerter.UpdateThresholds(
                        new TemperatureThresholdsResult(
                            Thresholds.BoilingPointThreshold - TemperatureChangeInsignifiganceThreshold,
                            Thresholds.FreezingPointThreshold
                        )
                    );
                }
                else if (temperatureThresholdResult.Result == TemperatureThresholdCheckResultEnum.FreezingPointReachedOrSubceeded)
                {
                    TemperatureThresholdAlerter.UpdateThresholds(
                        new TemperatureThresholdsResult(
                            Thresholds.BoilingPointThreshold,
                            Thresholds.FreezingPointThreshold + TemperatureChangeInsignifiganceThreshold
                            
                        )
                    );
                }
                else if (temperatureThresholdResult.Result == TemperatureThresholdCheckResultEnum.InBetweenBoilingAndFreezingPoints)
                {
                    TemperatureThresholdAlerter.UpdateThresholds(
                        new TemperatureThresholdsResult(
                            Thresholds.BoilingPointThreshold,
                            Thresholds.FreezingPointThreshold

                        )
                    );
                }
            }

            if (temperatureThresholdResult.Result != TemperatureThresholdCheckResultEnum.InBetweenBoilingAndFreezingPoints &&
                temperatureThresholdResult == previousResult &&
                AlertOnlyWhenTempEntersFromOutsideThresholds
            ) {
                return null;
            }

            return temperatureThresholdResult;
        }
    }
}

