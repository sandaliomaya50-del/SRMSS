namespace SRMSS.Models
{
    public class Driver
    {

        // =========================================================
        // PRIMARY KEY
        // =========================================================

        public int DriverId { get; set; }





        // =========================================================
        // DRIVER DETAILS
        // =========================================================

        public string DriverName { get; set; } = string.Empty;


        public string PhoneNumber { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;





        // =========================================================
        // LICENCE DETAILS
        // =========================================================

        public string LicenseNumber { get; set; } = string.Empty;


        public DateTime LicenseExpiryDate { get; set; }





        // =========================================================
        // WORK DETAILS
        // =========================================================

        public string WorkingHours { get; set; } = string.Empty;


        public string AssignedRoute { get; set; } = string.Empty;





        // =========================================================
        // STATUS DETAILS
        // =========================================================

        public string Status { get; set; } = string.Empty;





        // =========================================================
        // PHOTO & NOTES
        // =========================================================

        public string? DriverImage { get; set; }


        public string? Notes { get; set; }





        // =========================================================
        // SYSTEM DETAILS
        // =========================================================

        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public bool IsActive { get; set; } = true;


    }
}