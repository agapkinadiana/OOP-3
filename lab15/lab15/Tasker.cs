using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab15
{
    public class Tasker
    {
        public static void GetTask(int size, int num)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Vector vector = new Vector(size);
            //vector.Print();
            Task task = Task.Factory.StartNew(() => vector = vector * num);
            WriteLine("Status: {0}", task.Status);
            task.Wait();
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            WriteLine("Run Time: " + elapsedTime);
            //vector.Print();
        }
        //task3,4
        public static async Task FourSum(Vector one, Vector two, Vector three)
        {
            Task<int> task1 = new Task<int>(() => one.Sum());
            task1.Start();
            Task<int> task2 = new Task<int>(() => two.Sum());
            task2.Start();
            Task<int> task3 = new Task<int>(() => three.Sum());
            task3.Start();
            Task<Vector> task4 = new Task<Vector>(() => new Vector(task1.Result + task2.Result + task3.Result));
            Task task5 = task4.ContinueWith(Display);
            task4.Start();
            task5.Wait();
            WriteLine(task4.Result.Sum());
        }
        public static void Display(Task task)
        {
            WriteLine("ID current: {0}", Task.CurrentId);
            WriteLine("ID before: {0}", task.Id);
            Thread.Sleep(3000);
        }
    }
}
