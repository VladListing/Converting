using Converter;
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
          
        private static string pathBinary;
        private static string pathCsv;
        private static ProcessMappingBase processMapping=null;

        // метод возвращает экземпляр одного из двух 
        // возможных конвертирующих классов потдерживающих интерфейс 'IConverter'.
        private static IConverter GetConverter(bool revert)
        {
            if (revert)
            {
                return new ConverterBinaryToCsv(processMapping = new ProcessMappingConvertion(pathBinary, pathCsv));               
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
            pathBinary = Path.Default.pathBinary;

            //путь и имя создаваемого файла с разделителями, типа *.CSV ,
            //присвоение из файла настроек: 'Path.settings'
            pathCsv = Path.Default.pathCsv;

            //(true)преобразование из бинарного файла в файл с разделителями Csv
            //(false)преобразование из файла Csv в бинарный файл 
            bool revert = true;
                       
            //ProcessMappingBase processMapping = new ProcessMappingConvertion(pathBinary, pathCsv);

                Console.SetWindowSize(100, 20);

                //выбираем тип преобразования
                IConverter converter = GetConverter(revert);

                //создаем задачу     
                var task = converter.ConvertAsync(pathBinary, pathCsv);
                Console.WriteLine($"Состояние задачи: {task.Status}");
                Console.WriteLine(new string('_', 29));
                task.Wait();

                Console.WriteLine(new string('_', 29));
                Console.WriteLine($"Состояние задачи: {task.Status}");
                
                Console.ReadLine();
        }
    }
}
