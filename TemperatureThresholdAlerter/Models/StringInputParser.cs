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
            return FloatExtensions.TryParse(inputText);
        }
    }
}

