using System;
using static System.Console;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab14
{
    class methods
    {
        static object locker = new object();
        static string oddNum;
        static string evenNum;

        public static void OddAndEvenNumbersToConsole(object num)
        {
            // true = odd numbers, false = even numbers
            //lock (locker)
            //{
                var n = (ValueTuple<int, bool>)num;
                for (int i = 0; i < n.Item1; i++)
                {
                    if (i % 2 == 1 && n.Item2)
                    {
                        string str = "Odd Thread: " + i + "\n";
                        Write(str);
                        oddNum += str;
                      //  Thread.Sleep(100);
                    }
                    if (i % 2 == 0 && !n.Item2)
                    {
                        string str = "Even Thread: " + i + "\n";
                        Write(str);
                        evenNum += str;
                        Thread.Sleep(0);
                       // Thread.Sleep(100);
                    }
                }
            //}
        }

        public static void OddAndEvenNumbersToFile()
        {
            using (StreamWriter sw = new StreamWriter(@"OddEvenNumbers.txt", false, Encoding.Default))
            {
                sw.WriteLine(oddNum);
                sw.WriteLine(evenNum);
            }
        }


        public static void WriteProcessToFile(string path)
        {
            var process = Process.GetProcesses();
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (var p in process)
                {
                    sw.WriteLine("ProcName: " + p.ProcessName);
                    sw.WriteLine("ProcId: " + p.Id);
                    //sw.WriteLine("ProcPriority: " + p.BasePriority);
                    //sw.WriteLine("ProcStartTime: " + p.StartTime.ToString());
                    //sw.WriteLine("ProcWorkingTime: " + p.TotalProcessorTime);
                    sw.WriteLine("\n\n");
                }
            }
            WriteLine("First task has complete\n\n");
        }


        public static void CurrentDomainInfo()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            WriteLine("Domain id: " + domain.Id);
            WriteLine("Domain name: " + domain.FriendlyName);
            WriteLine("Domain base directory: " + domain.BaseDirectory);
            Assembly[] assemblies = domain.GetAssemblies();
            WriteLine("Assemblies:");
            foreach (var ass in assemblies)
                WriteLine("Name: " + ass.GetName().Name);
        }

        public static void NewDomainActions()
        {
            AppDomain domain = AppDomain.CreateDomain("My custom domain");
            domain.AssemblyLoad += DomainAssLoadEvent;
            domain.DomainUnload += DomainUnloadEvent;

            // Need to copy it to /bin/debug/
            domain.Load(new AssemblyName("System.Data"));
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (var ass in assemblies)
            {
                WriteLine("Name: " + ass.GetName().Name);
                Thread.Sleep(50);
            }

            AppDomain.Unload(domain);
        }
        private static void DomainUnloadEvent(object sender, EventArgs e) => WriteLine("Домен выгружен из процесса");
        private static void DomainAssLoadEvent(object sender, AssemblyLoadEventArgs args) => WriteLine("Сборка загружена");

    }
}

