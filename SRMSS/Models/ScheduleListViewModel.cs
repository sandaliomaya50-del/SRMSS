namespace SRMSS.Models
{
    public class ScheduleListViewModel
    {
        public int ScheduleId { get; set; }

        public string ScheduleCode { get; set; } = string.Empty;

        public string Route { get; set; } = string.Empty;

        public string Bus { get; set; } = string.Empty;

        public string Driver { get; set; } = string.Empty;

        public string DepartureTime { get; set; } = string.Empty;

        public string ArrivalTime { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string ScheduleStatus { get; set; } = string.Empty;

        public string? Notes { get; set; }
    }
}