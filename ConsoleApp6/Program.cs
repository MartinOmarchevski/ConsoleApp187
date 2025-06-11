using System;
using System.Numerics;

namespace CombApp
{
    class Program
    {
        static void Main()
        {
            Console.Write("Въведете n и k (цели числа, разделени с интервал): ");
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine("Няма въведени данни.");
                return;
            }

            var parts = line.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2
                || !int.TryParse(parts[0], out int n)
                || !int.TryParse(parts[1], out int k))
            {
                Console.WriteLine("Невалиден формат – въведете две цели числа.");
                return;
            }

            if (n < 0 || k < 0)
            {
                Console.WriteLine("n и k трябва да са неотрицателни.");
                return;
            }

            BigInteger perm = Combinatorics.Factorial(n);
            BigInteger comb = Combinatorics.Combinations(n, k);
            BigInteger variat = Combinatorics.Variations(n, k);

            Console.WriteLine($"\nПермутации (n!): {perm}");
            Console.WriteLine($"Комбинации C(n,k): {comb}");
            Console.WriteLine($"Вариации V(n,k): {variat}");
        }
    }
}
