using System;
using static System.Console;

namespace labs4_6
{
    sealed class Steamer : Ship
    {
        public uint Seats { get; set; }

        public Steamer(double Carrying, string CaptainName, uint CaptainAge, double Delta, uint Seats)
            : base(Carrying, CaptainName, CaptainAge, Delta)
        {
            this.Seats = Seats;
            ToWater();
        }

        public override void Move() => WriteLine("So much stream and so low");
        public override string ToString() => "Steamer";
    }
}
