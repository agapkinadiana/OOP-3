using System;

namespace labs4_6
{
    partial class Port
    {
        public Port(int maxIndex)
        {
            this.maxIndex = maxIndex - 1;
            shipsArr = new Ship[maxIndex];
        }

        public Ship[] GetShips() => shipsArr;
        public static void Show()
        {
            foreach (Ship sh in shipsArr)
                sh.GetVehicleInf();
        }
    }
}
