using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var m_size = 5; //Размерность массива (N x N)
            var matrix = new byte[m_size, m_size];
            for (int i = 0; i <= m_size - 1; i++)
            {
                for (int j = 0; j <= m_size - 1; j++)
                {
                    matrix[i, j] = (byte) rand.Next(10);
                }
            }
            Console.WriteLine("Обычный вывод:");
            for (int i = 0; i <= m_size - 1; i++)
            {
                for (int j = 0; j <= m_size - 1; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("\nВывод по диагонали (с правого верхнего угла):");
            
            int ii = 0;
            int jj = m_size - 1;
            while(ii <= m_size - 1 && jj >= 0)
            {
                int i2 = ii, j2 = jj;
                while (ii < m_size && jj < m_size)
                    Console.Write(matrix[ii++, jj++] + " ");
                
                ii = i2;
                jj = j2;
                if (jj > 0)  jj--;
                else  ii++;
                Console.WriteLine();
            }
        }
    }
}