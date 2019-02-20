using System;
using System.Diagnostics;
using static System.Console;

namespace labs4_6
{
    class Program
    {
        struct SomeStruct
        {
            public string name;
            public int age;

            public void DisplayNameAndAge() => WriteLine($"Name: {name}, age: {age}");

            public SomeStruct(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }

        enum Dig
        {
            ONE = 1, TWO, THREE
        }


        static void Main(string[] args)
        {
            int[] a = null;
            //Debug.Assert(a != null, "Values array cannot be null");
            /*Dig dig = Dig.ONE;
            WriteLine(dig);
            dig++;
            WriteLine(dig);
            SomeStruct someStruct = new SomeStruct("Diana", 18);
            someStruct.DisplayNameAndAge();
            string name = someStruct.name;

            Port port = new Port(4);
            port[0] = new Boat(44, "Yan", 18, 0.6);
            port[1] = new Sailboat(777, "Vlad", 28, 0.7);
            port[2] = new Corvette(7878787, "Petr Poroshenko", 999, 3232, 0.5);
            port[3] = new Steamer(333, "Ivan", 27, 0.3, 14);
            foreach (Ship ship in PortController.AllCaptainsAgeLessThan35(port))
                ship.GetVehicleInf();
            WriteLine("Displacement of all sailboats: " + PortController.CalculateDisplacement(port));
            WriteLine("Seats of all steamers: " + PortController.SteamerSeats(port));*/
            Port port = new Port(4);
            try
            {
                port[0] = new Boat(44, "Ilya", 18, 0.45F);
                port[1] = new Sailboat(777, "En", 28, 0.65F);

                //port[0] = new Boat(0, "Vitya", 20, 0.1);
                //port[1] = new Boat(11, "Vanya", 11, 1.1);
                //Console.WriteLine(port[5]);
                port[5] = new Boat(444, "Ilya", 4, 0.30F);
            }
            catch (PortException exception)
            {
                WriteLine($"Error: {exception.Message} in {exception.ErrorClass}, actual: {exception.CountException}, expected: {exception.ExpectedCount}");
            }
            catch (VehicleException exception)
            {
                WriteLine($"Error: {exception.Message} - {exception.CarringException}");
            }
            finally
            {
                WriteLine("Finally block");
            }
           WriteLine();

            try
            {
                port[0] = new Boat(44, "Ilya", 18, 0.45F);
                //port[1] = new Sailboat(777, "Ilya", 28, 0.65F);
                port[1] = new Boat(-99, "Valya", 99, 0.4);
                //Console.WriteLine(port[5]);
                port[5] = new Boat(444, "Egor", 4, 0.30F);
            }
            catch (CustomException exception)
            {
                //VehicleException veh = (VehicleException)exception;
                //Console.WriteLine(veh.CarringException);

                object exc = exception as PortException;
                if (exc == null)
                {
                    exc = exception as VehicleException;
                    if (exc == null)
                        WriteLine("Sorry");
                    else
                    {
                        VehicleException vehicleException = (VehicleException)exc;
                        WriteLine($"Error: {vehicleException.Message} - {vehicleException.CarringException}");
                    }
                }
                else
                {
                    PortException portException = (PortException)exc;
                    WriteLine($"Error: {portException.Message} in {portException.ErrorClass}, actual: {portException.CountException}, expected: {portException.ExpectedCount}");
                }
            }
            WriteLine();

            try
            {
                Port port1 = new Port(2);
                port1[0] = new Boat(44, "Yan", 18, 0.45F);
                port1[1] = new Boat(777, "Nik", 28, 0.65F);
                //PortController.CalculateDisplacement(port1);
                throw new Exception("new standard exception");
            }
            catch (Exception exception)
            {
                WriteLine(exception.Message);
            }
            finally
            {
                WriteLine("Hi");
            }

        }
    }
}
