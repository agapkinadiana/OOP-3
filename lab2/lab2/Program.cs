using System;

namespace lab2
{
    class Program
    {
        public static void Sum(int A, int B, out int sum)
        {
            sum = A + B;
        }

        static void Main(string[] args)
        {
            Vector v1 = new Vector();
            v1.Print(); Console.WriteLine();
            int a = 5;
            Console.WriteLine("Multiplication of vector elements: " + v1.Increase());
            Console.WriteLine("Module of vector elements: " + v1.ModuleOfVector());
            Console.WriteLine("Sum of vector elements with number: " + v1.SumOfElements(ref a));
            Console.WriteLine("Sum of vector elements: " + v1.SumOfElements());
            Console.WriteLine();
            Console.WriteLine(v1.GetHashCode());

            Vector v2 = new Vector(4);
            v2.Print(); Console.WriteLine();
            Console.WriteLine("Multiplication of vector elements: " + v2.Increase());
            Console.WriteLine("Module of vector elements: " + v2.ModuleOfVector());
            Console.WriteLine("Sum of vector elements: " + v2.SumOfElements());
            Console.WriteLine();
            Console.WriteLine(v1.Equals(v2));
            Console.WriteLine();

            Vector v3 = new Vector(4, 5, 6, 7, 4);
            v3.Print(); Console.WriteLine();
            Console.WriteLine("Multiplication of vector elements: " + v3.Increase());
            Console.WriteLine("Module of vector elements: " + v3.ModuleOfVector());
            Console.WriteLine("Sum of vector elements: " + v2.SumOfElements());
            Console.WriteLine();

            Console.WriteLine("Number of vectors: " + Vector.GetCount());

            Vector[] vectors = { v1, v2, v3 };

            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].IsNullInArray())
                    Console.WriteLine("{0} vector contains 0", (i + 1));
            }

            Console.WriteLine();

            double t1 = v1.ModuleOfVector();
            double t2 = v2.ModuleOfVector();
            double t3 = v3.ModuleOfVector();

            Console.Write("longest vector: ");

            if (t1 > t2 && t1 > t3)
            {
                v1.Print();
            }

            else if (t2 > t1 && t2 > t3)
            {
                v2.Print();
            }

            else if (t3 > t2 && t3 > t1)
            {
                v3.Print();
            }

            Console.WriteLine(); Console.WriteLine();

            int a1, b1, sum;
            a1 = 5;
            b1 = 10;
            Console.WriteLine("a1 = {0}\nb1 = {1}\n", a1, b1);
            Sum(a1, b1, out sum);
            Console.WriteLine("a1 + b1 = " + sum);
            Console.WriteLine();

            var v4 = new Vector(4);
            Console.WriteLine(v4.GetType());
        }
    }
}
