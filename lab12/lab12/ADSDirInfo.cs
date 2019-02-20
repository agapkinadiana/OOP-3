using System;
using System.IO;
using static System.Console;

namespace lab12
{
    class ADSDirInfo : ADSLog
    {
        string dir = "/Users/dianaagapkina/Desktop/3 семестр";
        public void DirInfo()
        {
            if (Directory.Exists(dir))
            {
                Add("Получаем информацию о файлах и директориях в " + dir);
                string[] files = Directory.GetFiles(dir);
                string[] subdir = Directory.GetDirectories(dir);
                int a = 0;
                int b = 0;
                foreach (string s in files)
                {
                    a++;
                }
                foreach (string s in subdir)
                {
                    b++;
                }
                WriteLine("Количество файлов в папке: " + a);
                WriteLine("Время создания папки: " + Directory.GetCreationTime(dir));
                WriteLine("Количетсво поддиректориев в папке: " + b);
                WriteLine("Список родительских директориев: " + Directory.GetParent(dir));
            }
        }
    }
}
