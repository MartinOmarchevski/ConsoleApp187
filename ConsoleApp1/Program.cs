using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StatsApp
{
    class Program
    {
        static void Main()
        {
            Console.Write("Въведете списък от числа, разделени със запетая: ");
            string? line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine("Няма въведени числа.");
                return;
            }

            try
            {
                // Парсваме всеки елемент като double (според текущата култура)
                var numbers = line
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => double.Parse(s.Trim(), CultureInfo.CurrentCulture))
                    .ToList();

                double mean = Statistics.Mean(numbers);
                double median = Statistics.Median(numbers);
                var modes = Statistics.Mode(numbers);

                Console.WriteLine($"Средно аритметично: {mean:F2}");
                Console.WriteLine($"Медиана: {median:F2}");

                // Отпечатваме модата/ите
                string modeOutput = string.Join(", ",
                    modes.Select(m => m % 1 == 0
                        ? ((int)m).ToString()        // ако е цяло число – без десетична точка
                        : m.ToString("F2")));        // иначе с 2 знака
                Console.WriteLine($"Мода: {modeOutput}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Невалиден формат на входа. Уверете се, че числата са разделени с запетая и са валидни.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }
        }
    }
}
