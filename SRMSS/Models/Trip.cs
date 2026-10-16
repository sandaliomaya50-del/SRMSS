namespace SRMSS.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        public int ScheduleId { get; set; }

        public DateTime TripDate { get; set; }

        public TimeSpan? ActualDepartureTime { get; set; }

        public TimeSpan? ActualArrivalTime { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}