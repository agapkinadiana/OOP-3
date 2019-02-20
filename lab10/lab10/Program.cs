using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace lab10
{
    class Program
    {
        string DESTINATION { get; set; }

        Program(string dest)
        {
            DESTINATION = dest;
        }

        static void Main(string[] args)
        {
            //task1
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            WriteLine("Enter string lenght");
            int n = int.Parse(ReadLine());
            var selectedStr = from m in months
                              where m.Length == n
                              select m;
            //отложенное выполнение
            foreach (string s in selectedStr)
                WriteLine(s);
            selectedStr = from m in months
                          where m == "June" || m == "July" || m == "August" || m == "January" || m == "February" || m == "December"
                          select m;
            WriteLine("_____________Summer and winter months_____________");
            foreach (string s in selectedStr)
                WriteLine(s);
            selectedStr = months.OrderBy(s => s);
            WriteLine("_____________Months ordered by alphabet_____________");
            foreach (string s in selectedStr)
                WriteLine(s);
            //немедленное выполнение
            int count = (selectedStr.Where(s => (s.IndexOf('u') > -1 && s.Length >= 4))).Count();
            WriteLine("____________________________________________________");
            WriteLine();
            WriteLine("Number of months containing a letter 'u' and with a lenght >=4: " + count);
            WriteLine();
            WriteLine("____________________________________________________");

            //task2
            var airlaines = new List<Airline>();
            airlaines.AddRange(new Airline[]{
                new Airline(),
                new Airline("Minsk", 22, 'A', Airline.WeekDays.fri),
                new Airline("Minsk", 88, 'A', Airline.WeekDays.mon),
                new Airline("Vitebsk", 2, 'B', Airline.WeekDays.thir),
                new Airline("Mogilev", 1, 'A', Airline.WeekDays.fri),
                new Airline("Mogilev", 422, 'C', Airline.WeekDays.wen)
            });

            //task3
            string dest = "Minsk";
            var flightsByDest = from a in airlaines
                                where a.DESTINATION == dest
                                select a;
            WriteLine("Flight list for a given destination: ");
            foreach (var flight in flightsByDest)
                flight.ShowDetail();
            WriteLine("____________________________________________________");
            Airline.WeekDays day = Airline.WeekDays.mon;
            var flightsByDay = from a in airlaines
                               where a.DAY == day
                               select a;
            WriteLine("Flight list for a given day: ");
            foreach (var flight in flightsByDay)
                flight.ShowDetail();
            WriteLine("____________________________________________________");
            Airline morningFlight = airlaines.Where(s => s.DAY == Airline.WeekDays.mon).Min();
            WriteLine("Flight that takes off on Mon before everyone else: ");
            morningFlight.ShowDetail();
            WriteLine("____________________________________________________");
            Airline eveningFlight = airlaines.Where(s => s.DAY == Airline.WeekDays.wen || s.DAY == Airline.WeekDays.fri).Max();
            WriteLine("Flight that takes off on FRI or WEN later everyone else: ");
            eveningFlight.ShowDetail();
            WriteLine("____________________________________________________");
            IEnumerable<IGrouping<Airline.WeekDays, Airline>> groupByDays = from flight in airlaines
                                                                            orderby flight.DAY
                                                                            ascending                        //по возрастанию
                                                                            group flight by flight.DAY;
            WriteLine("Group by days: ");
            foreach(IGrouping<Airline.WeekDays, Airline> fl in groupByDays)
            {
                WriteLine(fl.Key);
                foreach(Airline airline in fl)
                {
                    airline.ShowDetail();
                }
            }

            //task4
            WriteLine("____________________________________________________");

            Airline[] customQuery = airlaines.Where(a => a.DAY != Airline.WeekDays.mon && a.NUMBEROFFLIGHT < 100).OrderByDescending(a => a.DESTINATION).Skip(2).Reverse().ToArray();

            foreach (Airline cq in customQuery)
                cq.ShowDetail();

            WriteLine("____________________________________________________");

            //task5
            var mainlist = new Program[] {
                new Program("Gomel"),
                new Program("Mogilev"),
                new Program("Minsk")
            };
            var result = from resair in airlaines
                         join resmain in mainlist on resair.DESTINATION equals resmain.DESTINATION
                         select new
                         {
                             name = resair.NUMBEROFFLIGHT,
                             type = resmain.DESTINATION
                         };
            foreach (var res in result)
                WriteLine(res.name + "\t" + res.type);
            WriteLine("____________________________________________________");

            var result1 = airlaines.Join(mainlist, p => p.DESTINATION, t => t.DESTINATION, (p, t) => new { Name = p.TYPEOFPLANE, Something = t.DESTINATION, Day = p.DAY });
            foreach (var res in result1)
                WriteLine(res.Name + "\t" + res.Something + "\t" + res.Day);
        }
    }
}
