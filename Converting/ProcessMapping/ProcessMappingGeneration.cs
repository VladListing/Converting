﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMapping
{
    ///<symmary>
    ///класс 'ProcessMappingGeneration' отображает текушее выполнения генерации строк в процентах.
    ///<symmary>
     

    public class ProcessMappingGeneration : ProcessMappingBase
    {
        
        public ProcessMappingGeneration(long totalCount) : base(totalCount)
        {
        }

        //пересчитывает текущее количество строк записанных в файл
        protected override void RecalculateFinalValue()
        {
            _currentValue = _counter;
        }

        // присвоение значения корректирующему коэффициенту 
        protected override double _correctionValue
        {
            get { return 1.0; }
        }
    }
}
