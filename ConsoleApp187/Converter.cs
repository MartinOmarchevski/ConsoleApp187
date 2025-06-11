using System;
using System.Text;

namespace BaseConverterApp
{
    public static class Converter
    {
        // Преобразува от десетична в бройна система с основа 'targetBase' (2–36)
        public static string FromDecimal(int decimalNumber, int targetBase)
        {
            if (targetBase < 2 || targetBase > 36)
                throw new ArgumentOutOfRangeException(nameof(targetBase), "Основа трябва да е между 2 и 36.");

            if (decimalNumber == 0)
                return "0";

            bool isNegative = decimalNumber < 0;
            if (isNegative)
                decimalNumber = -decimalNumber;

            StringBuilder sb = new StringBuilder();
            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % targetBase;
                sb.Insert(0, DigitToChar(remainder));
                decimalNumber /= targetBase;
            }

            if (isNegative)
                sb.Insert(0, '-');

            return sb.ToString();
        }

        // Преобразува от бройна система с основа 'sourceBase' в десетична
        public static int ToDecimal(string number, int sourceBase)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Числото не може да е празно.", nameof(number));
            if (sourceBase < 2 || sourceBase > 36)
                throw new ArgumentOutOfRangeException(nameof(sourceBase), "Основа трябва да е между 2 и 36.");

            number = number.Trim();
            bool isNegative = number.StartsWith("-");
            if (isNegative)
                number = number.Substring(1);

            int result = 0;
            foreach (char c in number)
            {
                int digit = CharToDigit(c);
                if (digit < 0 || digit >= sourceBase)
                    throw new ArgumentException($"Некоректен символ '{c}' за осnova {sourceBase}.");
                checked
                {
                    result = result * sourceBase + digit;
                }
            }

            return isNegative ? -result : result;
        }

        private static char DigitToChar(int digit)
        {
            return digit < 10
                ? (char)('0' + digit)
                : (char)('A' + (digit - 10));
        }

        private static int CharToDigit(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            if (c >= 'A' && c <= 'Z')
                return c - 'A' + 10;
            if (c >= 'a' && c <= 'z')
                return c - 'a' + 10;
            return -1;
        }
    }
}
