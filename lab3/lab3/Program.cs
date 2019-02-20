using System;
using static System.Console;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random key = new Random();
            WriteLine("Enter the size of array: ");
            int size = int.Parse(ReadLine());
            WriteLine();
            Array arr1 = new Array(size);
            arr1.printArray();
            Array arr2 = new Array(6);
            arr2.printArray();
            Array arr3 = new Array();
            arr3 = arr1 * arr2;
            arr3.printArray();
            WriteLine();
            if (arr3)
                WriteLine("Array doesn't contain negative elements");
            else
                WriteLine("Array contains negative elements");
            WriteLine();
            WriteLine("Size of array: " + (int)arr3);
            WriteLine();
            WriteLine("Equality: " + (arr1==arr2));
            WriteLine();
            Write("Enter the number which u want to find in array: ");
            int x = int.Parse(ReadLine());
            arr3.Search(x);
            WriteLine();
            if (arr1 > arr2)
                WriteLine("First array contains more elements");
            if (arr1 < arr2)
                WriteLine("Second array contains more elements");
            WriteLine();
            MathOperation.Delete(arr3);
            arr3.printArray();
            WriteLine();
            WriteLine("Max element in array: " + MathOperation.MaxElement(arr3));
            WriteLine("Min element in array: " + MathOperation.MinElement(arr3));
            WriteLine("Number of array elements: " + MathOperation.CountElements(arr3));
            WriteLine();

            string str = "hello";
            WriteLine(str.CheckStr('h'));
            WriteLine();
            Array.Owner owner = new Array.Owner(1, "Diana", "BSTU");
            owner.InfoAboutOwner();
            Array.CurrentDate date = new Array.CurrentDate(21, 10, 2018);
            date.InfoAboutCurrentDate();
        }
    }
}
