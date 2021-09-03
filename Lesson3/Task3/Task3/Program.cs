using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово для инверсии");
            string word = Console.ReadLine();
            if (word.Length == 0)
            {
                Console.WriteLine("Вы ничего не ввели");
                return;
            }
            int word_len = word.Length;
            for (int i = word_len - 1; i >= 0; i--)
                Console.Write(word[i]);

            Console.WriteLine();
        }
    }
}