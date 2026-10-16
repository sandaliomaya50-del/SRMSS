namespace SRMSS.Models
{
    public class FuelLog
    {
        public int FuelLogId { get; set; }

        public int BusId { get; set; }

        public DateTime FuelDate { get; set; }

        public decimal FuelAmount { get; set; }

        public decimal FuelCost { get; set; }

        public decimal Mileage { get; set; }
    }
}