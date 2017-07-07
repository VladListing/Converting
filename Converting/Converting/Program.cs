using CommandLine;
using Converter;
using ProcessMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converting
{
    class InputArguments
    {
        [Option('b',"pathBinaryFile", Required = true)]
        public string pathBinaryFile { get; set; }
        [Option('c',"pathCsvFile", Required = true)]
        public string pathCsvFile { get; set; }
    }

    class Program
    {          
        private static string pathBinaryFile;
        private static string pathCsvFile;
        private static ProcessMappingBase processMapping=null;

        // метод возвращает экземпляр одного из двух 
        // возможных конвертирующих классов потдерживающих интерфейс 'IConverter'.
        private static IConverter GetConverter(bool revert)
        {
            if (revert)
            {
                return new ConverterBinaryToCsv(processMapping = new ProcessMappingConvertion(pathBinaryFile, pathCsvFile));               
            }
            else
            {
                return new ConverterCsvToBinary();
            }
        }   

        static void Main(string[] args)
        {
            try
            {
                var inputArguments = new InputArguments();

                //проверка правильности ввода входных аргументов
                if (Parser.Default.ParseArguments(args, inputArguments))
                {
                    Console.WriteLine("InputArguments: ");
                    Console.WriteLine($"pathBinaryFile  {inputArguments.pathBinaryFile}");
                    Console.WriteLine($"pathCsvFile     {inputArguments.pathCsvFile}");
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("InputArguments: ");
                    Console.WriteLine($"pathBinaryFile  {inputArguments.pathBinaryFile}");
                    Console.WriteLine($"pathCsvFile     {inputArguments.pathCsvFile}");
                    Console.WriteLine("\n");
                    Console.WriteLine("Недопустимые входные аргументы. Нажмите клавишу 'Enter' для выхода");
                    Console.ReadLine();
                    return;
                }

                //путь и имя бинарного файла 
                pathBinaryFile = inputArguments.pathBinaryFile;

                //путь и имя создаваемого файла с разделителями, типа *.CSV ,
                pathCsvFile = inputArguments.pathCsvFile;

                //-(true)-преобразование из бинарного файла в файл Csv
                //-(false)-преобразование из файла Csv в бинарный файл 
                bool revert = true;

                Console.SetWindowSize(100, 20);

                //выбираем тип преобразования
                IConverter converter = GetConverter(revert);

                //создаем задачу     
                var task = converter.ConvertAsync(pathBinaryFile, pathCsvFile);
                Console.WriteLine($"Состояние задачи: {task.Status}");
                Console.WriteLine(new string('_', 29));
                task.Wait();

                Console.WriteLine(new string('_', 29));
                Console.WriteLine($"Состояние задачи: {task.Status}");

                Console.ReadLine();

            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();

        }
    }
}
