/* =========================================================
   USING STATEMENTS
   ========================================================= */


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;
using SRMSS.Models;







namespace SRMSS.Controllers
{


    public class DriverManagementController : Controller
    {


        private readonly ApplicationDbContext _context;







        public DriverManagementController(
            ApplicationDbContext context)
        {


            _context = context;


        }









        // =========================================================
        // DRIVER MANAGEMENT INDEX
        // =========================================================


        public async Task<IActionResult> Index()
        {


            var drivers =
                await _context.Drivers
                .Where(d => d.IsActive)
                .OrderByDescending(d => d.CreatedDate)
                .ToListAsync();





            // LOAD ROUTES FOR ASSIGNED ROUTE DROPDOWN

            await LoadRoutes();





            return View(drivers);


        }









        // =========================================================
        // LOAD ROUTES FOR DROPDOWN
        // =========================================================


        private async Task LoadRoutes()
        {


            ViewBag.Routes =
                await _context.Routes
                .OrderBy(r => r.RouteName)
                .ToListAsync();


        }
        // =========================================================
        // CREATE DRIVER - PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Create()
        {


            await LoadRoutes();


            return View();


        }









        // =========================================================
        // CREATE DRIVER - SAVE
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(
            Driver driver,
            IFormFile? DriverImage)
        {



            if (!ModelState.IsValid)
            {


                await LoadRoutes();



                TempData["ErrorMessage"] =
                    "Please check the entered driver details.";



                return View(driver);


            }









            // =====================================================
            // DRIVER IMAGE UPLOAD
            // =====================================================


            if (DriverImage != null &&
                DriverImage.Length > 0)
            {


                string uploadFolder =
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "Images",
                        "Drivers"
                    );





                if (!Directory.Exists(uploadFolder))
                {

                    Directory.CreateDirectory(uploadFolder);

                }









                string fileName =
                    Guid.NewGuid().ToString()
                    +
                    Path.GetExtension(
                        DriverImage.FileName
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


                    await DriverImage.CopyToAsync(stream);


                }









                driver.DriverImage =
                    "/Images/Drivers/" + fileName;


            }









            // =====================================================
            // SYSTEM VALUES
            // =====================================================


            driver.CreatedDate =
                DateTime.Now;



            driver.IsActive =
                true;









            // =====================================================
            // SAVE DRIVER
            // =====================================================


            _context.Drivers.Add(driver);



            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Driver saved successfully!";









            return RedirectToAction(
                nameof(Index)
            );


        }
        // =========================================================
        // DETAILS
        // =========================================================


        public async Task<IActionResult> Details(int id)
        {


            var driver =
                await _context.Drivers
                .FirstOrDefaultAsync(
                    d => d.DriverId == id
                );



            if (driver == null)
            {

                return NotFound();

            }



            return View(driver);


        }









        // =========================================================
        // EDIT PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {


            var driver =
                await _context.Drivers
                .FindAsync(id);





            if (driver == null)
            {

                return NotFound();

            }





            await LoadRoutes();





            return View(driver);


        }









        // =========================================================
        // EDIT SAVE
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(
            int id,
            Driver driver)
        {


            if (id != driver.DriverId)
            {

                return NotFound();

            }









            if (!ModelState.IsValid)
            {


                await LoadRoutes();



                TempData["ErrorMessage"] =
                    "Please check the entered driver details.";



                return View(driver);


            }









            try
            {


                var existingDriver =
                    await _context.Drivers
                    .FindAsync(id);





                if (existingDriver == null)
                {

                    return NotFound();

                }









                // UPDATE ONLY EDITABLE FIELDS


                existingDriver.DriverName =
                    driver.DriverName;



                existingDriver.LicenseNumber =
                    driver.LicenseNumber;



                existingDriver.LicenseExpiryDate =
                    driver.LicenseExpiryDate;



                existingDriver.PhoneNumber =
                    driver.PhoneNumber;



                existingDriver.Email =
                    driver.Email;



                existingDriver.AssignedRoute =
                    driver.AssignedRoute;



                existingDriver.WorkingHours =
                    driver.WorkingHours;



                existingDriver.Status =
                    driver.Status;



                existingDriver.Notes =
                    driver.Notes;









                await _context.SaveChangesAsync();









                TempData["SuccessMessage"] =
                    "Driver updated successfully!";









                return RedirectToAction(
                    nameof(Index)
                );


            }

            catch
            {


                await LoadRoutes();



                TempData["ErrorMessage"] =
                    "Driver update failed.";



                return View(driver);


            }


        }

        // =========================================================
        // DELETE PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {


            var driver =
                await _context.Drivers
                .FindAsync(id);





            if (driver == null)
            {

                return NotFound();

            }





            return View(driver);


        }









        // =========================================================
        // DELETE CONFIRM
        // =========================================================


        [HttpPost]

        [ActionName("Delete")]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(
            int id)
        {


            var driver =
                await _context.Drivers
                .FindAsync(id);









            if (driver == null)
            {


                TempData["ErrorMessage"] =
                    "Driver could not be deleted.";




                return RedirectToAction(
                    nameof(Index)
                );


            }









            // =====================================================
            // SOFT DELETE
            // =====================================================


            driver.IsActive = false;





            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Driver deleted successfully!";









            return RedirectToAction(
                nameof(Index)
            );


        }





    }   // END DriverManagementController CLASS



}       // END NAMESPACE
