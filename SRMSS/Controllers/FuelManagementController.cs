using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;
using SRMSS.Models;


namespace SRMSS.Controllers
{

    public class FuelManagementController : Controller
    {


        private readonly ApplicationDbContext _context;



        public FuelManagementController(ApplicationDbContext context)
        {

            _context = context;

        }









        // =========================================================
        // FUEL MANAGEMENT INDEX
        // =========================================================


        public async Task<IActionResult> Index()
        {


            // LOAD VEHICLES FOR DROPDOWN

            await LoadVehicles();




            var fuelRecords =
                await _context.FuelRecords
                .Include(f => f.Vehicle)
                .Where(f => f.IsActive)
                .OrderByDescending(f => f.CreatedDate)
                .ToListAsync();





            return View(fuelRecords);


        }









        // =========================================================
        // LOAD VEHICLES FOR DROPDOWN
        // =========================================================


        private async Task LoadVehicles()
        {


            ViewBag.Vehicles =
                await _context.Vehicles
                .OrderBy(v => v.RegistrationNumber)
                .ToListAsync();



        }









        // =========================================================
        // CREATE FUEL RECORD PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Create()
        {


            await LoadVehicles();


            return View();

        }


        // =========================================================
        // CREATE FUEL RECORD SAVE
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(
            FuelRecord fuelRecord,
            IFormFile? ReceiptImage)
        {



            if (!ModelState.IsValid)
            {


                await LoadVehicles();


                TempData["ErrorMessage"] =
                    "Please check the entered fuel details.";


                return View(fuelRecord);

            }









            // =====================================================
            // RECEIPT IMAGE UPLOAD
            // =====================================================


            if (ReceiptImage != null && ReceiptImage.Length > 0)
            {


                string uploadFolder =
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "Images",
                        "FuelReceipts"
                    );




                if (!Directory.Exists(uploadFolder))
                {

                    Directory.CreateDirectory(uploadFolder);

                }







                string fileName =
                    Guid.NewGuid().ToString()
                    +
                    Path.GetExtension(
                        ReceiptImage.FileName
                    );







                string filePath =
                    Path.Combine(
                        uploadFolder,
                        fileName
                    );







                using (var stream =
                    new FileStream(
                        filePath,
                        FileMode.Create))
                {


                    await ReceiptImage.CopyToAsync(stream);


                }







                fuelRecord.ReceiptImage =
                    "/Images/FuelReceipts/" + fileName;


            }









            // =====================================================
            // SYSTEM VALUES
            // =====================================================


            fuelRecord.CreatedDate =
                DateTime.Now;



            fuelRecord.IsActive =
                true;









            // =====================================================
            // SAVE FUEL RECORD
            // =====================================================


            _context.FuelRecords.Add(fuelRecord);



            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Fuel record saved successfully!";








            return RedirectToAction(
                nameof(Index)
            );


        }


        // =========================================================
        // DELETE FUEL RECORD
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(
            int id)
        {


            var fuelRecord =
                await _context.FuelRecords
                .FindAsync(id);







            if (fuelRecord == null)
            {


                TempData["ErrorMessage"] =
                    "Fuel record could not be deleted.";


                return RedirectToAction(
                    nameof(Index)
                );


            }









            // SOFT DELETE

            fuelRecord.IsActive =
                false;



            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Fuel record deleted successfully!";








            return RedirectToAction(
                nameof(Index)
            );


        }




    }

}