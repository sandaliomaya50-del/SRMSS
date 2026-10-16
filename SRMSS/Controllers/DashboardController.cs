using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;

namespace SRMSS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalBuses = await _context.Buses.CountAsync();

            ViewBag.TotalDrivers = await _context.Drivers.CountAsync();

            ViewBag.TotalRoutes = await _context.Routes.CountAsync();

            ViewBag.TotalSchedules = await _context.Schedules.CountAsync();

            ViewBag.OnTimeTrips = await _context.Trips
                .CountAsync(t => t.Status == "On-Time");

            ViewBag.DelayedTrips = await _context.Trips
                .CountAsync(t => t.Status == "Delayed");

            ViewBag.CompletedTrips = await _context.Trips
                .CountAsync(t => t.Status == "Completed");

            ViewBag.TotalFuelCost = await _context.FuelLogs
                .SumAsync(f => (decimal?)f.FuelCost) ?? 0;

            ViewBag.MaintenanceCount = await _context.Maintenance
                .CountAsync();

            return View();
        }
    }
}