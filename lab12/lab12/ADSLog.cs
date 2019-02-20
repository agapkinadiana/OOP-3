using System;
using System.IO;
using static System.Console;

namespace lab12
{
    class ADSLog
    {
        private FileInfo file;
        private FileInfo file2;
        public ADSLog()
        {
            file = new FileInfo("ADSlogfile.txt");
            file2 = new FileInfo("test.txt");
        }
        public void Add(string a)
        {
            using (StreamWriter writer = new StreamWriter(file.ToString(), true, System.Text.Encoding.Default))
            {
                writer.WriteLine(DateTime.Now + " - " + a);
            }
        }
        public int Cnv(string a, int o)
        {
            int b, c, m, s;
            c = 3600 * int.Parse(a.Substring(0 + o, 2));
            m = 60 * int.Parse(a.Substring(3 + o, 2));
            s = int.Parse(a.Substring(6 + o, 2));
            b = c + m + s;
            return b;
        }
        public void Read()
        {
            using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
            {
                int a = 0;
                while (true)
                {
                    if (reader.EndOfStream)
                    {
                        break;
                    }
                    WriteLine(reader.ReadLine());
                    a++;
                }
                WriteLine("Кол.-во записей в файле: " + a);
            }
        }
        public void DeleteTime()
        {
            using (StreamWriter fs = new StreamWriter(file2.ToString(), false, System.Text.Encoding.Default))
            {
                string pl = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour.ToString() + ":";

                string str = "";
                WriteLine(pl);
                using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                {
                    while (true)
                    {
                        if (reader.EndOfStream)
                        {
                            break;
                        }
                        str = reader.ReadLine();
                        if (str.Contains(pl))
                        {
                            fs.WriteLine(str);
                        }
                    }
                }
            }
            file.Delete();
            file2.MoveTo("ADSlogfile.txt");
        }
        public void Search()
        {

            WriteLine("Поиск: \n1. Указать дату.\n2. Указать диапазон времени.\n3. Указать ключевое слово.");
            string a, b;
            int r = 1;
            while (r != 0)
            {
                r = int.Parse(ReadLine());
                switch (r)
                {
                    case 1:
                        using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                        {
                            WriteLine("Укажите дату в формате 01.01.2001: ");
                            a = ReadLine();
                            while (true)
                            {
                                if (reader.EndOfStream)
                                {
                                    break;
                                }
                                if (reader.ReadLine().Contains(a))
                                {
                                    WriteLine(reader.ReadLine());
                                }
                            }
                        }
                        break;
                    case 2:
                        using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                        {
                            WriteLine("Укажите первую часть времени: ");
                            a = ReadLine();
                            WriteLine("Укажите вторую часть времени: ");
                            b = ReadLine();
                            Cnv(a, 0);
                            Cnv(b, 0);
                            string str;
                            while (true)
                            {
                                if (reader.EndOfStream)
                                {
                                    break;
                                }
                                str = reader.ReadLine();
                                if (Cnv(str, 11) >= Cnv(a, 0) && Cnv(str, 11) <= Cnv(b, 0))
                                {
                                    WriteLine(str);
                                }

                            }
                        }
                        break;
                    case 3:
                        using (StreamReader reader = new StreamReader(file.ToString(), System.Text.Encoding.Default))
                        {
                            WriteLine("Введите ключевое слово: ");
                            a = ReadLine();
                            while (true)
                            {
                                if (reader.EndOfStream)
                                {
                                    break;
                                }
                                if (reader.ReadLine().Contains(a))
                                {
                                    WriteLine(reader.ReadLine());
                                }
                            }
                        }
                        break;
                }

            }
        }

    }
}
