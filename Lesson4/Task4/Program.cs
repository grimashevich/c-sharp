/*4. (*) Написать программу, вычисляющую число Фибоначчи для заданного значения
рекурсивным способом.*/
using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFibo(10));
        }

        static int GetFibo(int num)
        {
            if (num == 0)
                return 0;
            if (num == 1)
                return 1;
            return (GetFibo(num - 1) + GetFibo(num - 2));
        }
    }
}