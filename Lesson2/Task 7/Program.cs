using System;
/*
 Определить является ли введенное число палиндромом 
*/

/*
 * Я переделал эту задачу на математичесмкое решение после просмотра 3-й лекции, где вы дали подсказку про реверс числа
 * я немного опазываю с графиком, т.к. присоединился к группе на 5 дней позже старта, поэтому просьба пока что простить мне, что я пушу
 * уже после закрытия сроков сдачи ДЗ. Очень постараюсь нагнать группу в ближайшие выходные.
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

            int i2 = i, i_rev = 0;
            while (i > 0)
            {
                i_rev *= 10;
                i_rev += i % 10;
                i /= 10;
            }
            if (i2 != i_rev)
                Console.WriteLine("Число не является палиндромом");
            else Console.WriteLine("Введенное число - палиндром");


            /* Решение через строку
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
            */
        }
    }
}
