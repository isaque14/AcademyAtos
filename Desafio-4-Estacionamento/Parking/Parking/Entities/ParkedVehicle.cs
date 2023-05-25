namespace Parking.Entities
{
    public sealed class ParkedVehicle
    {
        public string Plate { get; private set; }
        public DateTime EntryDate { get; private set; }
        public TimeSpan EntryTime { get; private set; }
        public TimeSpan ExitTime { get; private set; }
        public int StayTimeInMinutes { get; private set; }
        public decimal AmountCharged { get; private set; }

        public ParkedVehicle() { }

        public ParkedVehicle(string plate)
        {
            Plate = plate;
            EntryDate = DateTime.Today;
            var now = DateTime.Now;
            EntryTime = now - DateTime.Today;
        }

        public ParkedVehicle(string plate, DateTime entryDate, TimeSpan entryTime)
        {
            Plate = plate;
            EntryDate = entryDate;
            EntryTime = entryTime;
        }

        public void AddExitTime()
        {
            var now = DateTime.Now;
            ExitTime = now - DateTime.Today;
        }

        public void CalculateAmountCharged(decimal valuePerHours) 
        {
            TimeSpan difference = ExitTime - EntryTime;
            StayTimeInMinutes = (int)difference.TotalMinutes;
            TimeSpan roundedDifference = new TimeSpan((long)Math.Ceiling(difference.TotalMilliseconds) * TimeSpan.TicksPerMillisecond);


            if (roundedDifference.Minutes > 0)
                roundedDifference = roundedDifference.Add(new TimeSpan(1, 0, 0));

            AmountCharged = (int)roundedDifference.TotalHours * valuePerHours;
        }
    }
}
