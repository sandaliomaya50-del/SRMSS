using Microsoft.AspNetCore.Mvc.Rendering;
using SRMSS.Models;

namespace SRMSS.ViewModels
{
    public class ScheduleManagementViewModel
    {

        // =========================================================
        // SCHEDULE DATA
        // =========================================================

        public Schedule Schedule { get; set; } = new Schedule();




        // =========================================================
        // DROPDOWN LISTS
        // =========================================================

        public List<SelectListItem> Routes { get; set; }
            = new List<SelectListItem>();


        public List<SelectListItem> Buses { get; set; }
            = new List<SelectListItem>();


        public List<SelectListItem> Drivers { get; set; }
            = new List<SelectListItem>();






        // =========================================================
        // TODAY SCHEDULE SUMMARY
        // =========================================================

        public int TotalTrips { get; set; }


        public int OnTimeTrips { get; set; }


        public int DelayedTrips { get; set; }


        public int CompletedTrips { get; set; }


    }
}