using System;

namespace labs4_6
{
    class VehicleException : CustomException
    {
        public double CarringException { get; set; }

        public VehicleException(string message, double CarringException)
            : base(message, "Vehicle")
        {
            this.CarringException = CarringException;
        }
    }
}
