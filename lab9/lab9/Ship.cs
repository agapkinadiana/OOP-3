using System;
namespace lab9
{
    public class Ship
    {
        public string VehicleName { get; set; }
        public double Carrying { get; set; }


        public Ship(string VehicleName, double Carrying)
        {
            this.VehicleName = VehicleName;
            this.Carrying = Carrying;
        }
    }
}
