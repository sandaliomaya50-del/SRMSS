using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;
using SRMSS.Models;


namespace SRMSS.Controllers
{

    public class VehicleManagementController : Controller
    {


        private readonly ApplicationDbContext _context;



        public VehicleManagementController(ApplicationDbContext context)
        {

            _context = context;

        }









        // =========================================================
        // VEHICLE MANAGEMENT INDEX
        // =========================================================


        public async Task<IActionResult> Index()
        {


            var vehicles =
                await _context.Vehicles
                .Where(v => v.IsActive)
                .OrderByDescending(v => v.CreatedDate)
                .ToListAsync();



            // LOAD DRIVERS FOR DROPDOWN

            await LoadDrivers();




            return View(vehicles);

        }









        // =========================================================
        // LOAD DRIVERS FOR DROPDOWN
        // =========================================================


        private async Task LoadDrivers()
        {


            ViewBag.Drivers =
                await _context.Drivers
                .OrderBy(d => d.DriverName)
                .ToListAsync();


        }


        // =========================================================
        // CREATE VEHICLE - PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Create()
        {


            await LoadDrivers();


            return View();

        }









        // =========================================================
        // CREATE VEHICLE - SAVE
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(
            Vehicle vehicle,
            IFormFile? VehicleImage)
        {



            if (!ModelState.IsValid)
            {


                await LoadDrivers();


                TempData["ErrorMessage"] =
                    "Please check the entered vehicle details.";


                return View(vehicle);

            }







            // =====================================================
            // IMAGE UPLOAD
            // =====================================================


            if (VehicleImage != null && VehicleImage.Length > 0)
            {


                string uploadFolder =
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "Images",
                        "Vehicles"
                    );




                if (!Directory.Exists(uploadFolder))
                {

                    Directory.CreateDirectory(uploadFolder);

                }






                string fileName =
                    Guid.NewGuid().ToString()
                    +
                    Path.GetExtension(
                        VehicleImage.FileName
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


                    await VehicleImage.CopyToAsync(stream);


                }






                vehicle.VehicleImage =
                    "/Images/Vehicles/" + fileName;


            }









            // =====================================================
            // SYSTEM VALUES
            // =====================================================


            vehicle.CreatedDate =
                DateTime.Now;



            vehicle.IsActive =
                true;









            // =====================================================
            // SAVE VEHICLE
            // =====================================================


            _context.Vehicles.Add(vehicle);



            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Vehicle saved successfully!";








            return RedirectToAction(
                nameof(Index)
            );


        }


        // =========================================================
        // DETAILS
        // =========================================================


        public async Task<IActionResult> Details(int id)
        {


            var vehicle =
                await _context.Vehicles
                .FirstOrDefaultAsync(
                    v => v.VehicleId == id
                );



            if (vehicle == null)
            {

                return NotFound();

            }



            return View(vehicle);


        }









        // =========================================================
        // EDIT PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {


            var vehicle =
                await _context.Vehicles
                .FindAsync(id);




            if (vehicle == null)
            {

                return NotFound();

            }



            await LoadDrivers();



            return View(vehicle);


        }









        // =========================================================
        // EDIT SAVE
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(
            int id,
            Vehicle vehicle)
        {


            if (id != vehicle.VehicleId)
            {

                return NotFound();

            }







            if (!ModelState.IsValid)
            {


                await LoadDrivers();


                TempData["ErrorMessage"] =
                    "Please check the entered vehicle details.";


                return View(vehicle);


            }







            try
            {


                _context.Update(vehicle);



                await _context.SaveChangesAsync();







                TempData["SuccessMessage"] =
                    "Vehicle updated successfully!";







                return RedirectToAction(
                    nameof(Index)
                );


            }

            catch
            {


                await LoadDrivers();


                TempData["ErrorMessage"] =
                    "Vehicle update failed.";


                return View(vehicle);


            }


        }
        // =========================================================
        // DELETE PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {


            var vehicle =
                await _context.Vehicles
                .FindAsync(id);




            if (vehicle == null)
            {

                return NotFound();

            }



            return View(vehicle);


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


            var vehicle =
                await _context.Vehicles
                .FindAsync(id);







            if (vehicle == null)
            {


                TempData["ErrorMessage"] =
                    "Vehicle could not be deleted.";


                return RedirectToAction(
                    nameof(Index)
                );


            }









            // SOFT DELETE

            vehicle.IsActive = false;



            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Vehicle deleted successfully!";








            return RedirectToAction(
                nameof(Index)
            );


        }




    }   // END VehicleManagementController CLASS


}       // END NAMESPACE