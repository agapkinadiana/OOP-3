using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab15
{
    public class Vector
    {
        Random random = new Random();
        public List<int> vector = new List<int>();
        public Vector(int n)
        {
            for (int i = 0; i < n; i++)
            {
                vector.Add(random.Next(n));
            }
        }
        public int Length
        {
            get { return vector.Count; }
        }
        public int this[int number]
        {
            get { return vector[number]; }
            set { vector[number] = value; }
        }
        public void Print()
        {
            foreach (var number in vector)
            {
                Write(number + " ");
            }
            WriteLine();
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < vector.Count; i++)
            {
                sum += vector[i];
            }
            return sum;
        }
        public void Sort()
        {
            vector.Sort();
        }
        public static Vector operator *(Vector vec, int n)
        {
            for (int i = 0; i < vec.vector.Count; i++)
            {
                vec.vector[i] *= n;
            }
            return vec;
        }
    }
}
