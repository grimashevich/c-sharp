/*1. Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.*/
using System;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"..\..\..\task1.txt";
            Console.WriteLine("Введите данные для сохранения в файл, для окончания наберите q!");
            if (File.Exists(fileName)) File.Delete(fileName);
            var firstLine = true;
            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput == "q!")
                    break;
                if (firstLine) firstLine = false;
                else File.AppendAllText(fileName, "\n");
                File.AppendAllText(fileName, userInput);
            }
        }
    }
}