using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBinaryFiles
{
    ///<symmary>
    ///класс 'RandomString' заполняем столбец 'коментарий' случайными значениями
    ///<symmary>

    class RandomString
    {

        Random r = new Random(DateTime.Now.Millisecond);

        private string sumString = null;// "склеянная строка со случайными значениями по текущей сделке"
        private int number = 0;         // номер варианта случайной строки
        private int profit = 0;         // сумма по прибыльной сделке
        private int loss = 0;           // сумма по убыточной сделке


        public string GetCommentRandom()
        {
            number = r.Next(0, 6);
            loss = r.Next(-1000, 0);
            profit = r.Next(0, 10000);

            switch (number)
            {
                case 0:
                    sumString = "   trade:Sell   result:Profit     " + "   +" + profit + " $";
                    break;
                case 1:
                    sumString = "   trade:Sell   result:Loss           " + loss + " $";
                    break;
                case 2:
                    sumString = "   trade:Bay    result:Profit     " + "  +" + profit + " $";
                    break;
                case 3:
                    sumString = "   trade:Bay    result:Loss          " + loss + " $";
                    break;
                case 4:
                    sumString = "   trade:Bay    result:Stoploss  " + loss + " $";
                    break;
                case 5:
                    sumString = "   trade:Sell   result:Stoploss  " + loss + " $";
                    break;
            }

            return sumString;
        }
    }
}
