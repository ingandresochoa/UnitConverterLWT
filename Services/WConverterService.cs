using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Models;

namespace UnitConverter.Services
{
    public class WeightConverterService : IConverterService
    {
        private readonly Dictionary<string, double> _conversionRates = new()
        {
            { "kilogramos", 1 },
            { "libras", 2.20462 }
        };

        public ConversionResult Convert(double value, string fromUnit, string toUnit)
        {
            double kilos = fromUnit == "kilogramos" ? value : value / _conversionRates[fromUnit];
            double result = toUnit == "kilogramos" ? kilos : kilos * _conversionRates[toUnit];

            return new ConversionResult
            {
                InputValue = value,
                OutputValue = result,
                InputUnit = fromUnit,
                OutputUnit = toUnit
            };
        }

        public List<string> GetAvailableUnits() => _conversionRates.Keys.ToList();
    }
}