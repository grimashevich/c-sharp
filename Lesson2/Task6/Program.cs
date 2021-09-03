using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] office = new byte[3] { 0b1111100, 0b1111010, 0b1101101 }; //Расписание офисов
            byte[] workdays = new byte[7] { 0b1000000, 0b0100000, 0b0010000, 0b0001000, 0b0000100, 0b0000010, 0b0000001 }; //Маски дней недели
            for (byte i = 0; i < 3; i++)
            {
                Console.WriteLine($"Режим работы оффиса № {i + 1}");
                for (byte j = 0; j < 7; j++)
                {
                    if ((office[i] & workdays[j]) > 0)
                        Console.WriteLine(get_day_of_week(j + 1));
                }
                Console.WriteLine("");
            }

        }

        static string get_day_of_week(int day_num)
        {
            return day_num switch
            {
                1 => "Понедельник",
                2 => "Вторник",
                3 => "Среда",
                4 => "Четверг",
                5 => "Пятница",
                6 => "Суббота",
                7 => "Воскресенье",
                _ => "Ошибка в номере дня недели",
            };
        }
    }
}
