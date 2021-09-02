using System;

namespace Task2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер месяца от 1 до 12:");
            string month_str = Console.ReadLine();
            if (!(int.TryParse(month_str, out int month_num) && month_num >= 1 && month_num <= 12))
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }
            DateTime cur_date = new DateTime(2021, month_num, 1);
            string month_name = cur_date.ToString("MMMM");
            Console.WriteLine($"Кажется это {month_name}");
        }
    }
}
