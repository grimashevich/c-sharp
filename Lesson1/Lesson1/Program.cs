using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя: ");
            string username = Console.ReadLine();
            DateTime today = DateTime.Today;
            Console.WriteLine("Привет, " + username + " сегодня " + today.ToString("d MMM yyyy"));
        }
    }
}
