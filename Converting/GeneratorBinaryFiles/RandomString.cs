using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    ///<symmary>
    ///класс 'RandomString' заполняем столбец 'коментарий' случайными значениями
    ///<symmary>

    class RandomString
    {

        Random random = new Random(DateTime.Now.Millisecond);

        private string _sumString = null;// "склеянная строка со случайными значениями по текущей сделке"
        private int _number = 0;         // номер варианта случайной строки
        private int _profit = 0;         // сумма по прибыльной сделке
        private int _loss = 0;           // сумма по убыточной сделке


        public string GetCommentRandom()
        {
            _number = random.Next(0, 6);
            _loss = random.Next(-1000, 0);
            _profit = random.Next(0, 10000);

            switch (_number)
            {
                case 0:
                    _sumString = $"   trade:Sell   result:Profit   + { _profit }  $";
                    break;
                case 1:
                    _sumString = $"   trade:Sell   result:Loss       { _loss   }  $";
                    break;
                case 2:
                    _sumString = $"   trade:Bay    result:Profit   + { _profit }  $";
                    break;
                case 3:
                    _sumString = $"   trade:Bay    result:Loss       { _loss   }  $";
                    break;
                case 4:
                    _sumString = $"   trade:Bay    result:Stoploss   { _loss   }  $";
                    break;
                case 5:
                    _sumString = $"   trade:Sell   result:Stoploss   { _loss   }  $";
                    break;
            }

            return _sumString;
        }
    }
}
