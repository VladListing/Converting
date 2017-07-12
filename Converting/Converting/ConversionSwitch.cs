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
