using System;
using System.Linq;

namespace MatrixDeterminantApp
{
    class Program
    {
        static void Main()
        {
            var matrix = new int[3, 3];
            Console.WriteLine("Въведете 3×3 матрица (всеки ред: 3 цели числа, разделени със запетая или интервал):");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Ред {i + 1}: ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Невалиден вход. Опитайте пак.");
                    i--; continue;
                }

                var parts = line
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3 || !parts.All(p => int.TryParse(p, out _)))
                {
                    Console.WriteLine("Трябва да въведете точно 3 цели числа.");
                    i--; continue;
                }

                for (int j = 0; j < 3; j++)
                    matrix[i, j] = int.Parse(parts[j]);
            }

            int det = Matrix.Determinant3x3(matrix);
            Console.WriteLine($"\nДетерминанта на матрицата е: {det}");
        }
    }
}
