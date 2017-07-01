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

        // метод возвращает экземпляр одного из двух 
        // возможных конвертирующих классов потдерживающих интерфейс 'IConverter'.
        private static IConverter GetConverter(bool revert)
        {
            if (revert)
            {
                return new ConverterBinaryToCsv();               
            }
            else
            {
                return new ConverterCsvToBinary();
            }
        }   


        static void Main(string[] args)
        {
            //путь и имя бинарного файла со структурами, 
            //присвоение из файла настроек: 'Path.settings'
            string pathBinary = Path.Default.pathBinary;

            //путь и имя создаваемого файла с разделителями, типа *.CSV ,
            //присвоение из файла настроек: 'Path.settings'
            string pathCsv = Path.Default.pathCsv;

            //(true)преобразование из бинарного файла в файл с разделителями Csv
            //(false)преобразование из файла Csv в бинарный файл 
            bool revert = true;
            //int w=0;
            Console.SetWindowSize(100, 20);

                //выбираем тип преобразования
                IConverter converter = GetConverter(revert);

                //создаем задачу     
                var task = converter.GetConvertAsync(pathBinary, pathCsv);
                Console.WriteLine($"Состояние задачи: {task.Status}");
                Console.WriteLine(new string('_', 29));
                task.Wait();

                Console.WriteLine(new string('_', 29));
                Console.WriteLine($"Состояние задачи: {task.Status}");
                
                Console.ReadLine();
        }
    }
}
