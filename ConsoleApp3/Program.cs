using System;
using System.Linq;
using System.Numerics;

namespace PolyRootsApp
{
    class Program
    {
        static void Main()
        {
            Console.Write("Въведете коефициенти на полином (разделени с интервал), най-голяма степен първо: ");
            string input = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Няма въведени коефициенти.");
                return;
            }

            try
            {
                double[] coeffs = input
                    .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                    .Select(token => double.Parse(token.Trim()))
                    .ToArray();

                Complex[] roots = PolynomialSolver.Solve(coeffs);

                for (int i = 0; i < roots.Length; i++)
                {
                    var z = roots[i];
                    if (Math.Abs(z.Imaginary) < 1e-8)
                        Console.WriteLine($"Корен {i + 1}: {z.Real:F2}");
                    else
                        Console.WriteLine(
                            $"Корен {i + 1}: {z.Real:F2} " +
                            $"{(z.Imaginary >= 0 ? "+" : "-")} {Math.Abs(z.Imaginary):F2}i"
                        );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }
        }
    }
}
