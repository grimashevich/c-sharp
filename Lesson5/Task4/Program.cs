/*4. (*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с
рекурсией и без.*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

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

            List<string> dirTree = new List<string>();
            Console.WriteLine("Рекурсивный листинг директории:\n");
            GenDirRec(curDir, ref dirTree);
            SaveListing(dirTree, @"..\..\..\task4Rec.txt");
            PrintDir(dirTree);

            Console.WriteLine();
            Console.WriteLine("Нерекурсивный листинг директории:\n");
            dirTree = GenDirNonRec(curDir);
            SaveListing(dirTree, @"..\..\..\task4NonRec.txt");
            PrintDir(dirTree);
        }

        static void PrintDir(List<string> dirTree)
        {
            foreach (var str in dirTree)
            {
                Console.WriteLine(str);
            }
        }

        static void  SaveListing(List<string> dirTree, string fileName)
        {
            string json = JsonSerializer.Serialize(dirTree);
            File.WriteAllText(fileName, json);
        }

        static List<string> GenDirRec(string dirAdress, ref List<string> tree, string shift = "\t")
        {
            foreach (var dir in Directory.GetDirectories(dirAdress))
            {
                tree.Add("[dir]" + shift + Path.GetFileName(dir));
                GenDirRec(dir, ref tree, shift + "  ");
            }

            foreach (var file in Directory.GetFiles(dirAdress))
            {
                tree.Add("[file]" + shift + Path.GetFileName(file));
            }

            return tree;
        }


        static List<string> GenDirNonRec(string dirAdress, string shift = "\t")
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


            for (int i = 0; i < tree.Count; i++)
            {
                var tmpStr = tree[i].Split("?")[1];
                /*Console.Write(curFile.Split("?")[1]);*/
                var curCubLevel = SubStrCount(tree[i], @"\") - startBS - 1;
                /*Console.Write("\t" + String.Concat(Enumerable.Repeat("  ", curCubLevel)));
                Console.WriteLine(Path.GetFileName(curFile.Split("?")[0]));*/
                tmpStr += "\t" + String.Concat(Enumerable.Repeat("  ", curCubLevel));
                tmpStr +=  Path.GetFileName(tree[i].Split("?")[0]);
                tree[i] = tmpStr;
            }

            return tree;
        }
        
        static int SubStrCount(string str, string subStr)
        {
            return str.Length - str.Replace(subStr, "").Length;
        }

    }
}