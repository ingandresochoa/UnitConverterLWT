using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Models;

namespace UnitConverter.Services
{
    public class LengthConverterService : IConverterService
    {
        private readonly Dictionary<string, double> _conversionRates = new()
        {
            { "metros", 1 },
            { "pies", 3.28084 }
        };

        public ConversionResult Convert(double value, string fromUnit, string toUnit)
        {
            double metros = fromUnit == "metros" ? value : value / _conversionRates[fromUnit];
            double result = toUnit == "metros" ? metros : metros * _conversionRates[toUnit];

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