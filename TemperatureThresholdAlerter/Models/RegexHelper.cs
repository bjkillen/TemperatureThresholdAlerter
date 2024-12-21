using System;
using System.Text.RegularExpressions;

namespace TemperatureThresholdAlerter.Models
{
    public class RegexHelper
    {
        public RegexHelper()
        {
        }

        private static readonly string onlyDigitsPattern = @"[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)";
        private static readonly Regex matchNumbersRegex = new(onlyDigitsPattern);

        public static Match MatchesValidNumber(string inputText)
        {
            return matchNumbersRegex.Match(inputText);
        }
    }
}

