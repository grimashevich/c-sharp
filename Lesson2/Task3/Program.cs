using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            string num_str = Console.ReadLine();
            if (!int.TryParse(num_str, out int num))
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }
            if (num % 2 == 0)
                Console.WriteLine("Число четное");
            else
                Console.WriteLine("Число нечетное");
        }
    }
}
