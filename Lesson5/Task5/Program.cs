using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Task5
{
    public class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo()
        {
            Title = "";
            IsDone = false;
        }
        
        public override string ToString()
        {
            return (IsDone ? "[#]" : "[ ]") + " " + Title;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var taskFile = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,"tasks.json"));
            var tasks = new List<ToDo>();
            if (File.Exists(taskFile))
            {
                LoadTasks(taskFile, ref tasks);
            }
            
            PrintTasks(ref tasks);

            var helloMsg = "Для добавления задачи введите +.";
            helloMsg += "\nДля того что бы изменить статус задачи, введите её номер.";
            helloMsg += "\nДля выхода введите q";
            
            Console.WriteLine(helloMsg);
            
            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "q")
                    return;
                if (userInput == "+")
                {
                    tasks.Add(NewTask());
                    PrintTasks(ref tasks);
                    if (!SaveTasks(taskFile, ref tasks))
                        Console.WriteLine("Ошибка сохранения файла");
                    continue;
                }

                if (int.TryParse(userInput, out int i) && i > 0 && i <= tasks.Count)
                {
                    tasks[i - 1].IsDone = !tasks[i - 1].IsDone;
                    PrintTasks(ref tasks);
                    if (!SaveTasks(taskFile, ref tasks))
                        Console.WriteLine("Ошибка сохранения файла");
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                    Console.WriteLine(helloMsg);
                }
                    
            }
        }

        static void PrintTasks(ref List<ToDo> taskList)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|             СПИСОК ЗАДАЧ             |");
            Console.WriteLine("----------------------------------------");
            if (taskList.Count == 0)
                Console.WriteLine("\t\tУ вас нет задач");
            else
            {
                for (int i = 0; i < taskList.Count; i++) 
                    Console.WriteLine(i + 1 + "\t" + taskList[i]);   
            }
            Console.WriteLine("----------------------------------------");
        }
        static ToDo NewTask()
        {
            var tmp = new ToDo();
            while (tmp.Title.Trim().Length == 0)
            {
                Console.WriteLine("Введите заголовок задачи:");
                tmp.Title = Console.ReadLine();
            }
            
            return tmp;
        }

        static bool LoadTasks(string fileName, ref List<ToDo> taskList)
        {
            try
            {
                taskList = JsonSerializer.Deserialize<List<ToDo>>(File.ReadAllText(fileName));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке загрузить задачи из файла:\n" + e);
                return false;
            }
        }
        
        static bool SaveTasks(string fileName, ref List<ToDo> taskList)
        {
            
            
            try
            {
                var json = ("n" + JsonSerializer.Serialize(taskList[0]) + "\n");
                File.WriteAllText(fileName, JsonSerializer.Serialize(taskList));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке записать задачи в файл:\n" + e);
                return false;
            }
        }
    }
}