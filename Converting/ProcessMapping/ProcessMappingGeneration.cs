using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMapping
{
    ///<symmary>
    ///класс 'ProcessMappingGeneration' отображает текуший процента выполнения генерации строк в процентах.
    ///<symmary>
     

    public class ProcessMappingGeneration : ProcessMappingBase//наследуемся от абстрактного класса
    {
        //метод 
        public ProcessMappingGeneration(long totalCount) : base(totalCount)
        {
        }

        //метод 'RecalculateFinalValue' пересчитывает текущее количество строк в сгенерированном файле, (тип переопределяющий)
        protected override void RecalculateFinalValue()
        {
            currentValue = counter;
        }

        // присвоение значения корректирующему коэффициенту (тип переопределяющий)
        protected override double CorrectionValue
        {
            get { return 1.0; }
        }
    }
}
