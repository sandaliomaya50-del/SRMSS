namespace SRMSS.Models
{
    public class Maintenance
    {
        public int MaintenanceId { get; set; }

        public int BusId { get; set; }

        public DateTime MaintenanceDate { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Cost { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime? CompletedDate { get; set; }
    }
}