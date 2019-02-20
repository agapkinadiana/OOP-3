using System;
namespace labs4_6
{
    interface IVehicle
    {
        string VehicleName { get; set; }
        double Carrying { get; set; }

        void GetVehicleInf();
        void OneNameMethod();
    }
}
