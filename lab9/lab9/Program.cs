using System;
using System.Collections;
using System.Collections.ObjectModel;
using static System.Console;


namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //task1
                ArrayList list = new ArrayList();
                var rand = new Random();
                for (int i = 0; i < 5; i++)
                {
                    list.Add(rand.Next(1, 10));
                }
                list.Add("string");
                list.Add(new Student<int>());
                WriteLine("Which item to delete?");
                int el = int.Parse(ReadLine());
                if (el > list.Count)
                    throw new Exception("Such index doesn't exist");
                else
                    list.Remove(list[el]);
                WriteLine("Number of items in the collection: " + list.Count);
                foreach (object obj in list)
                    WriteLine(obj);
                WriteLine("Enter index to search");
                el = int.Parse(ReadLine());
                if (el > list.Count)
                    throw new Exception("Such index doesn't exist");
                else
                    foreach (object obj in list)
                        if (obj.Equals(list[el]))
                            WriteLine(obj);
                WriteLine("__________________________________________________________");

                //task2
                var genericlist = Student<long>.genericlist;
                for (int i = 0; i < 10; i++)
                    genericlist.Add((long)(long.MaxValue / 10 * i));
                foreach (object obj in genericlist)
                    WriteLine(obj);
                WriteLine("Number of items in the collection: " + genericlist.Count);
                WriteLine("How many items to remove?");
                el = int.Parse(ReadLine()) - 1;
                for (int i = 0; i < el; i++)
                    genericlist.Remove(genericlist[genericlist.Count - 1]);
                foreach (object obj in genericlist)
                    WriteLine(obj);
                WriteLine("Adding items to the list");
                genericlist.Add(10);
                genericlist.Insert(3, 50);
                genericlist.AddRange(new long[] { 12222, 12222 });
                foreach (object obj in genericlist)
                    WriteLine(obj);
                WriteLine("__________________________________________________________");
                var sortedset = Student<long>.sortedset;
                foreach (long obj in genericlist)
                    sortedset.Add(obj);
                foreach (long obj in sortedset)
                    WriteLine(obj);
                WriteLine("Enter element to search");
                long lon = long.Parse(ReadLine());
                foreach (long ln in sortedset)
                    if (ln == lon)
                    {
                        WriteLine("Find: " + ln);
                    }

                WriteLine("__________________________________________________________");

                //task3
                var listOfShips = Student<Port>.genericlist;
                var port1 = new Port(2);
                port1[0] = new Ship("ship1.1", 100);
                port1[1] = new Ship("ship1.2", 101);
                var port2 = new Port(2);
                port2[0] = new Ship("ship2.1", 200);
                port2[1] = new Ship("ship2.2", 201);
                var port3 = new Port(1);
                port3[0] = new Ship("ship3.1", 300);
                listOfShips.AddRange(new Port[] { port1, port2, port3 });
                foreach (Port obj in listOfShips)
                    obj.Print();
                WriteLine("Number of items in the collection: " + listOfShips.Count);
                WriteLine("How many items to remove?");
                el = int.Parse(ReadLine()) - 1;
                for (var i = el; i >= 0; i--)
                    listOfShips.RemoveAt(i);
                listOfShips.Add(port1);
                foreach (Port obj in listOfShips)
                    obj.Print();
                WriteLine("__________________________________________________________");
                var sortedsetOfShips = Student<Port>.sortedset;
                foreach (Port obj in listOfShips)
                    sortedsetOfShips.Add(obj);
                foreach (Port obj in sortedsetOfShips)
                    obj.Print();
                WriteLine("Enter ship name to search");
                string str = ReadLine();
                int index = 0;
                foreach (Port port in sortedsetOfShips)
                {
                    index++;
                    foreach (Ship ship in port.GetShips())
                    {
                        if (str == ship.VehicleName)
                            WriteLine($"Fount {index} element. Name: {str}");
                    }
                }
                WriteLine("__________________________________________________________");

                //task4
                ObservableCollection<Student<int>> students = new ObservableCollection<Student<int>>()
                {
                 new Student<int>("Vitya"),
                 new Student<int>("Kolya"),
                 new Student<int>("Illya"),
                };
                students.CollectionChanged += Student<int>.WhenChange;
                students.Add(new Student<int>());
                students.RemoveAt(3);
                students[1] = new Student<int>("Andrey");

                foreach (Student<int> student in students)
                    WriteLine(student.Name);
            }

            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }
}
