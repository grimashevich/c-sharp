using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new string[5, 2];
            phonebook[0, 0] = "Иван";
            phonebook[0, 1] = "+7 (111) 111-11-11";
            phonebook[1, 0] = "Василий";
            phonebook[1, 1] = "+7 (222) 222-22-22";
            phonebook[2, 0] = "Тамара";
            phonebook[2, 1] = "tamara93@gmail.com";
            phonebook[3, 0] = "Петр";
            phonebook[3, 1] = "+7 (333) 333-33-33";
            phonebook[4, 0] = "Алексей";
            phonebook[4, 1] = "alex0001@gmail.com";
            Console.WriteLine("Имя\t\tТел\\email");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(phonebook[i, 0] + "\t\t" + phonebook[i, 1]);
            }
        }
    }
}