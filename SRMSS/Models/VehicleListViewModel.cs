namespace SRMSS.Models
{
    public class VehicleListViewModel
    {

        public int VehicleId { get; set; }



        public string RegistrationNumber { get; set; }
            = string.Empty;



        public string VehicleType { get; set; }
            = string.Empty;



        public int SeatingCapacity { get; set; }



        public decimal CurrentMileage { get; set; }



        public string Availability { get; set; }
            = string.Empty;



        public string MaintenanceStatus { get; set; }
            = string.Empty;



        public string Driver { get; set; }
            = string.Empty;



        public string? Notes { get; set; }



        public string? VehicleImage { get; set; }


    }
}
