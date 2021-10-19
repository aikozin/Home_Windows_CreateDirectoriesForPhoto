using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = "D:/Camera";
            DirectoryInfo dI = new DirectoryInfo(path);
            FileInfo[] allFiles = dI.GetFiles();
            try
            {
                int counter = 1;
                foreach (FileInfo fi in allFiles)
                {
                    DateTime creationTime = fi.LastWriteTime;
                    string nameDirectory = $"{creationTime.Year}.{creationTime.Month:D2}.{creationTime.Day:D2}";
                    Directory.CreateDirectory($"{path}/{nameDirectory}");
                    Console.Write("{0} - Папка: {1} - Файл: {2} - ...", $"{counter}/{allFiles.Length}",$"{path}/{nameDirectory}", fi.Name);
                    File.Copy($"{path}/{fi.Name}", $"{path}/{nameDirectory}/{fi.Name}");
                    Console.WriteLine(" - Успех!");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Произошла ошибка: {0}", ex.Message);
            }

            Console.WriteLine("Копирование завершено");
            Console.ReadLine();
        }
    }
}
