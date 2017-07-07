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


    public class ProcessMappingConvertion : ProcessMappingBase//наследуемся от абстрактного класса
    {
        private readonly string _pathToFinalFile; //путь конечного бинарного файла 


        //конструктор класса 'ProcessMappingConvertion'
        public ProcessMappingConvertion(string pathToSrcFile, string pathToFinalFile) : base(GetCount(pathToSrcFile))
        {
            _pathToFinalFile = pathToFinalFile;
        }

        
        
        //статический метод 'GetCount', возвращает текущий размер файла
        public static long GetCount(string pathToFile)
        {
            var fi = new FileInfo(pathToFile);
            return fi.Length;
        }

        //метод 'RecalculateFinalValue' пересчитывает текущий размер сконвертированного файла
        protected override void RecalculateFinalValue()
        {
            _currentValue = GetCount(_pathToFinalFile);
        }

        // свойство при чтении  корректирующего коэффициента 
        protected override double _correctionValue
        {
            get { return 1.1; }
        }
        
    }
}
