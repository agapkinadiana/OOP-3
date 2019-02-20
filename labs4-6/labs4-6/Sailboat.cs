using System;
using static System.Console;

namespace labs4_6
{
    sealed class Sailboat : Ship
    {
        public Sailboat(double Carrying, string CaptainName, uint CaptainAge, double Delta)
            : base(Carrying, CaptainName, CaptainAge, Delta)
        {
            ToWater();
        }

        public override void Move() => WriteLine("Hold your nose to the wind");
        public override string ToString() => "Sailboat";
    }
}
