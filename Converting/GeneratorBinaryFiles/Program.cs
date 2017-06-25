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

            Console.SetWindowSize(90, 20);

            try
            {
                InputValidation inputValidation = new InputValidation();//проверка правильности ввода с клавиатуры.
                BinaryFiles binaryFiles = new BinaryFiles();//генерация бинарных файлов.          

                binaryFiles.BinaryFilesGener(pathBinary, inputValidation.GetInputValidationKey());
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
        }
    }
}
