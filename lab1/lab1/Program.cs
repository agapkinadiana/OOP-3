using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Задание 1------------\n");
            bool boo = true, bo = false;
            byte b = 10;                                    //хранит целое число от 0 до 255 и занимает 1 байт
            sbyte sb = -10;                                 //хранит целое число от -128 до 127 и занимает 1 байт
            short s = 102;                                  //хранит целое число от -32768 до 32767 и занимает 2 байта
            ushort us = 55;                                 //хранит целое число от 0 до 65535 и занимает 2 байта
            int i1 = 800, i2 = 0xFF, i3 = 0b101;            //хранит целое число от -2147483648 до 2147483647 и занимает 4 байта
            uint ui = 19;                                   //хранит целое число от 0 до 4294967295 и занимает 4 байта
            long l = -200;                                  //хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт
            ulong ul = 0b110;                               //хранит целое число от 0 до 18 446 744 073 709 551 615 и занимает 8 байт
            float f = 3.14F;                                //хранит число с плавающей точкой от -3.4*1038 до 3.4*1038 и занимает 4 байта
            double d = 56.78;                               //хранит число с плавающей точкой от ±5.0*10-324 до ±1.7*10308 и занимает 8 байта
            decimal dec = 27.55m;                           //если без десятичной запятой - от 0 до +/–79 228 162 514 264 337 593 543 950 335; если с запятой, то от 0 до +/–7,9228162514264337593543950335 с 28 разрядами после запятой и занимает 16 байт
            char ch = 'D';                                  //хранит одиночный символ в кодировке Unicode и занимает 2 байта
            string st = "Hello";                            //хранит набор символов Unicode
            object num = 5, num1 = 3.14, chr = 'K';         //может хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе и 8 байт на 64-разрядной платформе


            float fl = i1;
            long lo = ui;
            int ii = ch;
            decimal de = us;
            double db = b;
            Console.WriteLine($"int - float: {fl}\nuint - long: {lo}\nchar - int: {ii}\nushort - decimal: {de}\nbyte - double: {db}\n");

            Console.WriteLine("int - byte: {0}\nfloat - int: {1}\nint - short: {2}\ndecimal - int: {3}\ndouble - short: {4}\n", (byte)i1, (int)f, (short)i1, (int)dec, (short)d);

            int number = 23;
            object boxing = number;
            int unboxing = (int)boxing;

            var typenum = 18;
            Console.WriteLine("Тип переменной - {0}\n", typenum.GetType());

            int? a = null;
            int? c = 3;
            Console.WriteLine("Рез-тат первого выражения - {0}\nРез-тат второго выражения - {1}\n", (a ?? 1), (c ?? 8));

            Console.WriteLine("------------Задание 2------------\n");
            string str1 = "Hello";
            string str2 = "Hello";
            int result = String.Compare(str1, str2);
            if (result < 0)
            {
                Console.WriteLine("Строка s1 перед строкой s2 (по алфавиту)");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка s1 стоит после строки s2");
            }
            else
            {
                Console.WriteLine("Строки s1 и s2 идентичны");
            }

            string str3 = "first";
            string str4 = "second";
            string str5 = "third";
            string[] values = new string[] { str3, str4, str5 };
            Console.WriteLine("Конкатенация строк - {0}\n", /*String.Concat(str3, str4, str5)*/ String.Join(" ", values));

            string sttr = String.Copy(str4);
            Console.WriteLine($"Копирование строк - {sttr}\n");

            string str6 = str3.Substring(1, 3);
            Console.WriteLine($"Выделение подстроки из {str3} - {str6}\n");

            string text = "Hello World";
            string[] words = text.Split(new char[] { ' ' });
            foreach (string i in words)
            {
                Console.WriteLine(i);
            }

            string subString = "!!! ";
            text = text.Insert(6, subString);
            Console.WriteLine($"Вставки подстроки в заданную позицию - {text}\n");

            string text1 = "newstring";
            text1 = text1.Remove(0, 3);
            Console.WriteLine($"Удаление заданной подстроки - {text1}\n");

            string str7 = "";
            Console.WriteLine("The length of '{0}' is {1}.", str7, str7.Length);

            string str8 = null;
            try
            {
                Console.WriteLine("The length of '{0}' is {1}.", str8, str8.Length);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            System.Text.StringBuilder str9 = new System.Text.StringBuilder("world", 50);
            str9.Append("!");
            str9.Insert(0, "Hi ");
            Console.WriteLine($"Измененная строка - {str9}\n");
            str9.Remove(2, 6);
            Console.WriteLine($"После удаления - {str9}\n");

            Console.WriteLine("------------Задание 3------------\n");
            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            int rows = mas.GetUpperBound(0) + 1;       //количество строк таблицы
            int columns = mas.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{mas[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            string[] arr = { "cs", "de", "au", "pt", "sr" };
            foreach (var z in arr)
            {
                Console.Write(z + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Длина массива - {0}", arr.Length);
            Console.WriteLine("Какой эл-т изменить?");
            int numb = int.Parse(Console.ReadLine());
            Console.WriteLine("На какой эл-т изменить?");
            string change = Console.ReadLine();
            arr[numb] = change;
            Console.WriteLine();
            foreach (var z in arr)
            {
                Console.Write(z + " ");
            }
            Console.WriteLine();

            float[][] myArr1 = new float[3][];
            Console.WriteLine("Заполните матрицу");
            for (int k = 0; k < 3; k++)
            {
                int ly = k + 2;
                myArr1[k] = new float[ly];
                for (int z = 0; z < ly; z++)
                    myArr1[k][z] = float.Parse((Console.ReadLine()));
            }
            for (int k = 0; k < 3; k++)
            {
                int ly = k + 2;
                for (int z = 0; z < ly; z++)
                    Console.Write(myArr1[k][z] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();

            var array = new[] { 1, 2, 3 };
            var strg = "";
            Console.WriteLine();

            Console.WriteLine("------------Задание 4------------\n");
            var cortege = (count: 1, str1: "hello", ch: 'Q', str2: "world", toolong: 78998);
            Console.WriteLine(cortege);
            int k1 = cortege.count;
            char k2 = cortege.ch;
            string k3 = cortege.str2;
            Console.WriteLine(k1);
            Console.WriteLine(k2);
            Console.WriteLine(k3);
            Console.WriteLine();
            var newkortege = (4, "olleh", 'M', "dlrow", 89987);
            if (!Equals(cortege, newkortege))
                Console.WriteLine("false");

            Console.WriteLine("------------Задание 5------------\n");
            System.ValueTuple<int[], char> localfunc(int[] numbers, string testStr)
            {
                int max = int.MinValue, min = int.MaxValue, sum = 0;
                foreach (int el in numbers) 
                {
                    sum += el;
                    if (el > max)
                        max = el;
                    if (el < min)
                        min = el;
                }
                (int[], char)res = (new int[] { min, max, sum }, testStr[0]);
                return res;
            }
            var resultOfFunc = localfunc(new int[] { 1, 2, 3, 4 }, "test");
            Console.WriteLine(resultOfFunc.Item1[0]);
            Console.WriteLine(resultOfFunc.Item1[1]);
            Console.WriteLine(resultOfFunc.Item1[2]);
            Console.WriteLine(resultOfFunc.Item2);
        }
    }
}
