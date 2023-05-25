using Parking.DTOs;
using Parking.Entities;
using Parking.Interfaces;
using Parking.Services.BaseResponses;
using System.Text;
using System.Text.RegularExpressions;

namespace Parking.Services
{
    public sealed class ParkingService : IParkingService
    {
        private readonly TimeSpan _startOfWork;
        private readonly TimeSpan _endOfWork;
        private readonly IparkedVehicleRepository _repository;
        private const int _maximumCapacity = 50;
        private const decimal _valuePerHour = 5;

        public ParkingService(IparkedVehicleRepository repository)
        {
            _startOfWork = TimeSpan.FromHours(7);
            _endOfWork = TimeSpan.FromHours(20);
            _repository = repository;
        }

        public GenericResponse VehicleEntrance(ParkedVehicle parkedVehicle)
        {
            if (!IsVacancy())
                return ResponseFullParkingLot();

            if (!ParkingIsOpen())
                return ResponseParkingIsClosed();

            if (!IsMercosulPlate(parkedVehicle.Plate))
                return ResponseInvalidPlate();

            if (_repository.IsParked(parkedVehicle.Plate))
                return ResponseVehicleIsParked();

            _repository.VehicleEntrance(parkedVehicle);
            return ResponseParkedVehicleEntrance();
        }

        public GenericResponse VehicleExit(ParkedVehicle parkedVehicle)
        {
            if (!ParkingIsOpen())
                return ResponseParkingIsClosed();

            bool isParked = _repository.IsParked(parkedVehicle.Plate);
            if (!isParked)
                return ResponseVehicleIsNotParked();

            parkedVehicle = _repository.GetByPlate(parkedVehicle.Plate);

            parkedVehicle.AddExitTime();
            parkedVehicle.CalculateAmountCharged(_valuePerHour);

            _repository.VehicleExit(parkedVehicle);
            return ResponseExitVehicle();
        }

        public string GetAllParkedVehicles()
        {
            var lines = _repository.GetAllParkedVehicle();

            return ConvertDataToString(lines);
        }

        public string GetAllExitsVeicles()
        {
            var lines = _repository.GetAllExitedVehicle();

            return ConvertDataToString(lines);
        }

        private string ConvertDataToString(string[] lines)
        {
            var sb = new StringBuilder();

            foreach (var line in lines)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        private bool IsVacancy()
        {
            var occupied = _repository.TotalParked();

            return occupied < _maximumCapacity ? true : false;
        }

        private bool ParkingIsOpen()
        {
            var currentTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            return currentTime >= _startOfWork && currentTime <= _endOfWork ? true : false;
        }

        public static bool IsMercosulPlate(string plate)
        {
            string pattern = @"^[A-Z]{3}\d{1}[A-Z0-9]{1}\d{2}$";
            return Regex.IsMatch(plate, pattern);
        }

        private GenericResponse ResponseParkingIsClosed()
        {
           return new GenericResponse
                {
                    IsSuccessful = false,
                    StatusMessage = "Ops, Fora do horário de Expediente"
                };
        }

        private GenericResponse ResponseInvalidPlate()
        {
            return new GenericResponse
            {
                IsSuccessful = false,
                StatusMessage = "Ops, Esta Placa Não Obedece aos critérios do Mercosul"
            };
        }

        private GenericResponse ResponseFullParkingLot()
        {
           return new GenericResponse
           {
               IsSuccessful = false,
               StatusMessage = "Ops, o Estacionamento está Lotado!!!"
           };
        }

        private GenericResponse ResponseParkedVehicleEntrance()
        {
            return new GenericResponse
            {
                IsSuccessful = true,
                StatusMessage = "Entrada de Veículo Registrada, Dados Salvos."
            };
        }

        private GenericResponse ResponseExitVehicle()
        {
            return new GenericResponse
            {
                IsSuccessful = true,
                StatusMessage = "Sáida de Veículo Registrada, Dados Salvos."
            };
        }

        private GenericResponse ResponseVehicleIsNotParked()
        {
            return new GenericResponse
            {
                IsSuccessful = true,
                StatusMessage = "Ops, Nenhum Veículo Registrado com essa Placa, verifique os dados!!!"
            };
        }

        private GenericResponse ResponseVehicleIsParked()
        {
            return new GenericResponse
            {
                IsSuccessful = true,
                StatusMessage = "Ops, Um Veículo com esta placa já está estacionado, verifique os dados!!!"
            };
        }
    }
}
