using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvancedConcepts.MiniQ2
{
    public class TemperatureConverterDemo
    {
        public TemperatureConverterDemo()
        {
            Console.WriteLine("Temperature Converter Demo");
            DisplayTemperatureInfo();
        }

        public void DisplayTemperatureInfo()
        {
            try
            {
                double celsius = 25;

                Console.WriteLine($"Celsius: {celsius}°C");

                Console.WriteLine($"Fahrenheit: {ConvertTemperature(celsius, "C", "F"):F2}°F");

                Console.WriteLine($"Kelvin: {ConvertTemperature(celsius, "C", "K"):F2}K");



                double fahrenheit = 77;

                Console.WriteLine($"\nFahrenheit: {fahrenheit}°F");

                Console.WriteLine($"Celsius: {ConvertTemperature(fahrenheit, "F", "C"):F2}°C");

                Console.WriteLine($"Kelvin: {ConvertTemperature(fahrenheit, "F", "K"):F2}K");




                double kelvin = 298.15;

                Console.WriteLine($"\nKelvin: {kelvin}K");

                Console.WriteLine($"Celsius: {ConvertTemperature(kelvin, "K", "C"):F2}°C");

                Console.WriteLine($"Fahrenheit: {ConvertTemperature(kelvin, "K", "F"):F2}°F");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Overload 1
        private double ConvertTemperature(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit)
            {
                return value;
            }

            if (fromUnit == "C" && toUnit == "F")
            {
                return (value * 9 / 5) + 32;
            }

            if (fromUnit == "C" && toUnit == "K")
            {
                return value + 273.15;
            }

            if (fromUnit == "F" && toUnit == "C")
            {
                return (value - 32) * 5 / 9;
            }

            if (fromUnit == "F" && toUnit == "K")
            {
                return (value - 32) * 5 / 9 + 273.15;
            }

            if (fromUnit == "K" && toUnit == "C")
            {
                return value - 273.15;
            }

            if (fromUnit == "K" && toUnit == "F")
            {
                return (value - 273.15) * 9 / 5 + 32;
            }

            throw new ArgumentException(
                "Invalid temperature unit."
            );
        }

        // Overload 2
        private double ConvertTemperature( double value, char fromUnit, char toUnit)
        {
            return ConvertTemperature(
                value,
                fromUnit.ToString(),
                toUnit.ToString()
            );
        }
    }
}
