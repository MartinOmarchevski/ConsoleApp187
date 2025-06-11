using System;
using System.Numerics;

namespace CombApp
{
    public static class Combinatorics
    {
        // Пресмята n! (факториел) с BigInteger
        public static BigInteger Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("n не може да е отрицателно");
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        // n! / (n-k)! = P(n,k) – вариации (пермутации с дължина k)
        public static BigInteger Variations(int n, int k)
        {
            if (k < 0 || k > n)
                return 0;
            BigInteger result = 1;
            for (int i = n; i > n - k; i--)
                result *= i;
            return result;
        }

        // C(n,k) = n! / (k! * (n-k)!)
        public static BigInteger Combinations(int n, int k)
        {
            if (k < 0 || k > n)
                return 0;
            // по-добре е да пресметнем частично, за да избегнем много големи междинни n!
            k = Math.Min(k, n - k);
            BigInteger numerator = 1;
            BigInteger denominator = 1;
            for (int i = 1; i <= k; i++)
            {
                numerator *= (n - k + i);
                denominator *= i;
            }
            return numerator / denominator;
        }
    }
}
