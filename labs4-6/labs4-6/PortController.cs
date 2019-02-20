using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace labs4_6
{
    static class PortController
    {
        public static double CalculateDisplacement(Port port)
        {
            double displacement = 0;
            double draft = 6.5F;
            double width = 14;
            foreach (Ship ship in port.GetShips())
                if (ship.ToString() == "Sailboat")              //парусники
                    displacement += draft * width * ship.Delta;
            return displacement;
        }

        public static uint SteamerSeats(Port port)
        {
            uint seats = 0;
            foreach (Ship ship in port.GetShips())
            {
                if (ship is Steamer steamer)                   //пароходы
                    seats += steamer.Seats;
            }
            return seats;
        }

        public static List<Ship> AllCaptainsAgeLessThan35(Port port)
        {
            List<Ship> ships = new List<Ship>();
            uint age = 35;
            foreach (Ship ship in port.GetShips())
                if (ship.CaptainAge < age)
                    ships.Add(ship);
            return ships;
        }
    }
}
