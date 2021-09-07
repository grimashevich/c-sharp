using System;
// ReSharper disable CommentTypo
/*Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и
возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести
результат на экран.*/

/*Программа проигнорирует все значения, которые нельзя сконвертировать в int, остальные сконвертирует и сложит*/
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа, разделенные пробелом:");
            Console.WriteLine(GetSum(Console.ReadLine()));
        }
        
        static int GetSum(string nums)
        {
        
            var arr = nums.Split(" ");
            int result = 0;
            
            foreach (var num in arr)
            {
                if (int.TryParse(num, out int numInt))
                    result += numInt;
            }
            return result;
        }
    }
}