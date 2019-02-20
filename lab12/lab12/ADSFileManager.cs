using System;
using System.IO;
using System.IO.Compression;
using static System.Console;

namespace lab12
{
    class ADSFileManager : ADSLog
    {
        string disk = "/Users/dianaagapkina/Desktop";
        DirectoryInfo[] directory;
        FileInfo file;
        FileInfo file2;
        string[] directoryes;
        string[] files;
        public ADSFileManager()
        {
            Add("Получаем файлы и директории в " + disk);
            directoryes = Directory.GetDirectories(disk);
            files = Directory.GetFiles(disk);
            directory = new DirectoryInfo[2];
            directory[0] = new DirectoryInfo("/Users/dianaagapkina/Desktop/ADSInspect");
            directory[1] = new DirectoryInfo("/Users/dianaagapkina/Desktop/ADSFiles");
            if (directory[0].Exists)
            {
                Add(directory[0] + " - существует. Удаляем.");
                directory[0].Delete(true);
            }
            if (directory[1].Exists)
            {
                Add(directory[1] + " - существует. Удаляем.");
                directory[1].Delete();
            }
            if (File.Exists("/Users/dianaagapkina/Desktop/ya.zip"))
            {
                Add("ya.zip - существует. Удаляем.");
                File.Delete("/Users/dianaagapkina/Desktop/ya.zip");
            }
        }
        public void Worker()
        {
            directory[0].Create();
            directory[1].Create();
            file = new FileInfo("/Users/dianaagapkina/Desktop/ADSInspect/ADSdirinfo.txt");
            Add("Создаем файл" + file);
            Add("Записываем информацию о файлах и папках в " + file);
            using (StreamWriter fs = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
            {
                foreach (string s in files)
                {
                    fs.WriteLine(s);
                }
                foreach (string s in directoryes)
                {
                    fs.WriteLine(s);
                }
                WriteLine("Текст записан в файл.");
            }
            Add("Перемещаем файл " + file + " в " + "/Users/dianaagapkina/Desktop/ADSInspect/bong.txt");
            file.CopyTo("/Users/dianaagapkina/Desktop/ADSInspect/bong.txt");
            file.Delete();
            DirectoryInfo dir = new DirectoryInfo("/Users/dianaagapkina/Desktop/good");
            dir.Create();
            Add("Получаем информацию о png файлах в /Users/dianaagapkina/Desktop/good");
            FileInfo[] f = dir.GetFiles("*.png");
            Add("Копируем файлы png из /Users/dianaagapkina/Desktop/good в /Users/dianaagapkina/Desktop/ADSInspect/");
            foreach (FileInfo s in f)
            {
                s.CopyTo("/Users/dianaagapkina/Desktop/ADSFiles/" + s.Name, true);
            }
            Add("Перемещаем " + directory[1] + " в " + directory[0]);
            directory[1].MoveTo("/Users/dianaagapkina/Desktop/ADSInspect/ADSFiles");
            ZipFile.CreateFromDirectory(directory[1].ToString(), "/Users/dianaagapkina/Desktop/ya.zip");
            Add("Разархивируем /Users/dianaagapkina/Desktop/ya.zip в /Users/dianaagapkina/Desktop/");
            ZipFile.ExtractToDirectory("/Users/dianaagapkina/Desktop/ya.zip", "/Users/dianaagapkina/Desktop/");
        }
    }

}
