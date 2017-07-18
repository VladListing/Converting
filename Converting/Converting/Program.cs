using CommandLine;
using ProcessMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Converting
{    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //инициализация и проверка входных аргументов.
                InputArguments inputArguments = new InputArguments();
                var verifiedInputArguments = inputArguments.GetCheckingInputArguments(args);                
                
                Console.SetWindowSize(100, 20);

                //'revert'выбор типа преобразования:
                //-(true)-преобразование из бинарного файла в файл Csv;
                //-(false)-преобразование из файла Csv в бинарный файл. 
                bool revert = true;
                ConversionSwitch conversionSwitch = new ConversionSwitch();
                IConverter converter = conversionSwitch.GetConverter(verifiedInputArguments.pathBinaryFile, verifiedInputArguments.pathCsvFile, revert);

                //задача.     
                var task = converter.ConvertAsync(verifiedInputArguments.pathBinaryFile, verifiedInputArguments.pathCsvFile);
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
