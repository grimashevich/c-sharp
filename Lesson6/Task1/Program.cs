using System;
using System.Diagnostics;

namespace Task1
{
    class Program
    {
        enum UserChoice
        {
            ShowProcess = 1,
            KillById = 2,
            KillByName = 3,
            Exit = 4,
            ShowHelp = 0
        }
        
        static void Main(string[] args)
        {
            
            /*var tmp = Process.GetProcessById(11111111);
            tmp.Kill();
            Console.WriteLine(tmp.Id);
            return;*/

            var helloMsg = "\nВведите цифру для продолжения работы\n";
            helloMsg += "1 - Показать список процессов\n";
            helloMsg += "2 - Убить процесс по ID\n";
            helloMsg += "3 - Убить процесс по имени\n";
            helloMsg += "4 - Выйти из программы\n";
            helloMsg += "0 - Показать этот текст";
            while (true)
            {
                Console.WriteLine(helloMsg);
                if (!(int.TryParse(Console.ReadLine().Trim(), out int uInput)
                      && uInput >= 0 && uInput <= Enum.GetNames(typeof(UserChoice)).Length - 1))
                {
                    Console.WriteLine("Некорретный ввод, попробуйте снова");
                    continue;
                }
                var uChoice = (UserChoice) uInput;
                switch (uChoice)
                {
                    case UserChoice.ShowHelp: Console.WriteLine(helloMsg); break;
                    case UserChoice.ShowProcess: PrintProcess(); break;
                    case UserChoice.KillById: KillProcById(); break;
                    case UserChoice.KillByName: KillProcByName(); break;
                    case UserChoice.Exit: return;
                }
            }
        }

        static void KillProcById()
        {
            Console.WriteLine("Введите id процесса для завершения:");

            if (!int.TryParse(Console.ReadLine(), out int procId))
            {
                Console.WriteLine("Введен неверный id процесса");
                return;
            }

            try
            {
                if (procId == Process.GetCurrentProcess().Id)
                    Console.WriteLine("САМОУБИЙСТВО!!!\n");
                var proc = Process.GetProcessById(procId);
                proc.Kill();
            }
            catch (Exception e) when (e.Message.Contains("is not running"))
            {
                Console.WriteLine($"Процесс с таким id не найден");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка завершения процесса:\n{e}");
            }
            
        }
        static void KillProcByName()
        {
            Console.WriteLine("Введите имя процесса для завершения:");
            var procName = Console.ReadLine();
            var procs = Process.GetProcessesByName(procName);
            if (procs.Length == 0)
            {
                Console.WriteLine("Процессов с таким именем не найдено");
                return;
            }
            if (procName == Process.GetCurrentProcess().ProcessName)
                Console.WriteLine("САМОУБИЙСТВО!!!\n");
            foreach (var proc in procs)
            {
                try
                {
                    proc.Kill();
                    Console.WriteLine($"Успешно завершен процесс: {proc.Id}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка завершения процесса {proc.Id}: {e}");
                }
            }
        }
        
        static void PrintProcess()
        {
            var procs = Process.GetProcesses();
            foreach (var proc in procs)
                Console.WriteLine($"{proc.Id}\t{proc.ProcessName}");
        }
    }
}