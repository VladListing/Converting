using ProcessMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CommandLine;


namespace GeneratorBinaryFiles
{
    class InputArguments
    {
        [Option('o', "pathBinaryFile", Required = true)]
        public string pathBinaryFile { get; set; }
        [Option('n', "quantityLine", Required = true)]
        public string quantityLine { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var inputArguments = new InputArguments();
            if (Parser.Default.ParseArguments(args, inputArguments))
            {                                
            }
            else 
            {
                Console.WriteLine("Недопустимые входные аргументы. Нажмите любую клавишу для выхода");
                Console.ReadLine();
                return;
            }            
                           
            //путь и имя создаваемого бинарного файла,  
            string partBinaryFile = inputArguments.pathBinaryFile;

            //количество строк в создаваемом файле.
            long quantityLine = Convert.ToInt64(inputArguments.quantityLine);
            
            Console.SetWindowSize(100, 20);

            try
            {
                //отображение текущего процента выполения генерации.
                ProcessMappingBase processMapping = new ProcessMappingGeneration(quantityLine);

                //генерация бинарного файла.
                BinaryFiles binaryFiles = new BinaryFiles(processMapping);
                binaryFiles.BinaryFilesGenerator(partBinaryFile, quantityLine);
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
        }
    }
}
