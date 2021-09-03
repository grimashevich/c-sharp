using System;
/*
 Определить является ли введенное число палиндромом 
*/


namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое положительное число");
            string i_str = Console.ReadLine();
            if (! int.TryParse(i_str, out int i) && i > 0)
            {
                Console.WriteLine("Ошибка ввода числа");
                return;
            }

            int str_len = i_str.Length;
            for (int n = 0; n < str_len / 2; n++)
            {
                if (i_str[n] != i_str[str_len - n - 1])
                {
                    Console.WriteLine("Число не является палиндромом");
                    return;
                }
            }
            Console.WriteLine("Введенное число - палиндром");
        }
    }
}
