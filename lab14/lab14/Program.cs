using System;
using static System.Console;
using System.IO;
using System.Text;
using System.Threading;

namespace lab14
{
    class Program
    {
        private static EventWaitHandle waitHandle = new ManualResetEvent(initialState: true);

        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                Write("Write some number: ");
                if (int.TryParse(ReadLine(), out n))
                    break;
                else
                    WriteLine("Try again");
            }
            Thread secondThread = new Thread(WriteNumbersEverywhere);
            secondThread.Name = "SecondThread";

            methods.WriteProcessToFile(@"processInfo.txt");
            methods.CurrentDomainInfo();

            secondThread.Start(n);
            methods.NewDomainActions();
            // Stoped thread
            waitHandle.Reset();

            WriteLine("Thread status: " + secondThread.ThreadState.ToString());
            WriteLine("Thread Name: " + secondThread.Name.ToString());
            WriteLine("Thread id: " + secondThread.ManagedThreadId.ToString());

            for (int i = 0; i < 100; i++)
                WriteLine("Thread paused " + i);
            // Resume thread
            waitHandle.Set();

            if (secondThread.IsAlive)
            {
                WriteLine("\n\nThread status: " + secondThread.ThreadState.ToString());
                WriteLine("Thread Name: " + secondThread.Name.ToString());
                WriteLine("Thread id: " + secondThread.ManagedThreadId.ToString());
            }
            else
                WriteLine("Thread is dead\n\n");
            WriteLine("====================================================");

            Thread oddThread = new Thread(methods.OddAndEvenNumbersToConsole);
            oddThread.Name = "oddThread";
            Thread evenThread = new Thread(methods.OddAndEvenNumbersToConsole);
            evenThread.Name = "evenThread";
            evenThread.Priority = ThreadPriority.Highest;

            // true = odd numbers, false = even numbers
            ValueTuple<int, bool> oddnum = (n, true);
            ValueTuple<int, bool> evennum = (n, false);

            oddThread.Start(oddnum);
            evenThread.Start(evennum);

            // Waiting for end of processes
            Thread.Sleep(2000);
            methods.OddAndEvenNumbersToFile();
            WriteLine("====================================================");

            TimerCallback tm = new TimerCallback(RandomTimerMethod);
            Timer timer = new Timer(tm, 10, 0, 2000);

            ReadLine();
            WriteLine("====================================================");

            // Coming soon
        }

        static void WriteNumbersEverywhere(object num)
        {
            int n = (int)num;
            using (StreamWriter sw = new StreamWriter(@"Numbers.txt", false, Encoding.Default))
            {
                for (int i = 0; i < n; i++)
                {
                    WriteLine("Second thread: " + i);
                    sw.WriteLine("Second thread: " + i);
                    Thread.Sleep(0);
                    waitHandle.WaitOne();
                }
            }
        }

        static void RandomTimerMethod(object count)
        {
            int n = (int)count;
            for (int i = 1; i < 9; i++, n++)
                WriteLine("Timer " + (n * i).ToString());
        }
    }
}
