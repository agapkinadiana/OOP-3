using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab15
{
    public static class Paralleler
    {
        public static void For()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Generate(10000);
            watch.Stop();
            WriteLine("Common loop: {0}", watch.Elapsed);
            watch.Start();
            Parallel.For(1, 10000, Generate);   //start, stop, method
            watch.Stop();
            WriteLine("Parallel loop: {0}", watch.Elapsed);
        }
        public static void ForEach()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach (int vec in new List<int>() { 10000, 10000 })
            {
                Generate(vec);
            }
            watch.Stop();
            WriteLine("Common loop: {0}", watch.Elapsed);
            watch.Start();
            ParallelLoopResult result = Parallel.ForEach(new List<int>() { 10000, 10000 }, Generate);   //collect, method
            watch.Stop();
            WriteLine("Parallel loop: {0}", watch.Elapsed);
        }
        public static void Generate(int n)
        {
            Vector vector = new Vector(n);
        }
        public static void DoubleTask(int n)
        {
            Parallel.Invoke(Display, () =>             // parall
            {
                WriteLine("Current task: {0}", Task.CurrentId);
                Thread.Sleep(3000);
                Generate(n);
            },
                                    () => Generate(n));
        }
        private static void Display()
        {
            WriteLine("Current task: {0}", Task.CurrentId);
            Thread.Sleep(3000);
        }
    }
}
