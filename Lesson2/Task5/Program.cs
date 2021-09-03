/*
5. (*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести
сообщение «Дождливая зима».
*/
using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите максимальную теспературу за сутки: ");
            string max_str = Console.ReadLine();
            Console.WriteLine("Введите минимальную теспературу за сутки: ");
            string min_str = Console.ReadLine();
            if (! (float.TryParse(max_str, out float max) && float.TryParse(min_str, out float min)))
            {
                Console.WriteLine("Ошибка ввода температуры");
                return;
            }
            
            Console.WriteLine("Введите номер месяца от 1 до 12:");
            string month_str = Console.ReadLine();
            if (!(int.TryParse(month_str, out int month_num) && month_num >= 1 && month_num <= 12))
            {
                Console.WriteLine("Ошибка ввода месяца");
                return;
            }
            float average_temp = (max + min) / 2;
            DateTime cur_date = new DateTime(2021, month_num, 1);
            string month_name = cur_date.ToString("MMMM");
            Console.WriteLine($"Средняя температура за сутки: {average_temp}");
            Console.WriteLine($"Месяц {month_name}");
            if (average_temp > 0 && (month_num == 12 || month_num <= 2))
                Console.WriteLine("Дождливая зима.");
        }
    }
}
