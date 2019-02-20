using System;
namespace lab9
{
    public class Port : IComparable
    {
        public Port(int maxIndex)
        {
            this.maxIndex = maxIndex;
            shipsArr = new Ship[this.maxIndex];
        }

        Ship[] shipsArr;
        int maxIndex;

        public Ship this[int index]
        {
            get
            {
                if (index > maxIndex)
                {
                    Console.WriteLine("Invalid index"); 
                    return null; 
                }
                return shipsArr[index];
            }
            set
            {
                if (index > maxIndex)
                    Console.WriteLine("Invalid index");
                else
                    shipsArr[index] = value;
            }
        }

        public void Print()
        {
            foreach (Ship ship in shipsArr)
                Console.WriteLine($"Carring: {ship.Carrying}, Name: {ship.VehicleName}");
        }

        public Ship[] GetShips() => shipsArr;

        public int CompareTo(object port)
        {
            if (shipsArr.Length > ((Port)port).shipsArr.Length)
                return 1;
            if (shipsArr.Length < ((Port)port).shipsArr.Length)
                return -1;
            return 0;
        }
    }
}
