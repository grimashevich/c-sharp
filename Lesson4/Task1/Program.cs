using System;
/*Написать метод GetFullName(string firstName, string lastName, string
patronymic), принимающий на вход ФИО в разных аргументах и возвращающий
объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль
3–4 разных ФИО.*/

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFullName("Иван", "Иванов", "Петрович"));
            Console.WriteLine(GetFullName("Петр", "Петров", "Иванович"));
            Console.WriteLine(GetFullName("Валентин", "Сидоров", "Михайлович"));
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName} {patronymic}";
        }
    }
}