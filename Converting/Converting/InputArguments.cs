using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converting
{
    ///<symmary>
    /// класс 'InputsArguments' инициализация и проверка входных аргументов.
    ///<symmary>
    
    public class InputArguments
    {
        //Аргументы
        public class Options
        {
            [Option('b', "pathBinaryFile", Required = true)]
            public string pathBinaryFile { get; set; }
            [Option('c', "pathCsvFile", Required = true)]
            public string pathCsvFile { get; set; }
        }

        //метод. возвращает входные аргументы после проверки  
        public Options GetCheckingInputArguments(string[] args)
        {
            Options options = new Options();

            if (Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("InputArguments: ");
                Console.WriteLine($"pathBinaryFile  {options.pathBinaryFile}");
                Console.WriteLine($"pathCsvFile    {options.pathCsvFile}");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("InputArguments: ");
                Console.WriteLine($"pathBinaryFile  {options.pathBinaryFile}");
                Console.WriteLine($"pathCsvFile    {options.pathCsvFile}");
                Console.WriteLine("\n");
                Console.WriteLine("Недопустимые входные аргументы. Нажмите клавишу 'Enter' для выхода");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            return options;
        }
    }
}
