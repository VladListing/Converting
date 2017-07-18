using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMapping
{
    ///<symmary>
    /// Абстрактный класс 'processMapping' расчет текущего процента выполнения конвертации или генерации в процентах.
    ///<symmary>
    

    public abstract class ProcessMappingBase
    {
        private readonly long _totalCount=0; //общее количество (размер исходного файла или к-во строк)
        private double _processPercent = 0;  //текуший процента выполнения
        private int _displayPeriod = 0;      //периодичность отображения
        private int _counter1 = 0;           //счетчик к-ва строк после которого производиться перерасчет процента выполнения (обнуляемый)
        protected long _counter = 0;         //счетчик общего количества строк (не обнуляемый)
        protected long _currentValue = 0;    //текущий значение контролируемой величины по конечному файлу (размер или к-во строк)
        private int _percent = 0;            //текуший процент выполнения

        protected abstract double _correctionValue { get; } //свойство (Автоматическое) при чтении коэффициента корректировки 

        //пользовательский конструктор aбстрактного класса
        protected ProcessMappingBase(long totalCount)
        {
            _totalCount = totalCount;
            InitDisplayPeriod(_totalCount);
        }

        //опредиление необходимой и достаточной периодичности для расчета текушего процента выполнения
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

        //расчет  текущего процента выполнения 
        public int GetProcessMappingInPercent()
        {
            _counter++;
            _counter1++; 

            if (_counter1 == _displayPeriod)
            {
                RecalculateFinalValue();

                _processPercent = (((_currentValue / _correctionValue) * 100) / _totalCount);

                if (_processPercent > 98)
                {
                    _processPercent = 99;
                }
                
                _percent = (int)Math.Truncate(_processPercent);
                _counter1 = 0;
            }
            return _percent;
        }        


        //присвоение  текущего значение контролируемой величине в конечном файле 
        //(размер файла или к-во строк в нем)
        protected abstract void RecalculateFinalValue();
               
    }
}
