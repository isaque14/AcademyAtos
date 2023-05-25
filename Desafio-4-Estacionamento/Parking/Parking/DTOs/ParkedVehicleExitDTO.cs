namespace Parking.DTOs
{
    public class ParkedVehicleExitDTO
    {
        public string Plate { get; set; }
        public DateTime EntryDate { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan ExitTime { get; set; }
        public decimal AmountCharged { get; set; }
    }
}
