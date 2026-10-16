using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;

namespace SRMSS.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // =====================================================
            // TRIP COUNTS
            // =====================================================

            int totalTrips = await _context.Trips.CountAsync();

            int completedTrips = await _context.Trips
                .CountAsync(t => t.Status == "Completed");

            int onTimeTrips = await _context.Trips
                .CountAsync(t => t.Status == "On-Time");

            int delayedTrips = await _context.Trips
                .CountAsync(t => t.Status == "Delayed");

            int cancelledTrips = await _context.Trips
                .CountAsync(t => t.Status == "Cancelled");


            // =====================================================
            // ROUTES
            // =====================================================

            int totalRoutes = await _context.Routes.CountAsync();


            // =====================================================
            // FUEL
            // =====================================================

            decimal totalFuelCost = await _context.FuelLogs
                .SumAsync(f => (decimal?)f.FuelCost) ?? 0;


            // =====================================================
            // MAINTENANCE
            // =====================================================

            int maintenanceCount = await _context.Maintenance
                .CountAsync();


            // =====================================================
            // PERCENTAGES
            // =====================================================

            double completedPercentage = 0;
            double onTimePercentage = 0;
            double delayedPercentage = 0;
            double cancelledPercentage = 0;

            if (totalTrips > 0)
            {
                completedPercentage =
                    Math.Round(
                        ((double)completedTrips / totalTrips) * 100,
                        1);

                onTimePercentage =
                    Math.Round(
                        ((double)onTimeTrips / totalTrips) * 100,
                        1);

                delayedPercentage =
                    Math.Round(
                        ((double)delayedTrips / totalTrips) * 100,
                        1);

                cancelledPercentage =
                    Math.Round(
                        ((double)cancelledTrips / totalTrips) * 100,
                        1);
            }


            // =====================================================
            // VIEWBAG VALUES
            // =====================================================

            ViewBag.TotalTrips = totalTrips;

            ViewBag.CompletedTrips = completedTrips;

            ViewBag.OnTimeTrips = onTimeTrips;

            ViewBag.DelayedTrips = delayedTrips;

            ViewBag.CancelledTrips = cancelledTrips;

            ViewBag.TotalRoutes = totalRoutes;

            ViewBag.TotalFuelCost = totalFuelCost;

            ViewBag.MaintenanceCount = maintenanceCount;


            ViewBag.CompletedPercentage = completedPercentage;

            ViewBag.OnTimePercentage = onTimePercentage;

            ViewBag.DelayedPercentage = delayedPercentage;

            ViewBag.CancelledPercentage = cancelledPercentage;


            return View();
        }
    }
}