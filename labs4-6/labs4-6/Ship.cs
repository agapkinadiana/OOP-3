using System;
using static System.Console;

namespace labs4_6
{
    abstract class Ship : Object, IVehicle, ICaptain
    {
        public string VehicleName { get; set; }
        double delta;
        public double Delta
        {
            get { return delta; }
            set
            {
                if (value >= 1)
                    throw new VehicleException("Неверный коэфициент дельта", value);
                delta = value;
            }
        }
        double carrying;
        public double Carrying
        {
            get { return carrying; }
            set
            {
                if (value <= 0)
                    throw new VehicleException("Неверное значение грузоподъемности", value);
                carrying = value;
            }
        }
        public string CaptainName { get; set; }
        public uint CaptainAge { get; set; }

        // Abstract method can't have implementation
        public abstract void Move();
        // Virtual can
        public virtual void GetVehicleInf() => WriteLine($"Vehicle: {VehicleName}, Carrying: {Carrying}, Captain: {CaptainName}, Captain Age: {CaptainAge}");
        public void ToWater() => WriteLine("To search adventure");

        protected Ship(double Carrying, string CaptainName, uint CaptainAge, double Delta)
        {
            VehicleName = "Ship";
            this.Carrying = Carrying;
            this.CaptainName = CaptainName;
            this.CaptainAge = CaptainAge;
            this.Delta = Delta;
        }

        void ICaptain.OneNameMethod() => WriteLine("Hi, i'm from Captain interface!");
        void IVehicle.OneNameMethod() => WriteLine("Hi, i'm from Vehicle interface!");

        public override string ToString() => base.ToString() + " - ToString in Ship";
        public override bool Equals(object obj) => !Equals(obj);
        public override int GetHashCode() => 0;
    }
}
