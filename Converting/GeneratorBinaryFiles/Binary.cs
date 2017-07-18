using ProcessMapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    ///<symmary>
    /// класс 'Binary' генерирует бинарные файлы с заданым количеством строк, заданной структуры.
    ///<symmary>

    public class Binary
    {
        //структура 'TradeRecord'.
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
        private ProcessMappingBase _processMapping;//экземпляр.       
        private int _currentPercentage = 0;//текущий процент выполнения. 
        private int _previousPercentage = 0;//предыдущий процент выполнения.       


        
        public Binary(ProcessMappingBase processMapping)
        {
            _processMapping = processMapping;
        }

        //метод.отображение текущего процента выполнения только при увеличении более чем на 5-ть %
        public void DisplayPercentage(int currentPercentage)
        {
            _currentPercentage = currentPercentage;
            if (_currentPercentage > _previousPercentage + 5)
            {
                Console.Write("\r");
                Console.Write($"выполнено: {_currentPercentage} % ");
                _previousPercentage = _currentPercentage;
            }
            else
            {
            }
        }

        //создание бинарного файла
        public void Generating(string pathBinaryFiles, long quantityLine )
        {
            Console.SetWindowSize(100, 20);
            Console.WriteLine($"Ждите, выполняется запись:  {quantityLine} строк(и)  в файл: {pathBinaryFiles} " );
            Console.WriteLine();

            _pathBinaryFiles = pathBinaryFiles;
            RandomString randoomString = new RandomString();

            try
            {                
                File.WriteAllText(pathBinaryFiles, null); 

                using (var writer = new BinaryWriter(File.Open(pathBinaryFiles, FileMode.Append, FileAccess.Write)))
                {
                    for (int i = 0; i < quantityLine; i++)                    {                        
                        TradeRecord trade = new TradeRecord(0 + i, 777, 640 + i, randoomString.GetCommentRandom());
                        writer.Write(trade.id);
                        writer.Write(trade.account);
                        writer.Write(trade.volume);
                        writer.Write(trade.comment);
                        _counter++;

                        //процента выполнения    
                        _currentPercentage = _processMapping.GetProcessMappingInPercent();                        
                        DisplayPercentage(_currentPercentage);
                    }
                }

                Console.Write("\r");
                Console.Write("выполнено: 100 % ");
                Console.WriteLine("\n\n");
                Console.WriteLine($"в файл: {pathBinaryFiles}  записано  {_counter}  строк(и) " );

            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
        }
    }
}



    
