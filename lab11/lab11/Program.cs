using System;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Airline airline = new Airline();
            Reflector<Airline> reflector = new Reflector<Airline>();
            reflector.ShowAll(airline);
            reflector.GetPublicMethods(airline);
            reflector.GetPropField(airline);
            reflector.GetInterfaces(airline);
            reflector.GetUserMethods(airline);
            reflector.CallAnyMethod(airline, "Method1");
        }
    }
}
