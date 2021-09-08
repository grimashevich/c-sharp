/*2. Написать программу, которая при старте дописывает текущее время в файл
«startup.txt».*/

using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,@"..\..\..\startup.txt"));
            
            File.AppendAllText(fileName, DateTime.Now.ToString() + "\n");
        }
    }
}