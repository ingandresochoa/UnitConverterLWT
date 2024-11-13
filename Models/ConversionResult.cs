using System;

namespace UnitConverter.Models
{
    public class ConversionResult
    {
        public double InputValue { get; set; }
        public double OutputValue { get; set; }
        public string InputUnit { get; set; }
        public string OutputUnit { get; set; }
        public string FormattedResult => $"{InputValue} {InputUnit} = {OutputValue:F2} {OutputUnit}";
    }
}