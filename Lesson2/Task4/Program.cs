/*
4. Для полного закрепления понимания простых типов найдите любой чек, либо фотографию
этого чека в интернете и схематично нарисуйте его в консоли, только за место динамических,
по вашему мнению, данных (это может быть дата, название магазина, сумма покупок)
подставляйте переменные, которые были заранее заготовлены до вывода на консоль.
*/

using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime cur_date = DateTime.Now;
            string shop_name = "Супермаркет Караван";
            decimal good_1 = 25.00M;
            decimal good_2 = 100.25M;
            decimal good_3 = 9.99M;
            decimal received = 200.00M;
            int cash_box_num = 4;
            string cashier_name = "Иванова А.Б.";
            Console.WriteLine("---------------------------------");
            Console.WriteLine("|\t\t\t\t|");
            Console.WriteLine($"|\t{cur_date}\t|");
            Console.WriteLine($"|\t{shop_name}\t|");
            Console.WriteLine("|\t\t\t\t|");
            Console.WriteLine($"| Товар 1\t\t{good_1}\t|");
            Console.WriteLine($"| Товар 2\t\t{good_2}\t|");
            Console.WriteLine($"| Товар 3\t\t{good_3}\t|");
            Console.WriteLine("|\t\t\t\t|");
            Console.WriteLine($"| Итого:\t\t{good_1 + good_2 + good_3}\t|");
            Console.WriteLine($"| Получено: \t\t{received}\t|");
            Console.WriteLine($"| Сдача: \t\t{received - good_1 - good_2 - good_3}\t|");
            Console.WriteLine("|\t\t\t\t|");
            Console.WriteLine($"| Кассир \t{cashier_name}\t|");
            Console.WriteLine($"| Касса № \t{cash_box_num}\t\t|");
            Console.WriteLine("|\t\t\t\t|");
            Console.WriteLine("---------------------------------");
        }
    }
}
