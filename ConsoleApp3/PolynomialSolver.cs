using System;
using System.Numerics;
using System.Linq;

namespace PolyRootsApp
{
    public static class PolynomialSolver
    {
        /// <summary>
        /// Връща всички корени (Complex) на полином с коефициенти coeffs[0]·x^n + coeffs[1]·x^(n-1) + … + coeffs[n].
        /// Поддържа линейни, квадратни и кубични полиноми.
        /// </summary>
        public static Complex[] Solve(double[] coeffs)
        {
            int degree = coeffs.Length - 1;
            if (degree < 1)
                throw new ArgumentException("Нужно е поне два коефициента (линеен полином).");

            // 1) Линеен: a·x + b = 0
            if (degree == 1)
            {
                double a = coeffs[0], b = coeffs[1];
                return new[] { new Complex(-b / a, 0) };
            }

            // 2) Квадратен: a·x² + b·x + c = 0
            if (degree == 2)
            {
                double a = coeffs[0], b = coeffs[1], c = coeffs[2];
                double D = b * b - 4 * a * c;
                if (D >= 0)
                {
                    double sqrtD = Math.Sqrt(D);
                    return new[]
                    {
                        new Complex((-b + sqrtD) / (2 * a), 0),
                        new Complex((-b - sqrtD) / (2 * a), 0)
                    };
                }
                else
                {
                    double sqrtD = Math.Sqrt(-D);
                    return new[]
                    {
                        new Complex(-b / (2 * a),  sqrtD / (2 * a)),
                        new Complex(-b / (2 * a), -sqrtD / (2 * a))
                    };
                }
            }

            // 3) Кубичен: a·x³ + b·x² + c·x + d = 0
            if (degree == 3)
            {
                double a = coeffs[0], b = coeffs[1], c = coeffs[2], d = coeffs[3];
                // Понижаване: x = t - b/(3a)
                double shift = b / (3 * a);
                double p = (3 * a * c - b * b) / (3 * a * a);
                double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d)
                           / (27 * a * a * a);
                double D = (q / 2) * (q / 2) + (p / 3) * (p / 3) * (p / 3);

                if (D >= 0)
                {
                    // Един реален + две комплексни
                    double sqrtD = Math.Sqrt(D);
                    Complex u = Complex.Pow(-q / 2 + sqrtD, 1.0 / 3.0);
                    Complex v = Complex.Pow(-q / 2 - sqrtD, 1.0 / 3.0);
                    Complex r1 = u + v - shift;
                    Complex r2 = -(u + v) / 2 - shift + Complex.ImaginaryOne * (u - v) * Math.Sqrt(3) / 2;
                    Complex r3 = Complex.Conjugate(r2);
                    return new[] { r1, r2, r3 };
                }
                else
                {
                    // Три реални
                    double r = 2 * Math.Sqrt(-p / 3);
                    double phi = Math.Acos(-q / (2 * Math.Sqrt(-p * p * p / 27)));
                    Complex r1 = r * Math.Cos(phi / 3) - shift;
                    Complex r2 = r * Math.Cos((phi + 2 * Math.PI) / 3) - shift;
                    Complex r3 = r * Math.Cos((phi + 4 * Math.PI) / 3) - shift;
                    return new[] { r1, r2, r3 };
                }
            }

            throw new NotSupportedException("Полиноми от степен >3 не се поддържат.");
        }
    }
}
