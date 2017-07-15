using ProcessMapping;
using System;




namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            //инициализируем и проверяем входные аргументы.
            InputArguments inputArguments = new InputArguments();
            var verifiedInputArguments = inputArguments.GetCheckingInputArguments(args);

            //заданное количество строк в создаваемом бинарном файле.
            long quantityLine = Convert.ToInt64(verifiedInputArguments.quantityLine);

            //путь и имя создаваемого бинарного файла.  
            string partBinaryFile = verifiedInputArguments.pathBinaryFile;            
            
            Console.SetWindowSize(100, 20);
            
            //отображение текущего процента выполения генерации.
            ProcessMappingBase processMapping = new ProcessMappingGeneration(quantityLine);
                
            //генерация бинарного файла.
            Binary binaryFiles = new Binary(processMapping);
            binaryFiles.GeneratingBinaryFile(partBinaryFile, quantityLine);

            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
        }
    }
}
