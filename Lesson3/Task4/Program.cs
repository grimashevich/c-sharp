using System;
using System.Diagnostics;
using System.Xml.Schema;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                GenSeaИBattle();
                Console.WriteLine("\nСгенерировать еще одну карту? (y/n)");
                string answer = Console.ReadLine();
                if (answer.ToLower() != "y")
                    break;
                Console.WriteLine();
            }
        }

        private static void GenSeaИBattle()
        {
            var field = new int[10, 10];
            for (var i = 4; i > 0; i--)
            {
                var count = 5 - i;
                while (count > 0)
                {
                    var ship = gen_ship(i, 10);
                    if (CheckPosition(field, ship, i, 10))
                    {
                        field = PutShip(field, ship, i);
                        count--;
                    }
                }
            }
            PrintField(field, 10);
        }
        
        private static void PrintField(int[,] field, int fSize)
        {
            char s;
            for (int i = 0; i < fSize; i++)
            {
                for (int j = 0; j < fSize; j++)
                {
                    if (field[i, j] == 0)  s = 'o';
                    else  s = 'X';
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }
        }
        private static int[,] PutShip(int[,] field, int[,] ship, int sSize)
        {
            for (int i = 0; i < sSize; i++)
            {
                field[ship[i, 0], ship[i, 1]] = 1;
            }

            return field;
        }

        private static bool CheckPosition(int[,] field, int[,] ship, int sSize, int fSize)
        {
            for (int s = 0; s < sSize; s++)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (!(InRange(ship[s, 0] + i, 0, fSize - 1) &&
                            InRange(ship[s, 1] + j, 0,fSize - 1)))
                            continue;
                        if (field[ship[s, 0] + i, ship[s, 1] + j] != 0)
                            return false;
                    }
                }
            }

            return true;
        }

        private static bool InRange(int i, int min, int max)
        {
            return i >= min && i <= max;
        }
        private static int[,] gen_ship(int size, int fieldSize)
        {
            byte curCell = 0;
            var result = new int[size, 2];
            var rand = new Random();
            while (curCell < size)
            {
                if (curCell == 0)
                {
                    result[0, 0] = rand.Next(fieldSize);
                    result[0, 1] = rand.Next(fieldSize);
                }
                else
                {
                    int rand1 = 0;
                    int rand2 = 0;

                    while (!(rand1 == 0 ^ rand2 == 0)) //Сдвигаемся только по одной координате
                    {
                        rand1 = rand.Next(3) - 1;
                        rand2 = rand.Next(3) - 1;
                    }
                    int newY = result[curCell - 1, 0] + rand1;
                    int newX = result[curCell - 1, 1] + rand2;
                    
                    //Если повтор ячейки
                    if (curCell > 1 && (newY == result[curCell - 2, 0] && newX == result[curCell - 2, 1])) 
                        continue;
                    if (newY < 0 || newY >= fieldSize || newX < 0 || newX >= fieldSize) //Если вышли за границу поля
                    {
                        curCell = 0;
                        continue;
                    }
                    result[curCell, 0] = result[curCell - 1, 0] + rand1;
                    result[curCell, 1] = result[curCell - 1, 1] + rand2;

                    if (curCell >= 3 && IsShipSquare(result))
                    {
                        curCell = 0;
                        continue;
                    }
                }

                curCell++;
            }

            return result;

        }

        private static bool IsShipSquare(int[,] ship) //Проверяем на квадратность 4-палубного корабля
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (Math.Abs(ship[i, 0] - ship[j, 0]) > 1 || Math.Abs(ship[i, 1] - ship[j, 1]) > 1)
                        return false;
                }
            }

            return true;
        }
    }
}