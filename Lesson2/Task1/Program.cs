/*
 1. Запросить у пользователя минимальную и максимальную температуру за сутки и вывести
среднесуточную температуру.
 */

using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите максимальную теспературу за сутки: ");
            float max = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите минимальную теспературу за сутки: ");
            float min = float.Parse(Console.ReadLine());
            Console.WriteLine($"Средняя температура за сутки: {(max + min) / 2}");
        }
    }
}
