using System;
using System.Globalization;
using System.Linq;

namespace DiceProbApp
{
    class Program
    {
        static void Main()
        {
            const int TotalRolls = 100_000;
            Console.WriteLine($"Симулираме {TotalRolls:N0} хвърляния на зар...");

            // 1. Симулираме и взимаме честотите
            var frequencies = DiceSimulator.Simulate(TotalRolls);
            // 2. Преобразуваме честотите в проценти
            var probabilities = DiceSimulator.ToProbabilities(frequencies, TotalRolls);

            Console.WriteLine("\nРезултати по страни:");
            Console.WriteLine("Страна | Честота    | Вероятност");
            Console.WriteLine("-------+------------+-----------");
            foreach (var face in Enumerable.Range(1, 6))
            {
                int freq = frequencies[face];
                double pct = probabilities[face];
                Console.WriteLine(
                    $"{face,6} | {freq,10:N0} | {pct,8:F2}%"
                );
            }

            Console.WriteLine("\nГотово. Натиснете произволен клавиш за изход...");
            Console.ReadKey();
        }
    }
}
