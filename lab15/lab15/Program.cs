using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab15
{
    class Program
    {
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static CancellationToken token = cancelTokenSource.Token;

        static async Task DisplayResultAsync()
        {
            int result = await FactorialAsync(10);
            Thread.Sleep(3000);
            WriteLine("Factorial of number {0} equal {1}", 10, result);
        }
        static Task<int> FactorialAsync(int x)
        {
            int result = 1;
            return Task.Run(() =>
            {
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                return result;
            });
        }

        static void Main(string[] args)
        {
            Tasker.GetTask(100000, 2);
            Tasker.GetTask(100000, 4);
            Tasker.GetTask(100000, 36);
            WriteLine("____________");
            Task task = new Task(() =>
            {
                Tasker.GetTask(100000, 64);
                if (token.IsCancellationRequested)
                {
                    WriteLine("Операция прервана токеном");
                    return;
                }
            });
            Tasker.FourSum(new Vector(100), new Vector(20), new Vector(30)).GetAwaiter().GetResult();

            Paralleler.For();
            Paralleler.ForEach();
            Paralleler.DoubleTask(100000);

            Store.store = new BlockingCollection<string>();
            Task pr = new Task(Store.Producer);
            Task cn = new Task(Store.Consumer);
            pr.Wait(1000);
            cn.Wait(1000);
            pr.Start();
            cn.Start();

            Task t = DisplayResultAsync();
            t.Wait();
        }
    }
}
