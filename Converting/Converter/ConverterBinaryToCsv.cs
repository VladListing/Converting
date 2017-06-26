using ProcessMapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    /// <summary>
    /// класс 'ConverterBinaryToCsv' преобразует файл из бинарного формата в Csv ,
    /// а так же обрамляет в фоновую задачу.
    /// </summary>


    public class ConverterBinaryToCsv : IConverter
    {
        private string _pathBinary = null; //путь и имя исходного бинарного файла
        private string _pathCsv = null;    //путь и имя конечного Csv файла

        private int _id = 0;            //колонка "id"
        private int _account = 0;       //колонка "account"
        private double _volume = 0.0;   //колонка "volume"
        private string _comment = null; //колонка "comment"

        private int _counter = 0;       //счетчик записаных строк

        private const double _byteToMegabyteKoef =  1048576.0;//для преобразование из байтов в мегабайты


        public void Convert(string pathDat, string pathCsv)
        //public Task ConvertAsync(string pathDat, string pathCsv)
        {
            try
            {

                _pathBinary = pathDat;
                _pathCsv = pathCsv;

                //todo: вот консоль тут уже совершенно ни при чём, а если мы решим использовать библиотеку в оконном приложении ?
                Console.SetWindowSize(100, 20);

                ProcessMappingBase processMapping = new ProcessMappingConvertion(pathDat, pathCsv);
                using (BinaryReader reader = new BinaryReader(File.Open(_pathBinary, FileMode.Open), Encoding.ASCII))
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(_pathCsv))
                {
                    //todo: вызов статического метода возвращяющего размер файла
                    var a = ProcessMappingConvertion.GetCount(pathDat);
                    var b = a/ _byteToMegabyteKoef;
                    string sizeFile = b.ToString("#.###");

                    Console.WriteLine($"Ждите, выполняется конвертация из бинарного файла: {_pathBinary} , размером: {sizeFile} Mb");
                    Console.WriteLine($"в файл с разделителями: {_pathCsv} ");
                    Console.WriteLine();

                    reader.BaseStream.Position = 0;

                    while (reader.PeekChar() > -1)
                    {
                        _id = reader.ReadInt32();
                        _account = reader.ReadInt32();
                        _volume = reader.ReadDouble();
                        _comment = reader.ReadString();

                        file.Write(_id);
                        file.Write(";");
                        file.Write(_account);
                        file.Write(";");
                        file.Write(_volume);
                        file.Write(";");
                        file.Write(_comment);
                        file.WriteLine(";");
                        _counter++;

                        //процент выполнения    
                        processMapping.ProcessMappingInPercent();
                    }
                    Console.Write("\r");
                    Console.Write("выполнено: 100 % ");
                    Console.WriteLine("\n\n");
                    Console.Write($"в файл {pathCsv} конвертировано: {_counter} строк(и). ");
                    Console.WriteLine();

                    _counter = 0;
                }
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
        }

        //Метод возвращает  асинхронную задачу
        public Task GetConvertAsync(string srcPath, string destPath)
        {
            Task task1 = new Task(() => Convert(srcPath, destPath));
            task1.Start();
            Console.WriteLine($"Состояние задачи: {task1.Status}");
            Console.WriteLine(new string('_', 29));

            return task1;
        }
    }
}
