using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converting
{
    /// <summary>
    /// класс 'ConverterCsvToBinary' преобразует файл из формата Csv в бинарный,
    /// а так же обрамляет процесс  в фоновую задачу.
    /// </summary>


    public class ConverterCsvToBinary : IConverter
    {
        //преобразует файл из формата Csv в бинарный.
        public void Converts(string srcPath, string destPath)
        {
            throw new System.NotImplementedException();
        }

        //обрамляет в фоновую задачу
        public Task ConvertAsync(string srcPath, string destPath)
        {
            throw new System.NotImplementedException();
        }
    }
}
