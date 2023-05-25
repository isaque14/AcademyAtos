using Parking.Entities;
using Parking.Services.BaseResponses;

namespace Parking.Interfaces
{
    public interface IParkingService
    {
        GenericResponse VehicleEntrance(ParkedVehicle parkedVehicle);
        GenericResponse VehicleExit(ParkedVehicle parkedVehicle);

        string GetAllParkedVehicles();
        string GetAllExitsVeicles();
    }
}
