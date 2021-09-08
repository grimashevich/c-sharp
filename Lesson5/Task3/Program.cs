/*Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный
файл.*/
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа от 0 до 255 через пробел");
            var userBytes = ProcInts(Console.ReadLine());
            if (userBytes is null)
            {
                Console.WriteLine("Ошибка ввода чисел");
                return;
            }
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,@"..\..\..\task3.bin"));
            using (BinaryWriter wr = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                wr.Write(userBytes);
            }

            if (new FileInfo(fileName).Length == userBytes.Length)
                Console.WriteLine("Запись прошла успешно");
            else
                Console.WriteLine("Что-то пошло не так...");
        }

        static byte[] ProcInts(string str)
        {
            var strArr = str.Split(" ");
            byte[] byteArr = new byte[strArr.Length];
            
            for (int i = 0; i < byteArr.Length; i++)
            {
                if (int.TryParse(strArr[i], out int tmp) && tmp is >= 0 and <= 255)
                    byteArr[i] = (byte) tmp;
                else
                    return null;
            }

            return byteArr;
        }
    }
}