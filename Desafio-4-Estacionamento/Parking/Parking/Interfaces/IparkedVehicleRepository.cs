using Parking.DTOs;
using Parking.Entities;

namespace Parking.Interfaces
{
    public interface IparkedVehicleRepository
    {
        void VehicleEntrance(ParkedVehicle parkedVehicle);
        void VehicleExit(ParkedVehicle parkedVehicle);
        int TotalParked();
        bool IsParked(string plate);
        string[] GetAllParkedVehicle();
        string[] GetAllExitedVehicle();

        ParkedVehicle GetByPlate(string plate);
    }
}
