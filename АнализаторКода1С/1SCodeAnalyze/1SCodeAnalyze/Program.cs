using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _1SCodeAnalyze
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count()==0){Console.Write("Программа для синтаксического анализа кода конфигурации 1С\nдля работы необходимо указать путь к выгруженным файлам конфигурации"); return;}
			var ИмяПапки = args[1];
			var dir=new DirectoryInfo(ИмяПапки);// папка с файлами 
            var files = new List<string>(); // список для имен файлов 
            ПолучитьФайлыРекурсивно(dir, files);
            foreach (String s in files) Console.WriteLine(s);
			
			// TODO: Implement Functionality Here
			
			
			Console.ReadKey(true);
        }

        private static void ПолучитьФайлыРекурсивно(DirectoryInfo dir, List<string> files)
        {
            foreach (FileInfo file in dir.GetFiles()) // извлекаем все файлы и кидаем их в список 
                files.Add(file.FullName); // получаем полный путь к файлу и кидаем его в список 
            foreach (DirectoryInfo directory in dir.GetDirectories())  
                ПолучитьФайлыРекурсивно(directory,files);
            
        }



    }
}
