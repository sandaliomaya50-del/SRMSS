namespace SRMSS.Models
{
    public class Bus
    {
        public int BusId { get; set; }

        public string RegistrationNumber { get; set; } = string.Empty;

        public int SeatingCapacity { get; set; }

        public decimal Mileage { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}