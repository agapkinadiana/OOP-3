using System;
namespace lab2
{
    public partial class Vector
    {
        private int lenghtOfVector { get; set; }
        private int[] array;
        private readonly int ID = 0;
        private int status { get; set; }
        private static int count { get; set; } = 0;

        public int[] Array
        {
            get => array;

            private set => array = value;
        }

        public int this[int i]
        {
            get => array[i];
            set
            {
                if (value > 15)
                {
                    status = 1;
                }
                else
                    array[i] = value;
            }
        }

        static Vector()
        {

        }

        private Vector(int Item1, int Item2, int size)
        {
            array = new int[] { Item1, Item2};
            lenghtOfVector = size;
            count++;
            this.ID = GetHashCode();
        }

        public Vector()
        {
            Console.WriteLine("Enter the number of vector elements: ");
            lenghtOfVector = int.Parse(Console.ReadLine());
            array = new int[lenghtOfVector];
            Console.WriteLine("Vector elements: ");
            for (int i = 0; i < lenghtOfVector; i++)
                array[i] = int.Parse(Console.ReadLine());
            count++;
        }

        public Vector(int size)
        {
            array = new int[size];
            lenghtOfVector = size;
            Console.WriteLine("Vector elements: ");
            for (int i = 0; i < lenghtOfVector; i++)

                array[i] = int.Parse(Console.ReadLine());
            count++;
        }

        public Vector(int Item1, int Item2, int Item3, int Item4, int size)
        {
            array = new int[] { Item1, Item2, Item3, Item4 };
            lenghtOfVector = size;
            count++;
        }

        public void Print()
        {
            for (int i = 0; i < this.lenghtOfVector; i++)
                Console.Write(array[i] + " ");
        }

        public static int GetCount()
        {
            return count;
        }

        public int SumOfElements()
        {
            int sum = 0;
            foreach (int k in array)
            {
                sum += k;
            }
            return sum;
        }

        public int SumOfElements(ref int num)//сумма с числом и с ref параметром
        {
            int sum = SumOfElements() + num;
            return sum;
        }

        public int Increase()
        {
            int increase = 1;
            foreach (int k in array)
            {
                increase *= k;
            }
            return increase;
        }

        public bool IsNullInArray()
        {
            for (int i = 0; i < this.lenghtOfVector; i++)
            {
                if (array[i] == 0)
                    return true;
            }
            return false;
        }

        public double ModuleOfVector()
        {
            double mod = 0;
            for (int i = 0; i < array.Length; i++)
            {
                mod += array[i] * array[i];
            }
            mod = Math.Sqrt(mod);
            return mod;
        }

    }

    public partial class Vector
    {
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Vector vect = (Vector)obj;
            return (this.lenghtOfVector == vect.lenghtOfVector);
        }

        public override int GetHashCode()
        {
            return count;
        }

        public override string ToString()
        {
            return "Lenght of vector" + lenghtOfVector;
        }
    }
}
