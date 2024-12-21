using TemperatureThresholdAlerter.Controllers;
using TemperatureThresholdAlerter.Models;

public class Program
{
    public static void Main()
    {
        Console.Clear();

        Console.WriteLine("Welcome to my temperature threshold alerter!");
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

            BaseController
            Console.WriteLine("");
            Console.WriteLine("Please provide current temperature");

            string? temperatureInputText = Console.ReadLine();

            float? tempInput = StringInputParser.ParseTemperatureInput(temperatureInputText);


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

