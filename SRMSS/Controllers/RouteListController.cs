using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;
using SRMSS.Models;

namespace SRMSS.Controllers
{
    public class RouteListController : Controller
    {
        private readonly ApplicationDbContext _context;


        public RouteListController(ApplicationDbContext context)
        {
            _context = context;
        }



        // =========================================================
        // ROUTE LIST
        // =========================================================
        public async Task<IActionResult> Index()
        {
            var routes = await _context.Routes
                .GroupJoin(
                    _context.RouteManagementDetails,
                    route => route.RouteId,
                    detail => detail.RouteId,
                    (route, details) => new
                    {
                        Route = route,
                        Detail = details.FirstOrDefault()
                    })
                .Select(x => new RouteListViewModel
                {
                    RouteId = x.Route.RouteId,

                    RouteCode = x.Route.RouteName,

                    StartPoint = x.Route.StartLocation,

                    EndPoint = x.Route.EndLocation,

                    DistanceKm = x.Route.DistanceKm,

                    Status = x.Route.Status,


                    IntermediateStops = x.Detail == null
                        ? null
                        : x.Detail.IntermediateStops,


                    ServiceType = x.Detail == null
                        ? string.Empty
                        : x.Detail.ServiceType ?? string.Empty,


                    AssignedBus = x.Detail == null
                        ? null
                        : x.Detail.AssignedBus,


                    AssignedDriver = x.Detail == null
                        ? null
                        : x.Detail.AssignedDriver

                })
                .OrderBy(x => x.RouteId)
                .ToListAsync();



            return View(routes);
        }





        // =========================================================
        // DELETE ROUTE
        // =========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int routeId)
        {

            var route = await _context.Routes
                .FirstOrDefaultAsync(
                    r => r.RouteId == routeId
                );



            if (route == null)
            {

                TempData["WarningMessage"] =
                    "Route could not be found.";


                return RedirectToAction(
                    nameof(Index)
                );

            }





            var routeDetails = await _context.RouteManagementDetails
                .Where(
                    d => d.RouteId == routeId
                )
                .ToListAsync();





            if (routeDetails.Any())
            {

                _context.RouteManagementDetails
                    .RemoveRange(routeDetails);

            }





            _context.Routes.Remove(route);



            await _context.SaveChangesAsync();





            // ONLY NOTIFICATION MESSAGE CHANGED

            TempData["SuccessMessage"] =
                "Route Deleted Successfully.";





            return RedirectToAction(
                nameof(Index)
            );
        }
    }
}
