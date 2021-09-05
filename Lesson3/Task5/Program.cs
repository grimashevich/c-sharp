/*
 * Задача 5. Дано 2 строки. Найти максимально длинную общую подстроку в обеих строках и вывести ее на экран.
 */
using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "aabbbbcccccddaabb@c-";
            var str2 = "aabb@cc3cccaaddxx";
            var lenStr1 = str1.Length; // Опеределил переменные, что бы каждый раз это значение не вычислялялось.
            var lenStr2 = str2.Length;
            var rStart = -1;    // Начало результируещй строки
            var rLen = 0;      // Длина результируещй строки
            for (int i = 0; i < lenStr1; i++)
            {
                for (int j = 0; j < lenStr2; j++)
                {
                    var shift = 0;
                    while (i + shift < lenStr1 && j + shift < lenStr2)
                    {
                        if (str1[i + shift] == str2[j + shift])
                        {
                            if (rLen < shift + 1)
                            {
                                rStart = i;
                                rLen = shift + 1;   
                            }
                            shift++;
                        }
                        else break;
                    }
                }
            }

            if (rLen == 0)
            {
                Console.WriteLine("Нет совпадающих подстрок");
                return;
            }
            Console.WriteLine($"Самая длинная общая подстрока: {str1.Substring(rStart, rLen)}");
        }
    }
}