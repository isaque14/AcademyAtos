using Parking.Interfaces;
using Parking.Repositories;
using Parking.Services;

namespace Parking
{
    public static class Program
    {
        
        [STAThread]
        static void Main()
        {
            IparkedVehicleRepository repository = new ParkedVehicleRepository();
            IParkingService parking = new ParkingService(repository);


            ApplicationConfiguration.Initialize();
            Application.Run(new FormInitial(parking));
        }
    }
}