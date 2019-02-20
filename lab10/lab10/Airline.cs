using System;
using static System.Console;

namespace lab10
{
    public class Airline : IComparable
    {
        static int tableSize;
        public static void ShowInf() => WriteLine("Size: " + tableSize);
        public void ShowDetail() => Console.WriteLine($"Destination: {DESTINATION}, flight: {NUMBEROFFLIGHT}, type: {TYPEOFPLANE}, day: {DAY}");

        string destination = "";
        int numberOfFlight;
        char typeOfPlane;

        public enum WeekDays
        {
            sun = 1, mon, thue, wen, thir, fri, sat
        }

        public string DESTINATION
        {
            get => destination;
            set => destination = value != "Gomel" ? value : "error";
        }
        public int NUMBEROFFLIGHT
        {
            get => numberOfFlight;
            set => numberOfFlight = value != 5 ? value : -1;
        }
        public char TYPEOFPLANE
        {
            get => typeOfPlane;
            set => typeOfPlane = value != '\0' ? value : 'E';
        }
        public WeekDays DAY { get; set; } = WeekDays.mon;

        public Airline()
        {
            destination = "Minsk";
            numberOfFlight = 1;
            typeOfPlane = 'A';
            DAY = WeekDays.sun;
            tableSize++;
        }
        public Airline(string dest, int flight, char type, WeekDays day)
        {
            destination = dest;
            numberOfFlight = flight;
            typeOfPlane = type;
            DAY = day;
            tableSize++;
        }


        public int CompareTo(object obj)
        {
            Airline airline = (Airline)obj;
            return DAY > airline.DAY ? 1 : DAY < airline.DAY ? -1 : 0;
        }
    }
}
