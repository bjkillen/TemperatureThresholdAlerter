﻿using System;
using TemperatureThresholdAlerter.Models;

namespace TemperatureThresholdAlerter.Controllers
{
    public class BaseController
    {
        public BaseController(
            ThermometerThresholdAlerter temperatureThresholdAlerter)
        {
            TemperatureThresholdAlerter = temperatureThresholdAlerter;
        }

        private ThermometerThresholdAlerter TemperatureThresholdAlerter { get; set; }

        public TemperatureThresholdCheckResult CheckThresholds(string? inputText)
        {

        }
    }
}
