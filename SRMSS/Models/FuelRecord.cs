namespace SRMSS.Models
{
    public class FuelRecord
    {


        // =========================================================
        // PRIMARY KEY
        // =========================================================

        public int FuelRecordId { get; set; }





        // =========================================================
        // VEHICLE DETAILS
        // =========================================================

        public int VehicleId { get; set; }


        public Vehicle? Vehicle { get; set; }





        // =========================================================
        // FUEL DETAILS
        // =========================================================

        public DateTime FuelDate { get; set; } = DateTime.Now;


        public string FuelType { get; set; } = string.Empty;


        public decimal FuelQuantity { get; set; }


        public decimal FuelCost { get; set; }





        // =========================================================
        // FUEL STATION DETAILS
        // =========================================================

        public string FuelStation { get; set; } = string.Empty;





        // =========================================================
        // PERFORMANCE DETAILS
        // =========================================================

        public decimal FuelConsumption { get; set; }


        public decimal Mileage { get; set; }





        // =========================================================
        // RECEIPT DETAILS
        // =========================================================

        public string ReceiptNumber { get; set; } = string.Empty;


        public string? ReceiptImage { get; set; }





        // =========================================================
        // NOTES
        // =========================================================

        public string? AdditionalNotes { get; set; }





        // =========================================================
        // SYSTEM DETAILS
        // =========================================================

        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public bool IsActive { get; set; } = true;


    }
}
