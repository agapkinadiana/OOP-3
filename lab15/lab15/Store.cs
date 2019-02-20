using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab15
{
    public static class Store
    {
        public static BlockingCollection<string> store;
        static string[] products = { "fridge", "iron", "TV", "microwave", "oven" };
        static int x = 0;
        public static void Producer()
        {
            for (int producer = 1; producer <= products.Length; producer++)   //add
            {
                store.Add(products[x]);
                WriteLine($"Producer {producer}  add " + products[x]);
                x++;
            }
            store.CompleteAdding();
        }

        public static void Consumer()
        {
            for (int consumer = 1; consumer <= 10; consumer++)
            {
                if (store.TryTake(out products[store.Count]))
                {
                    WriteLine($"Sold product ");
                }
                else
                {
                    WriteLine($"Consumer left...");
                }
            }
        }
    }
}
