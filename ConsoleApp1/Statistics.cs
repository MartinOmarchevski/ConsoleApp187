using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StatsApp
{
    public static class Statistics
    {
        // Средно аритметично
        public static double Mean(List<double> numbers)
        {
            if (numbers.Count == 0)
                throw new InvalidOperationException("Няма числа за изчисление.");
            return numbers.Sum() / numbers.Count;
        }

        // Медиана
        public static double Median(List<double> numbers)
        {
            if (numbers.Count == 0)
                throw new InvalidOperationException("Няма числа за изчисление.");

            var sorted = numbers.OrderBy(n => n).ToList();
            int mid = sorted.Count / 2;

            return (sorted.Count % 2 == 1)
                ? sorted[mid]
                : (sorted[mid - 1] + sorted[mid]) / 2.0;
        }

        // Мода (връща всички стойности с максимална честота)
        public static List<double> Mode(List<double> numbers)
        {
            if (numbers.Count == 0)
                throw new InvalidOperationException("Няма числа за изчисление.");

            var groups = numbers
                .GroupBy(n => n)
                .Select(g => new { Value = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList();

            int maxCount = groups.First().Count;
            return groups
                .Where(g => g.Count == maxCount)
                .Select(g => g.Value)
                .ToList();
        }
    }
}
