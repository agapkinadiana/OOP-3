using System;
using static System.Console;

namespace labs4_6
{
    sealed class Corvette : Ship
    {
        public int Weapon { get; set; }

        public Corvette(double Carrying, string CaptainName, uint CaptainAge, int Weapon, double Delta)
            : base(Carrying, CaptainName, CaptainAge, Delta)
        {
            this.Weapon = Weapon;
            ToWater();
        }

        public override string ToString() => "Corvette";
        public override void Move() => WriteLine("I have never had so much power");
        public override void GetVehicleInf()
        {
            base.GetVehicleInf();
            Write($"Weapons: {Weapon}, ");
        }
    }
}
