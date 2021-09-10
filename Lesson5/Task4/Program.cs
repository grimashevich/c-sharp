/*4. (*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с
рекурсией и без.*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var curDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\.."));
            if (!Directory.Exists(curDir))
            {
                Console.WriteLine($" Такой директории не существует ({curDir})");
                return;
            }
            Console.WriteLine("Рекурсивный листинг директории:\n");
            PrintDirRec(curDir);
            Console.WriteLine();
            Console.WriteLine("Нерекурсивный листинг директории:\n");
            PrintDirNonRec(curDir);
        }

        static void PrintDirRec(string dirAdress, string shift = "\t")
        {
            foreach (var dir in Directory.GetDirectories(dirAdress))
            {
                Console.WriteLine("[dir]" + shift + Path.GetFileName(dir));
                PrintDirRec(dir, shift + "  ");
            }

            foreach (var file in Directory.GetFiles(dirAdress))
            {
                Console.WriteLine("[file]" + shift + Path.GetFileName(file));
            }
        }


        static void PrintDirNonRec(string dirAdress, string shift = "\t")
        {
            Queue<string> files = new Queue<string>();
            List<string> tree = new List<string>();
            files.Enqueue(dirAdress);

            //Кол-во слешей на старте. По ним определяем уровень вложенности
            int startBS = SubStrCount(dirAdress, @"\");

            while (files.Count > 0)
            {
                var curDir = files.Dequeue();
                foreach (var dir in Directory.GetDirectories(curDir))
                {
                    files.Enqueue(dir);
                    tree.Add(dir + "?[dir]");
                }

                foreach (var file in Directory.GetFiles(curDir))
                    tree.Add(file + "?[file]");
                
            }
            tree.Sort();
            foreach (var curFile in tree)
            {
                Console.Write(curFile.Split("?")[1]);
                var curCubLevel = SubStrCount(curFile, @"\") - startBS - 1;
                Console.Write("\t" + String.Concat(Enumerable.Repeat("  ", curCubLevel)));
                Console.WriteLine(Path.GetFileName(curFile.Split("?")[0]));
                
            }
        }
        
        static int SubStrCount(string str, string subStr)
        {
            return str.Length - str.Replace(subStr, "").Length;
        }

    }
}