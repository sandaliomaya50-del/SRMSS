using Microsoft.AspNetCore.Mvc;
using SRMSS.Data;

namespace SRMSS.Controllers
{
    public class RouteManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RouteManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRoute(
            string routeCode,
            string startPoint,
            string endPoint,
            string? intermediateStops,
            decimal totalDistanceKm,
            string serviceType,
            string? assignedBus,
            string? assignedDriver)
        {
            var route = new SRMSS.Models.Route
            {
                RouteName = routeCode,
                StartLocation = startPoint,
                EndLocation = endPoint,
                DistanceKm = totalDistanceKm,
                Status = "Active"
            };

            _context.Routes.Add(route);

            await _context.SaveChangesAsync();

            var routeDetails = new SRMSS.Models.RouteManagementDetail
            {
                RouteId = route.RouteId,
                IntermediateStops = intermediateStops,
                ServiceType = serviceType,
                AssignedBus = assignedBus,
                AssignedDriver = assignedDriver,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _context.RouteManagementDetails.Add(routeDetails);

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Route saved successfully!";

            return RedirectToAction(nameof(Index));
        }
    }
}
