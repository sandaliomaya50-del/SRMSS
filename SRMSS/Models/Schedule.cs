using System.ComponentModel.DataAnnotations;

namespace SRMSS.Models
{
    public class Schedule
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please select route")]
        [Display(Name = "Route")]
        public string Route { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please select bus")]
        [Display(Name = "Bus")]
        public string Bus { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please select driver")]
        [Display(Name = "Driver")]
        public string Driver { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please select date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }



        [Required(ErrorMessage = "Please select departure time")]
        [Display(Name = "Departure Time")]
        public string DepartureTime { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please select arrival time")]
        [Display(Name = "Arrival Time")]
        public string ArrivalTime { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please select schedule status")]
        [Display(Name = "Schedule Status")]
        public string ScheduleStatus { get; set; } = string.Empty;



        [Display(Name = "Notes")]
        public string? Notes { get; set; }
    }
}