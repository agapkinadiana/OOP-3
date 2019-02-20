using System;
using static System.Console;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            IMovable tiger = new Tiger(200, 2013, "Кошачьи");
            Lion lion = new Lion(160, 2014, "Кошачьи");

            tiger.Move();

            Mammals[] mammals = { (tiger as Mammals), (lion as Mammals)};

            int mcount = mammals.Length;

            for (int i = 0; i < mcount; i++)
            {
                mammals[i].GeneralInf();
                mammals[i].Description();
                mammals[i].Color();
                mammals[i].Move();
                mammals[i].Sounds();
                WriteLine(mammals[i].ToString());
                WriteLine("------------------------------------------------------");
            }

            Parrot parrot = new Parrot(100, 2017, "Попугаевые", 48);
            Owl owl = new Owl(2, 2016, "Хищники", 150);

            Birds[] birds = { (parrot as Birds), (owl as Birds) };

            int bcount = birds.Length;

            for (int i = 0; i < bcount; i++)
            {
                birds[i].Description();
                birds[i].Move();
                birds[i].Sounds();
                WriteLine(birds[i].ToString());
                WriteLine("------------------------------------------------------");
            }

            Shark shark = new Shark(10, 2011, "Хрящевые");

            Fish[] fish = { (shark as Fish) };

            int fcount = fish.Length;

            for (int i = 0; i < fcount; i++)
            {
                fish[i].Description();
                fish[i].Features();
                fish[i].Move();
                fish[i].Sounds();
                WriteLine(fish[i].ToString());
                WriteLine("------------------------------------------------------");
            }

            WriteLine(owl is IMovable);
            WriteLine(owl is Birds);
            WriteLine();

            Animal[] animals = { (tiger as Mammals), (lion as Mammals), (parrot as Birds), (owl as Birds), (shark as Fish) };

            int count = animals.Length;

            Printer printer = new Printer();
            for (int i = 0; i < count; i++)
            {
                WriteLine(printer.IAmPrinting(animals[i]));
            }

            ZooContainer zoo = new ZooContainer("ZOO");
            ZooController zooController = new ZooController(zoo);

            zoo.Add((Mammals)tiger, lion, parrot, owl, shark);

            zoo.Display();

        }
    }
}
