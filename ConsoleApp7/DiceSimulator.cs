using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceProbApp
{
    public static class DiceSimulator
    {
        /// <summary>
        /// Симулира n хвърляния на зар и връща честотата за всяка страна (1–6).
        /// </summary>
        public static Dictionary<int, int> Simulate(int rolls)
        {
            var rnd = new Random();
            // Инициализираме честоти за страните 1–6
            var freq = Enumerable.Range(1, 6).ToDictionary(face => face, face => 0);

            for (int i = 0; i < rolls; i++)
            {
                int face = rnd.Next(1, 7);
                freq[face]++;
            }

            return freq;
        }

        /// <summary>
        /// Преобразува честотите в емпирични вероятности (в проценти).
        /// </summary>
        public static Dictionary<int, double> ToProbabilities(Dictionary<int, int> freq, int totalRolls)
        {
            return freq.ToDictionary(
                kvp => kvp.Key,
                kvp => 100.0 * kvp.Value / totalRolls
            );
        }
    }
}
