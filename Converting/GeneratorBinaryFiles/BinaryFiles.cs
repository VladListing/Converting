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
    /// класс 'BinaryFiles' генерирует бинарные файлы с заданым количеством строкб, заданной структуры.
    ///<symmary>

    class BinaryFiles
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

        private string pathBinaryFiles = ""; //путь и имя создаваемого бинарного файла.
        private long counter = 0; //счетчик записаных в файл строк.        

        public void BinaryFilesGener(string pathBinaryFiles, long quantityLine)
        {
            this.pathBinaryFiles = pathBinaryFiles;

            Console.SetWindowSize(90, 20);

            Console.WriteLine("\n\n");
            Console.WriteLine("Ждите, выполняется запись в  файл: {0} ", pathBinaryFiles);
            Console.WriteLine();

            RandomString randoomString = new RandomString();

            try
            {
                //todo. ?
                ProcessMappingBase processMapping = new ProcessMappingGeneration(quantityLine);

                //todo. ?
                File.WriteAllText(pathBinaryFiles, ""); //очистка содержимого файла (в случае если файл уже существует).

                using (var writer = new BinaryWriter(File.Open(pathBinaryFiles, FileMode.Append, FileAccess.Write)))
                {
                    for (int i = 0; i < quantityLine; i++)
                    {
                        //TradeRecord trade = new TradeRecord(0 + i, 777, 640 + i, RandomString.GetCommentRandom());
                        TradeRecord trade = new TradeRecord(0 + i, 777, 640 + i, randoomString.GetCommentRandom());

                        writer.Write(trade.id);
                        writer.Write(trade.account);
                        writer.Write(trade.volume);
                        writer.Write(trade.comment);

                        counter++;

                        //отображение текушего процента выполнения    
                        processMapping.ProcessMappingInPercent();
                    }
                }

                Console.Write("\r");
                Console.Write("выполнено: 100 % ");
                Console.WriteLine("\n\n");
                Console.WriteLine("в файл {0} записано  {1}  строк(и) ", pathBinaryFiles, counter);

            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
        }
    }
}



    
