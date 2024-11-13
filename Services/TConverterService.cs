using System;
using System.Collections.Generic;
using UnitConverter.Models;

namespace UnitConverter.Services
{
    public class TemperatureConverterService : IConverterService
    {
        public ConversionResult Convert(double value, string fromUnit, string toUnit)
        {
            double result = fromUnit switch
            {
                "celsius" when toUnit == "fahrenheit" => (value * 9/5) + 32,
                "fahrenheit" when toUnit == "celsius" => (value - 32) * 5/9,
                _ => value
            };

            return new ConversionResult
            {
                InputValue = value,
                OutputValue = result,
                InputUnit = fromUnit,
                OutputUnit = toUnit
            };
        }

        public List<string> GetAvailableUnits() => new() { "celsius", "fahrenheit" };
    }
}