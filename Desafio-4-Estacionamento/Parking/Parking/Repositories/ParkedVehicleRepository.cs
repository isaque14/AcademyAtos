using Parking.DTOs;
using Parking.Entities;
using Parking.Interfaces;

namespace Parking.Repositories
{
    public sealed class ParkedVehicleRepository : IparkedVehicleRepository
    {
        private const string _filePathEntrance = @"C:\ws-vs22\AcademyAtos\Desafio-4\Parking\Parking\Repositories\DataBase\DataBaseEntrance.dat";
        private const string _filePathExit = @"C:\ws-vs22\AcademyAtos\Desafio-4\Parking\Parking\Repositories\DataBase\DataBaseExit.dat";
                                            

        public string[] GetAllExitedVehicle()
        {
            return File.ReadAllLines(_filePathExit);
        }

        public string[] GetAllParkedVehicle()
        {
            return File.ReadAllLines(_filePathEntrance);
        }

        public ParkedVehicle GetByPlate(string plate)
        {
            var parkedEntrance = new ParkedVehicle();
            var lines = File.ReadAllLines(_filePathEntrance);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string savedPlate = parts[0];

                if (savedPlate == plate)
                    return new ParkedVehicle(parts[0], DateTime.Parse(parts[1]), TimeSpan.Parse(parts[2]));
            }

            return parkedEntrance;
        }

        public bool IsParked(string plate)
        {
            var lines = File.ReadAllLines(_filePathEntrance);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string savedPlate = parts[0];
                
                if (savedPlate == plate)
                    return true;
            }

            return false;
        }

        public int TotalParked()
        {
            var lines = File.ReadAllLines(_filePathEntrance);
            return lines.Length;
        }

        public void VehicleEntrance(ParkedVehicle parkedVehicle)
        {
            string dataLine =
                $"{parkedVehicle.Plate};" +
                $"{parkedVehicle.EntryDate.Day}/{parkedVehicle.EntryDate.Month}/{parkedVehicle.EntryDate.Year};" +
                $"{parkedVehicle.EntryTime.Hours}:{parkedVehicle.EntryTime.Minutes};";

            File.AppendAllText(_filePathEntrance, dataLine + Environment.NewLine);
        }

        public void VehicleExit(ParkedVehicle parkedVehicle)
        {

            string dataLine = 
                $"{parkedVehicle.Plate};" +
                $"{parkedVehicle.EntryDate.Day}/{parkedVehicle.EntryDate.Month}/{parkedVehicle.EntryDate.Year};" +
                $"{parkedVehicle.EntryTime.Hours}:{parkedVehicle.EntryTime.Minutes};" +
                $"{parkedVehicle.StayTimeInMinutes};" +
                $"{parkedVehicle.AmountCharged}";

            File.AppendAllText(_filePathExit, dataLine + Environment.NewLine);

            var lines = File.ReadAllLines(_filePathEntrance);
            List<string> updatedLines = new List<string>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                string plate = parts[0];

                if (plate != parkedVehicle.Plate)
                    updatedLines.Add(line);
                
            }

            File.WriteAllLines(_filePathEntrance, updatedLines);
        }

        private IEnumerable<ParkedVehicleEntranceDTO> ConvertLinesFromFileInParKedVehicle(string[] lines)
        {
            var parkedVehicles = new List<ParkedVehicleEntranceDTO>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');

                parkedVehicles.Add(new ParkedVehicleEntranceDTO
                {
                    Plate = parts[0],
                    EntryDate = DateTime.Parse(parts[1]),
                    EntryTime = TimeSpan.Parse(parts[2])
                });
            }

            return parkedVehicles;
        }
    }
}
