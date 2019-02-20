using System;
using static System.Console;

namespace lab3
{
    public class Array
    {
        Random key = new Random();
        private int[] array;
        private int lenghtOfArray;

        public Array(int size)
        {
            array = new int[size];
            lenghtOfArray = size;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = key.Next(-5, 10);
            }

        }

        public Array()
        {

        }

        public void printArray()
        {
            for (int i = 0; i < this.lenghtOfArray; i++)
            {
                Write("|{0}|", this[i]);
            }
            WriteLine();
        }

        public int LenghtOfArray
        {
            get => lenghtOfArray;
            set => lenghtOfArray = value;
        }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public static Array operator * (Array arr1, Array arr2)
        {
            Array arr;
            int length1 = arr1.array.Length, length2 = arr2.array.Length;
            int tmp;
            if (length1 > length2)
            {
                arr = new Array(length1);
                tmp = length2;
            }
            else
            {
                tmp = length1;
                arr = new Array(length2);
            }

            for (int i = 0; i < tmp;i++)
            {
                arr.array[i] = (arr1.array[i] * arr2.array[i]);
            }
            return arr;
            
        }

        public static bool operator true (Array arr)
        {
            for (int i = 0; i < arr.array.Length; i++)
            {
                if (arr[i] < 0)
                    return false;
            }
            return true;
        }

        public static bool operator false(Array arr)
        {
            for (int i = 0; i < arr.array.Length; i++)
            {
                if (arr[i] < 0)
                    return false;
            }
            return true;
        }

        public static explicit operator int (Array arr)
        {
            return arr.lenghtOfArray;
        }

        public static bool operator == (Array arr1, Array arr2)
        {
            int length1 = arr1.array.Length, length2 = arr2.array.Length;
            int tmp = length1 > length2 ? length1 : length2;
            for (int i = 0; i < tmp; i++)
            {
                if(arr1.array[i] != arr2.array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Array arr1, Array arr2)
        {
            int length1 = arr1.array.Length, length2 = arr2.array.Length;
            int tmp = length1 > length2 ? length1 : length2;
            for (int i = 0; i < tmp; i++)
            {
                if (arr1.array[i] != arr2.array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator > (Array arr1, Array arr2)
        {
            int length1 = arr1.lenghtOfArray, length2 = arr2.lenghtOfArray;
            if (length1 > length2)
                return true;
            return false;
        }

        public static bool operator <(Array arr1, Array arr2)
        {
            int length1 = arr1.lenghtOfArray, length2 = arr2.lenghtOfArray;
            if (length1 < length2)
                return true;
            return false;
        }

        public class Owner
        {
            private int ID;
            private string name;
            private string organization;

            public Owner (int ID, string name, string organization)
            {
                this.ID = ID;
                this.name = name;
                this.organization = organization;
            }

            public void InfoAboutOwner()
            {
                WriteLine("ID: " + this.ID + " Name: " + this.name + " Organization: " + this.organization);
            }
        }

        public class CurrentDate
        {
            private int day;
            private int month;
            private int year;

            public CurrentDate (int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public void InfoAboutCurrentDate()
            {
                WriteLine("Day: " + this.day + " Month: " + this.month + " Year: " + this.year);
            }
        }
    }
}
