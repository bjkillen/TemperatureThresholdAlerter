using System;
using TemperatureThresholdAlerter.Extensions;

namespace TemperatureThresholdAlerter.Models
{
    public readonly struct TemperatureThresholdsResult
    {
        public TemperatureThresholdsResult()
        {
        }

        public TemperatureThresholdsResult(
            float? boilingPointThreshold,
            float? freezingPointThreshold)
        {
            BoilingPointThreshold = boilingPointThreshold;
            FreezingPointThreshold = freezingPointThreshold;
        }

        public float? BoilingPointThreshold { get; }
        public float? FreezingPointThreshold { get; }
    }

    public class StringInputParser
    {
        public static TemperatureThresholdsResult ParseThresholdsInput(
                string? boilingPointInputText, string? freezingPointInputText)
        {
            float? boilingPointParsedResult = ParseTemperatureInput(boilingPointInputText);
            float? freezingPointParsedResult = ParseTemperatureInput(freezingPointInputText);

            return new(boilingPointParsedResult, freezingPointParsedResult);
        }

        public static float? ParseTemperatureInput(string? inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return null;
            }

            var numbersMatch = RegexHelper.MatchesValidNumber(inputText);

            if (!numbersMatch.Success)
            {
                return null;
            }

            var parsedTemp = FloatExtensions.TryParse(numbersMatch.Value);

            if ((parsedTemp is not null) && (inputText?.ToLower().Contains('f') ?? false))
            {
                return TemperatureHelper.ConvertToCelsius((float)parsedTemp);
            }

            return parsedTemp;
        }
    }
}

