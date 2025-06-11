using System;
using System.Globalization;

namespace ShortestVectorApp
{
    class Program
    {
        static void Main()
        {
            Console.Write("Въведете брой на векторите N: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Невалиден брой.");
                return;
            }

            double minLength = double.MaxValue;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Въведете вектор #{i + 1} (x y z): ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Невалидна линия, опитайте пак.");
                    i--;
                    continue;
                }

                var parts = line
                    .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3
                    || !double.TryParse(parts[0], NumberStyles.Float, CultureInfo.CurrentCulture, out double x)
                    || !double.TryParse(parts[1], NumberStyles.Float, CultureInfo.CurrentCulture, out double y)
                    || !double.TryParse(parts[2], NumberStyles.Float, CultureInfo.CurrentCulture, out double z))
                {
                    Console.WriteLine("Трябва да въведете 3 числа, разделени с интервал.");
                    i--;
                    continue;
                }

                var vec = new Vector3D(x, y, z);
                double len = vec.Length();
                if (len < minLength)
                    minLength = len;
            }

            Console.WriteLine($"\nДължина на най-късия вектор: {minLength:F2}");
        }
    }
}
