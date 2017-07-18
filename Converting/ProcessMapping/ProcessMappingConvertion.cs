using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMapping
{
    ///<symmary>
    ///класс 'ProcessMappingConvertion' отображает текушее выполнение конвертации файлов в процентах.
    ///<symmary>


    public class ProcessMappingConvertion : ProcessMappingBase
    {
        private readonly string _pathToFinalFile; //путь конечного бинарного файла 

        
        public ProcessMappingConvertion(string pathToSrcFile, string pathToFinalFile) : base(GetCalculationFileSize(pathToSrcFile))
        {
            _pathToFinalFile = pathToFinalFile;
        }

        
        
        //возвращает  размер  файла
        public static long GetCalculationFileSize(string pathToFile) 
        {
            var fi = new FileInfo(pathToFile);
            return fi.Length;
        }

        //пересчитывает текущий размер сконвертированного файла
        protected override void RecalculateFinalValue()
        {
            _currentValue = GetCalculationFileSize(_pathToFinalFile);
        }

        // свойство при чтении  корректирующего коэффициента 
        protected override double _correctionValue
        {
            get { return 1.1; }
        }
        
    }
}
