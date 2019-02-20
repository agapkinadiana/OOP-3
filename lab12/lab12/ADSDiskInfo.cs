using System;
using System.IO;
using static System.Console;

namespace lab12
{
    class ADSDiskInfo : ADSLog
    {
        public void FreePlace()
        {
            Add("Получаем информацию о дисках системы.");
            var allinfo = DriveInfo.GetDrives();
            foreach (var d in allinfo)
            {
                if (!d.IsReady) continue;
                WriteLine("Метка тома: {0}", d.RootDirectory);
                WriteLine("Имя диска: {0}", d.Name);
                WriteLine("Обьём: {0}", d.TotalSize);
                WriteLine("Доступный Обьём: {0}", d.AvailableFreeSpace);
                WriteLine("Файловая система: {0}", d.DriveFormat);
                WriteLine("Свободно места: {0}", d.TotalFreeSpace);
                WriteLine();
            }
        }
    }
}
