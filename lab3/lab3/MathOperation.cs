using System;
using static System.Console;

namespace lab3
{
    public static class MathOperation
    {
        public static void Search(this Array arr, int x)
        {
            for (int i = 0; i < arr.LenghtOfArray;i++)
            {
                if (arr[i] == x)
                    WriteLine("Number is in the array");
            }
        }

        public static void Delete (Array arr)
        {
            for (int i = 0; i < arr.LenghtOfArray; i++)
            {
                if (arr[i] < 0)
                    arr[i] = 0;
            }
        }

        public static int MaxElement(Array arr)
        {
            int max = 0;
            for (int i = 0; i < arr.LenghtOfArray; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        public static int MinElement(Array arr)
        {
            int min = 999;
            for (int i = 0; i < arr.LenghtOfArray; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        public static int CountElements(Array arr)
        {
            int count = 0;
            for (int i = 0; i < arr.LenghtOfArray; i++)
                count++;
            return count;
        }

        public static bool CheckStr (this string str, char a)
        {
            for (int i = 0; i < str.Length;i++)
            {
                if (str[i] == a)
                    return true;
            }
            return true;
        }
    }
}
