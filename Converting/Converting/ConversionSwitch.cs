using Converter;
using ProcessMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Converting.InputArguments;

namespace Converting
{
    ///<symmary>
    /// класс 'ConversionSwitch' организует выбор типа преобразования.
    /// с помощью параметра 'revert'выбираем тип преобразования:
    ///-(true)-преобразование из бинарного файла в файл Csv;
    ///-(false)-преобразование из файла Csv в бинарный файл. 
    ///<symmary>

    public class ConversionSwitch
    {       
        private  ProcessMappingBase processMapping = null;

        public  IConverter GetConverter(string pathBinaryFile, string pathCsvFile, bool revert)
        {            
            if (revert)
            {                
                return new ConverterBinaryToCsv(processMapping = new ProcessMappingConvertion(pathBinaryFile, pathCsvFile));
            }
            else
            {
                return new ConverterCsvToBinary();
            }
        }
    }
}
