﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    ///<symmary>
    ///интерфейс 'IConverter' устанавливает методы по конвертации и обромлению в задачу.
    ///<symmary>

    public interface IConverter
    {
        //метод 'Convert' преобразует файл из одного формата в другой
        void Convert(string srcPath, string destPath);

        //Метод 'GetConvertAsync' возвращает фоновую задачу 
        Task GetConvertAsync(string srcPath, string destPath);

    }
}
