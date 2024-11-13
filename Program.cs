using System;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.Services;
using UnitConverter.Models;

namespace UnitConverter
{
    class Program
    {
        private static readonly Dictionary<string, IConverterService> _converters = new()
        {
            { "Longitud", new LengthConverterService() },
            { "Peso", new WeightConverterService() },
            { "Temperatura", new TemperatureConverterService() }
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CONVERTIDOR DE UNIDADES ===");
                ShowMenu();
                
                var selectedConverter = GetConverterSelection();
                if (selectedConverter == null) break;

                ProcessConversion(selectedConverter);
                
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void ShowMenu()
        {
            var options = _converters.Keys.ToList();
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine($"{options.Count + 1}. Salir");
        }

        private static IConverterService GetConverterSelection()
        {
            Console.Write("\nSeleccione una opción: ");
            if (int.TryParse(Console.ReadLine(), out int option) && 
                option > 0 && 
                option <= _converters.Count)
            {
                return _converters.ElementAt(option - 1).Value;
            }
            return null;
        }

        private static void ProcessConversion(IConverterService converter)
        {
            var units = converter.GetAvailableUnits();
            Console.WriteLine("\nUnidades disponibles:");
            for (int i = 0; i < units.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {units[i]}");
            }

            Console.Write("\nSeleccione unidad de origen: ");
            if (!int.TryParse(Console.ReadLine(), out int fromUnitIndex) || 
                fromUnitIndex < 1 || 
                fromUnitIndex > units.Count)
            {
                Console.WriteLine("Selección inválida");
                return;
            }

            Console.Write("Seleccione unidad de destino: ");
            if (!int.TryParse(Console.ReadLine(), out int toUnitIndex) || 
                toUnitIndex < 1 || 
                toUnitIndex > units.Count)
            {
                Console.WriteLine("Selección inválida");
                return;
            }

            Console.Write("Ingrese el valor a convertir: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Valor inválido");
                return;
            }

            var result = converter.Convert(
                value,
                units[fromUnitIndex - 1],
                units[toUnitIndex - 1]
            );

            Console.WriteLine($"\nResultado: {result.FormattedResult}");
        }
    }
}