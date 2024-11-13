using System;
using System.Collections.Generic;
using UnitConverter.Models;

namespace UnitConverter.Services
{
    public interface IConverterService
    {
        ConversionResult Convert(double value, string fromUnit, string toUnit);
        List<string> GetAvailableUnits();
    }
}