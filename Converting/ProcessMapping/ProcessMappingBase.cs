using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMapping
{

    //перечень возможных режимов (пока два режима: Генерация, Конвертация )
    //public enum ProcessMode
    //{
    //    Converting,
    //    Generation
    //}




    ///<symmary>
    /// Абстрактный класс 'processMapping' отображает текуший процент выполнения конвертации (загрузки) в процентах.
    ///<symmary>
    

    public abstract class ProcessMappingBase
    {
        private readonly long _totalCount;  //общее количество
        private double _processPercent = 0; //текуший процента выполнения
        private int _displayPeriod = 0;     //периодичность отображения
        private int _counter1 = 0;          //счетчик проходов
        protected long counter = 0;         //счетчик проходов
        protected long currentValue = 0;    //текущий значение 

        protected abstract double CorrectionValue { get; } //коэффициент корректировки

        //пользовательский конструктор класса
        protected ProcessMappingBase(long totalCount)
        {
            _totalCount = totalCount;
            InitDisplayPeriod(_totalCount);
        }

        //метод расчитывающий необходимую и достаточную периодичность расчета процента
        private void InitDisplayPeriod(long totalCount)
        {
            if (totalCount < 1000)
            {
                _displayPeriod = 1;
            }
            else if ((totalCount >= 1000) && (totalCount <= 1000000))
            {
                _displayPeriod = 10;
            }
            else if ((totalCount >= 1000000) && (totalCount <= 100000000))
            {
                _displayPeriod = 1000;
            }
            else if ((totalCount > 100000000) && (totalCount <= 1000000000))
            {
                _displayPeriod = 100000;
            }
            else if (totalCount > 1000000000)
            {
                _displayPeriod = 1000000;
            }
        }

        //метод расчитывающий  текущий процент выполнения 
        public void ProcessMappingInPercent()
        {
            counter++;
            _counter1++; //todo: counter += 1; counter++; ++counter


            if (_counter1 == _displayPeriod)
            {
                RecalculateFinalValue();

                _processPercent = (((currentValue / CorrectionValue) * 100) / _totalCount);

                if (_processPercent > 98)
                {
                    _processPercent = 99;
                }
                Console.Write("\r");
                Console.Write("выполнено: {0} % ", Math.Truncate(_processPercent));
                _counter1 = 0;
            }
        }

        //какойто абстрактный метод
        protected abstract void RecalculateFinalValue();

    }
}
