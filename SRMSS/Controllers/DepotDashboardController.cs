using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;

namespace SRMSS.Controllers
{

    public class DepotDashboardController : Controller
    {


        private readonly ApplicationDbContext _context;




        public DepotDashboardController(ApplicationDbContext context)
        {

            _context = context;

        }








        // =========================================================
        // DEPOT DASHBOARD INDEX
        // =========================================================


        public async Task<IActionResult> Index()
        {



            // =====================================================
            // DEPOT STATISTICS
            // =====================================================



            ViewBag.ActiveRoutes =
                await _context.Routes.CountAsync();





            ViewBag.AvailableBuses =
                await _context.Buses.CountAsync();





            ViewBag.AssignedDrivers =
                await _context.Drivers.CountAsync();





            ViewBag.CurrentTrips =
                await _context.Trips.CountAsync();







            ViewBag.DelayedTrips =
                await _context.Trips
                .CountAsync(t => t.Status == "Delayed");







            ViewBag.CompletedTrips =
                await _context.Trips
                .CountAsync(t => t.Status == "Completed");









            // =====================================================
            // DEPOT CAPACITY
            // =====================================================



            ViewBag.UnderMaintenance =
                await _context.Maintenance.CountAsync();









            // =====================================================
            // TRIP SUMMARY
            // =====================================================



            ViewBag.OnTimeTrips =
                await _context.Trips
                .CountAsync(t => t.Status == "On-Time");









            // =====================================================
            // FUEL INFORMATION
            // =====================================================



            ViewBag.TotalFuelCost =
                await _context.FuelLogs
                .SumAsync(f => (decimal?)f.FuelCost) ?? 0;









            // =====================================================
            // MAINTENANCE SUMMARY
            // =====================================================



            ViewBag.MaintenanceCount =
                await _context.Maintenance
                .CountAsync();









            return View();



        }



    }

}