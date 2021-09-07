using System;

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