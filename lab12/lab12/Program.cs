using System;
using static System.Console;

namespace lab12
{

    class Program
    {
        static void Main(string[] args)
        {
            ADSDiskInfo first = new ADSDiskInfo();
            first.FreePlace();
            WriteLine();

            ADSFileInfo second = new ADSFileInfo();
            second.fileInfo();
            WriteLine();

            ADSDirInfo third = new ADSDirInfo();
            third.DirInfo();
            WriteLine();

            ADSFileManager fourth = new ADSFileManager();
            fourth.Worker();

            WriteLine("___________________________________________________________");

            ADSLog log = new ADSLog();
            log.Read();
            WriteLine(DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year);
            log.Search();
            log.DeleteTime();
        }
    }
}
