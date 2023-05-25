namespace Parking.DTOs
{
    public sealed class ParkedVehicleEntranceDTO
    {
        public string Plate { get; set; }
        public DateTime EntryDate { get; set; }
        public TimeSpan EntryTime { get; set; }
    }
}
