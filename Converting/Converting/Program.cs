using Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converting
{
    class Program
    {

        // метод возвращает экземпляр одного из двух возможных конвертирующих классов потдерживающих интерфейс 'IConverter'
        private static IConverter GetConverter(bool revert)
        {
            if (revert)
            {
                // экземпляр класса , реализует преобразование из бинарного файла в файл с разделителями Csv
                return new ConverterBinaryToCsv();// создаем экземпляр по слабой ссылке                
            }
            else
            {
                //экземпляр класса , реализует преобразование из файл с разделителями Csv в бинарный файл 
                return new ConverterCsvToBinary();// создаем экземпляр по слабой ссылке
            }
        }
        


        static void Main(string[] args)
        {
            //путь и имя бинарного файла со структурами, присвоение из файла настроек: 'Path.settings'
            string pathBinary = Path.Default.pathBinary;

            //путь и имя создаваемого файла с разделителями, типа *.CSV , присвоение из файла настроек: 'Path.settings'
            string pathCsv = Path.Default.pathCsv;

            //выбираем , создать экземпляр класса преобразующего из бинарного файла в файл с разделителями Csv
            bool revert = true;

            Console.SetWindowSize(90, 20);            
                
                //Создаем экземпляр класса 'BinaryToCsvConverter'
                //преобразующий из бинарного файла в файл с разделителями Csv.
                IConverter converter = GetConverter(revert);


                //создаем задачу , в которой вызываем метод 
                //осуществляющий преобразование
                var task = converter.GetConvertAsync(pathBinary, pathCsv);
                task.Wait();

                Console.WriteLine(new string('_', 29));
                Console.WriteLine("Состояние задачи: {0}", task.Status);

                Console.ReadLine();

        }
    }
}
