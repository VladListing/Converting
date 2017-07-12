using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBinaryFiles
{
    public class InputArguments
    {
        //Аргументы
        public class Options
        {
            [Option('p', "pathBinaryFile", Required = true)]
            public string pathBinaryFile { get; set; }
            [Option('q', "quantityLine", Required = true)]
            public string quantityLine { get; set; }
        }

        //метод. возвращает входные аргументы после проверки  
        public  Options GetCheckingInputArguments(string[] args)
        {
            Options options = new Options();

            if (Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("InputArguments: ");
                Console.WriteLine($"pathBinaryFile  {options.pathBinaryFile}");
                Console.WriteLine($"quantityLine    {options.quantityLine}");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("InputArguments: ");
                Console.WriteLine($"pathBinaryFile  {options.pathBinaryFile}");
                Console.WriteLine($"quantityLine    {options.quantityLine}");
                Console.WriteLine("\n");
                Console.WriteLine("Недопустимые входные аргументы. Нажмите клавишу 'Enter' для выхода");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            return options;
        }
    }
}
