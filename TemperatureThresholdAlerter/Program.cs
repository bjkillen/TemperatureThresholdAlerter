using TemperatureThresholdAlerter.Controllers;
using TemperatureThresholdAlerter.Models;

public class Program
{
    public static void Main()
    {
        Console.Clear();

        Console.WriteLine("Welcome to my temperature threshold alerter!");
        Console.WriteLine("All temperatures can be expressed in Celsius or Fahrenheit and will default to Celsius.");
        Console.WriteLine("Ex: 93F, 100 F, 0 C, 100C");
        Console.WriteLine("");
        Console.WriteLine("Please provide a boiling point threshold");

        string? boilingPointInputText = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine("Please provide a freezing point threshold");

        string? freezingPointInputText = Console.ReadLine();

        TemperatureThresholdsResult thresholdsResult = StringInputParser.ParseThresholdsInput(boilingPointInputText, freezingPointInputText);

        ThermometerThresholdAlerter thermometerAlerter = new(thresholdsResult);

        try
        {
            thermometerAlerter.Validate();

            bool keepChecking = true;

            Console.CancelKeyPress += delegate (object? sender, ConsoleCancelEventArgs e) {
                keepChecking = false;
                e.Cancel = true;

                Console.WriteLine("Ctrl+C detected, please press enter to close program");
            };

            BaseController baseController = new(thermometerAlerter, thresholdsResult, true, true);

            while (keepChecking)
            {
                if (!keepChecking)
                {
                    break;
                }

                Console.WriteLine("");
                Console.WriteLine("Please provide current temperature");

                string? temperatureInputText = Console.ReadLine();

                float? tempInput = StringInputParser.ParseTemperatureInput(temperatureInputText);

                if (tempInput is null)
                {
                    Console.WriteLine("Please provide valid temperature input");
                    continue;
                }

                TemperatureThresholdCheckResult? result = baseController.CheckThresholds((float)tempInput);

                Console.WriteLine(result?.Message() ?? "Nothing new to report");
            }
        }
        catch (AggregateException e)
        {
            foreach (Exception ex in e.InnerExceptions)
            {
                Console.WriteLine(ex.Message);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

