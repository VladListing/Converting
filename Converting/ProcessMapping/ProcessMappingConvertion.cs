using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMapping
{
    ///<symmary>
    ///класс 'ProcessMappingConvertion' отображает текуший процента выполнения конвертации файлов в процентах.
    ///<symmary>


    public class ProcessMappingConvertion : ProcessMappingBase//наследуемся от абстрактного класса
    {
        private readonly string _pathToFinalFile; //путь конечного бинарного файла (тип переменной : защищенный , только для чтения)

        public ProcessMappingConvertion(string pathToSrcFile, string pathToFinalFile) : base(GetCount(pathToSrcFile))
        {
            _pathToFinalFile = pathToFinalFile;
        }


        //статический метод 'GetCount', возвращает текущий размер файла
        private static long GetCount(string pathToFile)
        {
            var fi = new FileInfo(pathToFile);
            return fi.Length;
        }

        //метод 'RecalculateFinalValue' пересчитывает текущий размер сконвертированного файла, (тип переопределяющий)
        protected override void RecalculateFinalValue()
        {
            currentValue = GetCount(_pathToFinalFile);
        }

        // присвоение значения корректирующему коэффициенту (тип переопределяющий)
        protected override double CorrectionValue
        {
            get { return 1.1; }
        }
    }
}
