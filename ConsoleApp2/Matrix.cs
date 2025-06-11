using System;

namespace MatrixDeterminantApp
{
    public static class Matrix
    {
        /// <summary>
        /// Изчислява детерминантата на 3×3 матрица по правилото на Сарус.
        /// </summary>
        /// <param name="m">Двумерен масив [3,3]</param>
        /// <returns>Цяла стойност на детерминантата</returns>
        public static int Determinant3x3(int[,] m)
        {
            return
                m[0, 0] * m[1, 1] * m[2, 2] +
                m[0, 1] * m[1, 2] * m[2, 0] +
                m[0, 2] * m[1, 0] * m[2, 1] -
                m[0, 2] * m[1, 1] * m[2, 0] -
                m[0, 0] * m[1, 2] * m[2, 1] -
                m[0, 1] * m[1, 0] * m[2, 2];
        }
    }
}
