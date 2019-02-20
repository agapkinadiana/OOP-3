using System;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            var class1 = new Class1();
            var class2 = new Class2();

            user.ShiftEvent += class1.Shift;
            user.ShiftEvent += class2.Shift;
            user.ShiftEvent += (x) => Console.WriteLine("Лямбда-выражение " + x);

            user.CompressionEvent += class1.Compress;
            user.CompressionEvent += class2.Compress;
            user.CompressionEvent += class2.Compress;
            user.CompressionEvent += class2.Compress;
            user.CompressionEvent -= class1.Compress;

            user.ShiftOrCompr(true, 20);
            Console.WriteLine("=================================");
            user.ShiftOrCompr(false, 30);

            Console.WriteLine("=================================");


            string str = "Hello, my name is Diana.";
            Action<string> actionOnConsole = (s) => Console.WriteLine(s);
            actionOnConsole(str);
            Func<string, string> func = User.AddSymbols;
            actionOnConsole(str = func(str));
            func += User.ToUpperCase;
            actionOnConsole(str = func(str));
            func += User.AfterFirstWord;
            actionOnConsole(str = func(str));
            func += User.RemoveSpaces;
            actionOnConsole(str = func(str));
            func += User.RemoveCommasDotes;
            actionOnConsole(str = func(str));
            func += User.ToBinary;
            actionOnConsole("Binary:");
            actionOnConsole(str = func(str));
        }
    }
}
