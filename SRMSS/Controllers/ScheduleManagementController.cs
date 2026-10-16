using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSS.Data;
using SRMSS.Models;
using SRMSS.ViewModels;

namespace SRMSS.Controllers
{

    public class ScheduleManagementController : Controller
    {


        private readonly ApplicationDbContext _context;



        public ScheduleManagementController(ApplicationDbContext context)
        {

            _context = context;

        }







        // =========================================================
        // LOAD SCHEDULE MANAGEMENT PAGE
        // =========================================================

        public IActionResult Index()
        {


            var model = new ScheduleManagementViewModel
            {


                Routes = _context.Routes
                    .Select(x => new SelectListItem
                    {
                        Value = x.RouteName,
                        Text = x.RouteName

                    })
                    .ToList(),






                Buses = _context.Buses
                    .Select(x => new SelectListItem
                    {
                        Value = x.RegistrationNumber,
                        Text = x.RegistrationNumber

                    })
                    .ToList(),






                Drivers = _context.Drivers
                    .Select(x => new SelectListItem
                    {
                        Value = x.DriverName,
                        Text = x.DriverName

                    })
                    .ToList(),






                // =========================================================
                // TODAY SCHEDULE SUMMARY
                // =========================================================

                TotalTrips = _context.Schedules.Count(),


                OnTimeTrips = _context.Schedules
                    .Count(x => x.ScheduleStatus == "On Time"),


                DelayedTrips = _context.Schedules
                    .Count(x => x.ScheduleStatus == "Delayed"),


                CompletedTrips = _context.Schedules
                    .Count(x => x.ScheduleStatus == "Completed")



            };





            return View(model);


        }









        // =========================================================
        // SAVE SCHEDULE
        // =========================================================


        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SaveSchedule(

            string route,

            string bus,

            string driver,

            DateTime date,

            string departureTime,

            string arrivalTime,

            string scheduleStatus,

            string? notes)

        {


            try
            {


                var schedule = new Schedule
                {


                    Route = route,


                    Bus = bus,


                    Driver = driver,


                    Date = date,


                    DepartureTime = departureTime,


                    ArrivalTime = arrivalTime,


                    ScheduleStatus = scheduleStatus,


                    Notes = notes


                };







                _context.Schedules.Add(schedule);







                await _context.SaveChangesAsync();







                TempData["SuccessMessage"] =
                    "Schedule Management saved successfully!";



            }

            catch (Exception ex)
            {


                TempData["ErrorMessage"] =
                    ex.InnerException?.Message ?? ex.Message;


            }







            return RedirectToAction(nameof(Index));



        }







    }

}