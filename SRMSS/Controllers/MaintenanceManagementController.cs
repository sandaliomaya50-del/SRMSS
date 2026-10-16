using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;
using SRMSS.Models;



namespace SRMSS.Controllers
{

    public class MaintenanceManagementController : Controller
    {



        private readonly ApplicationDbContext _context;





        public MaintenanceManagementController(ApplicationDbContext context)
        {

            _context = context;

        }









        // =========================================================
        // MAINTENANCE MANAGEMENT INDEX
        // =========================================================


        public async Task<IActionResult> Index()
        {


            await LoadVehicles();





            var maintenanceRecords =
                await _context.Maintenance
                .OrderByDescending(m => m.MaintenanceDate)
                .ToListAsync();






            return View(maintenanceRecords);


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
        // CREATE MAINTENANCE PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Create()
        {


            return RedirectToAction(nameof(Index));


        }









        // =========================================================
        // CREATE MAINTENANCE SAVE
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(
            Maintenance maintenance,
            int VehicleId)
        {




            if (!ModelState.IsValid)
            {


                await LoadVehicles();


                TempData["ErrorMessage"] =
                    "Please check the entered maintenance details.";



                return View(maintenance);


            }









            // MAP VEHICLE TO MAINTENANCE

            maintenance.BusId =
                VehicleId;









            // SAVE DATE VALUES

            if (maintenance.MaintenanceDate == DateTime.MinValue)
            {

                maintenance.MaintenanceDate =
                    DateTime.Now;

            }









            _context.Maintenance.Add(maintenance);



            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Maintenance record saved successfully!";









            return RedirectToAction(
                nameof(Index)
            );


        }









        // =========================================================
        // DELETE MAINTENANCE RECORD
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(
            int id)
        {



            var maintenance =
                await _context.Maintenance
                .FindAsync(id);







            if (maintenance == null)
            {


                TempData["ErrorMessage"] =
                    "Maintenance record could not be deleted.";



                return RedirectToAction(
                    nameof(Index)
                );


            }









            _context.Maintenance.Remove(maintenance);



            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Maintenance record deleted successfully!";









            return RedirectToAction(
                nameof(Index)
            );


        }









        // =========================================================
        // DETAILS
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Details(
            int id)
        {


            var maintenance =
                await _context.Maintenance
                .FirstOrDefaultAsync(
                    m => m.MaintenanceId == id
                );





            if (maintenance == null)
            {


                TempData["ErrorMessage"] =
                    "Maintenance record not found.";



                return RedirectToAction(
                    nameof(Index)
                );


            }






            return View(maintenance);


        }









        // =========================================================
        // EDIT MAINTENANCE PAGE
        // =========================================================


        [HttpGet]

        public async Task<IActionResult> Edit(
            int id)
        {


            await LoadVehicles();





            var maintenance =
                await _context.Maintenance
                .FindAsync(id);





            if (maintenance == null)
            {


                TempData["ErrorMessage"] =
                    "Maintenance record not found.";



                return RedirectToAction(
                    nameof(Index)
                );


            }







            return View(maintenance);


        }









        // =========================================================
        // EDIT MAINTENANCE SAVE
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(
            int id,
            Maintenance maintenance)
        {


            if (id != maintenance.MaintenanceId)
            {


                return NotFound();


            }







            if (!ModelState.IsValid)
            {


                await LoadVehicles();


                return View(maintenance);


            }







            _context.Maintenance.Update(maintenance);



            await _context.SaveChangesAsync();









            TempData["SuccessMessage"] =
                "Maintenance record updated successfully!";









            return RedirectToAction(
                nameof(Index)
            );


        }









    }

}
