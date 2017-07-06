using ProcessMapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBinaryFiles
{
    ///<symmary>
    /// класс 'BinaryFiles' генерирует бинарные файлы с заданым количеством строк, заданной структуры.
    ///<symmary>

    public class BinaryFiles
    {
        //описание структуры 'TradeRecord'.
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TradeRecord
        {
            public int id;
            public int account;
            public double volume;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string comment;

            public TradeRecord(int a, int b, double c, string d)
            {
                id = a;
                account = b;
                volume = c;
                comment = d;
            }
        }

        private string _pathBinaryFiles = null; //путь и имя создаваемого бинарного файла.
        private long _counter = 0; //счетчик записаных в файл строк.
        private ProcessMappingBase _processMapping;//текущий процент выполнения создания файла.       
        private int a = 0;//процент выполнения возвращаемый методом 'GetProcessMappingInPercent' 
        private int b = 0;//промежуточная переменная для определения частоты отображения процента выполнения.
         
        //конструктор пользовательский, класса 'BinaryFiles'
        public BinaryFiles(ProcessMappingBase processMapping)
        {
            _processMapping = processMapping;
        }

        public void BinaryFilesGenerator(string pathBinaryFiles, long quantityLine )
        {
            _pathBinaryFiles = pathBinaryFiles;           
            RandomString randoomString = new RandomString();

            Console.SetWindowSize(100, 20);
            Console.WriteLine("\n\n");
            Console.WriteLine($"Ждите, выполняется запись в  файл: {pathBinaryFiles} " );
            Console.WriteLine();
            

            try
            {
                //todo: тут иемеет смысл передать только один раз в конструктор quantityLine
                //ProcessMappingBase processMapping = new ProcessMappingGeneration(quantityLine);


                //todo: это тут не надо, как мы можем обойтись без этой операции
                File.WriteAllText(pathBinaryFiles, ""); //очистка содержимого файла (в случае если файл уже существует).

                using (var writer = new BinaryWriter(File.Open(pathBinaryFiles, FileMode.Append, FileAccess.Write)))
                {
                    for (int i = 0; i < quantityLine; i++)
                    {
                        
                        TradeRecord trade = new TradeRecord(0 + i, 777, 640 + i, randoomString.GetCommentRandom());

                        writer.Write(trade.id);
                        writer.Write(trade.account);
                        writer.Write(trade.volume);
                        writer.Write(trade.comment);

                        _counter++;

                        //отображение текушего процента выполнения    
                        a = _processMapping.GetProcessMappingInPercent();

                        if (a > b + 5)
                        {
                            Console.Write("\r");
                            Console.Write($"выполнено: {a} % ");
                            b = a;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                Console.Write("\r");
                Console.Write("выполнено: 100 % ");
                Console.WriteLine("\n\n");
                Console.WriteLine($"в файл {pathBinaryFiles} записано  {_counter}  строк(и) " );

            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
        }
    }
}



    
