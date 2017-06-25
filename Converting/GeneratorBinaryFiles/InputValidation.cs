using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBinaryFiles
{
    ///<symmary>
    ///класс 'InputValidation' проверяет правильность ввода с клавиатуры целых положительных чисел
    ///<symmary>

    class InputValidation
    {
        private int _counter = 0;        //счетчик введеных символов
        private int _charNum = 0;        //номер по таблице символов
        private string _stringsKey = null; //введенное число (предварительно)
        private long _checkedNumber;     //проверенное введеное число

        //из таблици символов Юникода
        private const char _zeroChar = (char)48;
        private const char _nineChar = (char)57;


        //метод , возвращает проверенное  введенное с клавиатуры число 
        public long GetInputValidationKey()
        {
            Console.WriteLine();
            Console.WriteLine("Введите количество строк в создаваемом бинарном файле :");
            Console.WriteLine();

            ConsoleKeyInfo any = new ConsoleKeyInfo();

            while (any.Key != ConsoleKey.Enter)
            {
                if (Console.KeyAvailable == true)
                {
                    _charNum = (int)Console.ReadKey().KeyChar;
                    if (_charNum >= _zeroChar && _charNum <= _nineChar)
                    {
                        _stringsKey += (char)_charNum;
                        _counter++;
                    }
                    else
                    {
                        _counter = 0;
                        _stringsKey = null;
                        Console.Write("\r");
                        Console.Write("Ошибка, введите целое положительное число:");
                        Console.WriteLine();

                        continue;
                    }
                    any = Console.ReadKey(true);
                }
            }
            if (_counter != 0 && any.Key == ConsoleKey.Enter)
            {
                _checkedNumber = Convert.ToInt64(_stringsKey);
            }
            return _checkedNumber;
        }
    }
}
