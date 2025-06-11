using System;

namespace BaseConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Избор на режим:");
            Console.WriteLine("1) От десетична в друга бройна система");
            Console.WriteLine("2) От друга в десетична бройна система");
            Console.Write("Вашият избор (1 или 2): ");
            string choice = Console.ReadLine();

            try
            {
                if (choice == "1")
                    ConvertFromDecimal();
                else if (choice == "2")
                    ConvertToDecimal();
                else
                    Console.WriteLine("Невалиден избор.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }

            Console.WriteLine("Натиснете произволен клавиш, за да излезете...");
            Console.ReadKey();
        }

        private static void ConvertFromDecimal()
        {
            Console.Write("Въведете десетично число: ");
            int dec = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Въведете целева основа (2–36): ");
            int targetBase = int.Parse(Console.ReadLine() ?? "10");

            string result = Converter.FromDecimal(dec, targetBase);
            Console.WriteLine($"Резултат: {result}");
        }

        private static void ConvertToDecimal()
        {
            Console.Write("Въведете число: ");
            string number = Console.ReadLine() ?? "";

            Console.Write("Въведете основа на числото (2–36): ");
            int sourceBase = int.Parse(Console.ReadLine() ?? "10");

            int result = Converter.ToDecimal(number, sourceBase);
            Console.WriteLine($"Резултат: {result}");
        }
    }
}
