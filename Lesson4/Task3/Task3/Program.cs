/*Написать метод по определению времени года. На вход подаётся число – порядковый номер
месяца. На выходе — значение из перечисления (enum) — Winter, Spring, Summer,
Autumn. Написать метод, принимающий на вход значение из этого перечисления и
возвращающий название времени года (зима, весна, лето, осень). Используя эти методы,
ввести с клавиатуры номер месяца и вывести название времени года. Если введено
некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».*/
using System;
namespace Task3
{
    class Program
    {
        enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }
        
        static void Main(string[] args)
        {
            int month;
            Console.WriteLine("Введите число от 1 до 12:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                    break;
                Console.WriteLine("Ошибка: введите число от 1 до 12");
            }
            Console.WriteLine($"Время года, соответствующее месяцу {month}: {GetRuSeason(GetSeason(month))}");
        }

        static Seasons GetSeason(int month)
        {
            switch (month)
            {
                case >= 3 and <= 5:
                    return Seasons.Spring;
                case >= 6 and <= 8:
                    return Seasons.Summer;
                case >= 9 and <= 11:
                    return Seasons.Autumn;
                default:
                    return Seasons.Winter;
            }
        }

        static string GetRuSeason(Seasons s)
        {
            switch (s)
            {
                case Seasons.Autumn:
                    return "Осень";
                case Seasons.Spring:
                    return "Весна";
                case Seasons.Summer:
                    return "Лето";
                default:
                    return "Зима";
            }
        }
    }
}