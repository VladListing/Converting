using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converting
{
    ///<symmary>
    ///интерфейс 'IConverter' устанавливает методы по конвертации и обрамлению их в фоновую задачу.
    ///<symmary>

    public interface IConverter
    {
        //преобразует файл из одного формата в другой
        void Converts(string srcPath, string destPath);

        //организует фоновую задачу 
        Task ConvertAsync(string srcPath, string destPath);

    }
}
