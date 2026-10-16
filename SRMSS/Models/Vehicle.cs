namespace SRMSS.Models
{
    public class Vehicle
    {

        // =========================================================
        // PRIMARY KEY
        // =========================================================

        public int VehicleId { get; set; }





        // =========================================================
        // VEHICLE DETAILS
        // =========================================================

        public string RegistrationNumber { get; set; } = string.Empty;


        public string VehicleType { get; set; } = string.Empty;


        public string? VehicleImage { get; set; }





        // =========================================================
        // CAPACITY & MILEAGE
        // =========================================================

        public int SeatingCapacity { get; set; }


        public decimal CurrentMileage { get; set; }





        // =========================================================
        // STATUS DETAILS
        // =========================================================

        public string Availability { get; set; } = string.Empty;


        public string MaintenanceStatus { get; set; } = string.Empty;





        // =========================================================
        // DRIVER DETAILS
        // =========================================================

        public string? Driver { get; set; }





        // =========================================================
        // ADDITIONAL NOTES
        // =========================================================

        public string? AdditionalNote { get; set; }





        // =========================================================
        // SYSTEM DETAILS
        // =========================================================

        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public bool IsActive { get; set; } = true;

    }
}