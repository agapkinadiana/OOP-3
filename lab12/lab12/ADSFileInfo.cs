using System;
using System.IO;
using static System.Console;

namespace lab12
{
    class ADSFileInfo : ADSLog
    {
        FileInfo file;
        public ADSFileInfo()
        {
            file = new FileInfo("ADSlogfile.txt");
        }
        public void fileInfo()
        {
            Add("Выполняем вывод информации о файле " + file);
            WriteLine($"Полный путь: {file.DirectoryName}");
            WriteLine($"Имя: {file.Name}");
            WriteLine($"Расширение: {file.Extension}");
            WriteLine($"Время создания: {file.CreationTime}");
        }
    }
}
