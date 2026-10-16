using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMSS.Data;
using SRMSS.Models;

namespace SRMSS.Controllers
{
    public class ScheduleListController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ScheduleListController(
            ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var schedules =
                await _context.Schedules
                    .OrderByDescending(s => s.Date)
                    .ThenBy(s => s.DepartureTime)
                    .Select(s => new ScheduleListViewModel
                    {
                        ScheduleId = s.Id,

                        ScheduleCode =
                            "SCH-" +
                            s.Id.ToString("D3"),

                        Route = s.Route,

                        Bus = s.Bus,

                        Driver = s.Driver,

                        DepartureTime =
                            s.DepartureTime,

                        ArrivalTime =
                            s.ArrivalTime,

                        Date = s.Date,

                        ScheduleStatus =
                            s.ScheduleStatus,

                        Notes = s.Notes
                    })
                    .ToListAsync();


            return View(schedules);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(
            int scheduleId)
        {
            try
            {
                var schedule =
                    await _context.Schedules
                        .FirstOrDefaultAsync(
                            s => s.Id == scheduleId
                        );


                if (schedule == null)
                {
                    TempData["WarningMessage"] =
                        "Schedule could not be found.";

                    return RedirectToAction(
                        nameof(Index)
                    );
                }


                _context.Schedules.Remove(
                    schedule
                );


                await _context.SaveChangesAsync();


                TempData["SuccessMessage"] =
                    "Schedule Deleted successfully.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] =
                    "Schedule could not be deleted.";
            }


            return RedirectToAction(
                nameof(Index)
            );
        }
    }
}
