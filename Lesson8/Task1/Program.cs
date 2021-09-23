using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Task1
{
    class AppUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }

        public override string ToString()
        {
            return $"Имя: {this.Name}\nВозраст: {this.Age}\nСфера деятельности: {this.Job}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var roaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            var confFile = new ExeConfigurationFileMap {ExeConfigFilename = roaming.FilePath};
            var config = ConfigurationManager.OpenMappedExeConfiguration(confFile,
                ConfigurationUserLevel.None);
            var curUser = new AppUser();
            var helloMsg = string.Empty;

            if (! File.Exists(roaming.FilePath) || ! config.AppSettings.Settings.AllKeys.Contains("hellomsg"))
            {
                config.AppSettings.Settings.Add("helloMsg", "Вас приветствует приложение с настройками!");
                config.Save();
            }
            
            Console.WriteLine(config.AppSettings.Settings["hellomsg"].Value);
            
            var confKeys = config.AppSettings.Settings.AllKeys;
            if (confKeys.Contains("name") && confKeys.Contains("age") && confKeys.Contains("job"))
            {
                curUser.Name = config.AppSettings.Settings["name"].Value;
                curUser.Age = int.Parse(config.AppSettings.Settings["age"].Value);
                curUser.Job = config.AppSettings.Settings["job"].Value;   
            }
            else
            {
                if (!GetUserData(ref curUser))
                {
                    Console.WriteLine("Вы отказались от ввода дыннх. Выход из приложения.");
                    return;
                }
                config.AppSettings.Settings.Add("name", curUser.Name);
                config.AppSettings.Settings.Add("age",  curUser.Age.ToString());
                config.AppSettings.Settings.Add("job", curUser.Job);
                config.Save();
                return;
            }
            Console.WriteLine(curUser);
            Console.WriteLine("- - - - -\nЧтобы очистить настройки приложения введите y");
            if (Console.ReadLine().Trim().ToLower() == "y")
            {
                config.AppSettings.Settings.Clear();
                config.Save();
                Console.WriteLine("Настройки очищены");
            }
            
        }

        static bool GetUserData(ref AppUser user)
        {
            while (true)
            {
                Console.WriteLine("Введите имя (или q для выхода):");
                string name = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(name))
                    continue;
                if (name.ToLower() == "q")
                    return false;
                user.Name = name;
                break;
            }
            
            while (true)
            {
                Console.WriteLine("Введите возраст (или q для выхода):");
                string sAge = Console.ReadLine().Trim();
                if (sAge.ToLower() == "q")
                    return false;
                if (! int.TryParse(sAge, out int age) || age < 1)
                    continue;
                user.Age = age;
                break;
            }
            
            while (true)
            {
                Console.WriteLine("Введите род деятельности (или q для выхода):");
                string job = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(job))
                    continue;
                if (job.ToLower() == "q")
                    return false;
                user.Job = job;
                break;
            }
            return true;
        }
    }
}