using System;
using static System.Console;

namespace labs4_6
{
    sealed class Boat : Ship
    {
        public Boat(double Carrying, string CaptainName, uint CaptainAge, double Delta)
            : base(Carrying, CaptainName, CaptainAge, Delta)
        {
            ToWater();
        }

        public override void Move() => WriteLine("Anyway better than nothing");
        public override string ToString() => "Boat";
    }
}
