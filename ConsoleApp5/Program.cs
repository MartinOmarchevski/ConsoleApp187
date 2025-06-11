using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SetOpsApp
{
    class Program
    {
        static void Main()
        {
            Console.Write("Въведете първото множество (числа разделени с интервал): ");
            var line1 = Console.ReadLine() ?? "";
            Console.Write("Въведете второто множество (числа разделени с интервал): ");
            var line2 = Console.ReadLine() ?? "";

            // Парсваме и премахваме дубликати
            var set1 = line1
                .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s.Trim(), CultureInfo.CurrentCulture))
                .Distinct();
            var set2 = line2
                .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s.Trim(), CultureInfo.CurrentCulture))
                .Distinct();

            // Извършваме операциите и сортираме за четимост
            var inter = SetOperations.Intersection(set1, set2).OrderBy(x => x);
            var uni = SetOperations.Union(set1, set2).OrderBy(x => x);
            var diff = SetOperations.Difference(set1, set2).OrderBy(x => x);
            var symd = SetOperations.SymmetricDifference(set1, set2).OrderBy(x => x);

            // Помощен метод за печат
            string FormatSet(IEnumerable<int> seq) => !seq.Any() ? "(празно)" : string.Join(" ", seq);

            Console.WriteLine();
            Console.WriteLine($"Сечение: {FormatSet(inter)}");
            Console.WriteLine($"Обединение: {FormatSet(uni)}");
            Console.WriteLine($"Разлика (първо \\ второ): {FormatSet(diff)}");
            Console.WriteLine($"Сбор (симетрична разлика): {FormatSet(symd)}");
        }
    }
}
