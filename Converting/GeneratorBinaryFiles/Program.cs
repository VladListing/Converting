using ProcessMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBinaryFiles
{
    






    class Program
    {
        static void Main(string[] args)
        {
            //путь и имя создаваемого бинарного файла,  
            //присвоение из файла настроек:'PathBinary.settings'.
            string pathBinary = PathBinary.Default.pathBinary;

            long quantityLine = 0;//количество строк в создаваемом файле.

            Console.SetWindowSize(100, 20);

            try
            {
                //проверка правильности ввода с клавиатуры.
                InputValidation inputValidation = new InputValidation();
                quantityLine = inputValidation.GetInputValidationKey();

                //отображение текущего процента выполения генерации.
                ProcessMappingBase processMapping = new ProcessMappingGeneration(quantityLine);

                //генерация бинарного файла.
                BinaryFiles binaryFiles = new BinaryFiles(processMapping);
                binaryFiles.BinaryFilesGenerator(pathBinary, quantityLine);
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
        }
    }
}
